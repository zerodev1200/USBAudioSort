using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace USBAudioSort
{
    class DirectoryUtils
    {
        public static string SelectDirectoryName()
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.Description = "フォルダを選択してください";
                if (fbd.ShowDialog() == DialogResult.OK)
                    return fbd.SelectedPath;
            }
            return "";
        }

        public static IEnumerable<DirectoryInfo> GetDirectoryInfoList(string rootPath)
        {
            if (GetDriveType(Path.GetPathRoot(rootPath)) != 2)
                throw new ApplicationException("リムーブバルディスクを選択してください。");
            var diList = new DirectoryInfo(rootPath);
            foreach (var di in diList.GetDirectories())
            {
                yield return di;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetDriveType([MarshalAs(UnmanagedType.LPTStr)] string nDrive);
    }
}
