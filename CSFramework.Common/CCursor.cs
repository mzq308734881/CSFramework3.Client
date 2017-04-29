using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CSFramework.Common
{
    /// <summary>
    /// 显示等待光标
    /// </summary>
    public class CCursor
    {
        [DllImport("user32.dll")]
        public static extern long GetCursorPos(ref System.Drawing.Point lpPoint);

        /// <summary>
        /// 显示等待光标
        /// </summary>
        public static void ShowWaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
        }

        /// <summary>
        /// 显示预设光标
        /// </summary>
        public static void ShowDefaultCursor()
        {
            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }
    }
}
