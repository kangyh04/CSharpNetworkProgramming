using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_ReceiveData
{
    public partial class Form1 : Form
    {
        bool Runflags = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            while (Runflags)
            {
                System.Threading.Thread.Sleep(1);
                foreach(var proc in Process.GetProcesses())
                {
                    if (proc.ProcessName.ToString() == "mook_SendData")
                    {
                        Runflags = false;
                        this.lblReceive02.Text = "Runned and result is " + mook_SendData.Form1.Word;
                    }
                }
            }
        }
    }
}
