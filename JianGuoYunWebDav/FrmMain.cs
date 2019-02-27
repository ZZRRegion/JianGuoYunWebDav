using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JianGuoYunWebDav
{
    public partial class FrmMain : Form
    {
        private HttpWebDav HttpWebDav = new HttpWebDav();
        public FrmMain()
        {
            InitializeComponent();
        }

        private  void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private async void btnMake_Click(object sender, EventArgs e)
        {
            bool b = await this.HttpWebDav.MakeFolder("test");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            bool b = await this.HttpWebDav.Delete("test.txt");

        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            bool b = await this.HttpWebDav.Upload("test.txt", Encoding.UTF8.GetBytes("hello world"));
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            byte[] bys = await this.HttpWebDav.GetBytes("test.txt");
        }
    }
}
