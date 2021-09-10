using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace USBAudioSort
{
    public partial class MainForm : Form
    {
        private string _rootDirectoryName = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MaximumSize = new Size(1200, Screen.GetWorkingArea(this).Height);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            MaximumSize = new Size(1200, Screen.GetWorkingArea(this).Height);
        }

        private void SelectDriveButton_Click(object sender, EventArgs e)
        {
            _rootDirectoryName = DirectoryUtils.SelectDirectoryName();
            if (string.IsNullOrEmpty(_rootDirectoryName))
                return;
            dataGridView1.Rows.Clear();
            try
            {
                var directoryInfoList = DirectoryUtils.GetDirectoryInfoList(_rootDirectoryName);
                foreach (var directoryInfo in directoryInfoList)
                {
                    dataGridView1.Rows.Add(directoryInfo.Name
                                        , directoryInfo.CreationTime
                                        , directoryInfo.LastWriteTime
                                        , directoryInfo.FullName
                                        );
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // マウスが長方形の外側に移動した場合は、ドラッグを開始します。
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    //リストアイテムを渡して、ドラッグアンドドロップを続行します。
                   dataGridView1.DoDragDrop(
                    dataGridView1.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // マウスの下にあるアイテムのインデックスを取得します。
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // DragSizeは、ドラッグイベントを開始する前にマウスが移動できるサイズを示します。              
                Size dragSize = SystemInformation.DragSize;

                // DragSizeを使用して長方形を作成し、マウスの位置を長方形の中心にします。
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                      dragSize);
            }
            else
                // マウスがリストボックス内の項目の上にない場合は、長方形をリセットします。
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            //マウスの位置は画面を基準にしているため、クライアントの座標に変換する必要があります。
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // マウスの下にあるアイテムの行インデックスを取得します。
            rowIndexOfItemUnderMouseToDrop =
                dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (rowIndexOfItemUnderMouseToDrop < 0)
                return;
            // ドラッグ操作が移動だった場合は、行を削除して挿入します。
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

            }
        }

        private void ToUpperButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            var currentRow = dataGridView1.SelectedRows[0];
            var currentRowCount = currentRow.Index;
            if (currentRowCount < 1)
                return;
            dataGridView1.Rows.RemoveAt(currentRowCount);
            dataGridView1.Rows.Insert(currentRowCount - 1, currentRow);
            dataGridView1.Rows[currentRowCount - 1].Selected = true;
        }

        private void ToLowerButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            var currentRow = dataGridView1.SelectedRows[0];
            var currentRowCount = currentRow.Index;
            if (currentRowCount == dataGridView1.Rows.Count - 1)
                return;
            dataGridView1.Rows.RemoveAt(currentRowCount);
            dataGridView1.Rows.Insert(currentRowCount + 1, currentRow);
            dataGridView1.Rows[currentRowCount + 1].Selected = true;
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                ToLowerButton.PerformClick();
                e.Handled = true;
                return;
            }
            if (e.KeyData == Keys.Up)
            {
                ToUpperButton.PerformClick();
                e.Handled = true;
                return;
            }
        }

        private async void TransferButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            var tempDirectoryPath = Path.Combine(_rootDirectoryName, "tempDirectory");
            var result = MessageBox.Show("転送を開始します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            var sourceData = GetPathListFromDataGridView();
            sourceData.Reverse();
            if (sourceData.Count == 0)
            {
                MessageBox.Show("転送するファイルが存在しませんでした。");
                return;
            }
            this.Enabled = false;

            TransferProgressBar.Minimum = 0;
            TransferProgressBar.Maximum = sourceData.Count * 2;
            TransferProgressBar.Value = 0;

            Directory.CreateDirectory(tempDirectoryPath);
            var errorList = new List<string>();
            foreach (var source in sourceData)
            {
                try
                {
                    var destinationPath = Path.Combine(tempDirectoryPath, Path.GetFileName(source));
                    await Task.Run(() => Directory.Move(source, destinationPath));
                    TransferProgressBar.Value++;
                }
                catch { errorList.Add(source); }
            }
            sourceData.Reverse();
            foreach (var source in sourceData)
            {
                if (errorList.Contains(source))
                    continue;
                try
                {
                    var sourcePath = Path.Combine(tempDirectoryPath, Path.GetFileName(source));
                    await Task.Run(() => Directory.Move(sourcePath, source));
                    TransferProgressBar.Value++;
                }
                catch { errorList.Add(source); }
            }
            var leftBehindCount = Directory.GetFileSystemEntries(tempDirectoryPath).Length;
            if (leftBehindCount == 0)
            {
                Directory.Delete(tempDirectoryPath);
                MessageBox.Show("ソートが完了しました。");
            }
            else
                MessageBox.Show("移動できていないファイル/フォルダがあります。" +
                                $"\r\n{tempDirectoryPath}を確認してください。");
            this.Enabled = true;
            TransferProgressBar.Value = 0;
        }

        private List<string> GetPathListFromDataGridView()
        {
            var pathList = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                pathList.Add(row.Cells[FullPathColumn.Index].Value.ToString());
            }
            return pathList;
        }

        private void ReverseDataGridViewItemsButton_Click(object sender, EventArgs e)
        {
            var rows = new List<DataGridViewRow>();
            rows.AddRange(dataGridView1.Rows.Cast<DataGridViewRow>());
            rows.Reverse();
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(rows.ToArray());
        }
    }
}
