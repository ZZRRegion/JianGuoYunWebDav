using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JianGuoYunWebDav
{
    public static class StCommon
    {
        public static string Version => "1.0.0.0";
        public static string VersionTime => "2019-02-27 21:30:00";
        public static void MsgBox(this Control @this, string msg)
        {
            MessageBox.Show(@this, msg);
        }
    }
}
