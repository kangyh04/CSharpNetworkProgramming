using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace mook_ThreadReceiveData
{
    public partial class Form1 : Form
    {
        Thread ReceThread = null;
        bool Runflags = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            ReceThread = new Thread(ReceiveData);
            ReceThread.Start();
        }

        private void ReceiveData()
        {
            while (Runflags)
            {
                Thread.Sleep(1);
                foreach(var proc in Process.GetProcesses())
                {
                    if (proc.ProcessName.ToString() == "mook_SendData")
                    {
                        Runflags = false;
                        this.lblReceive02.Text = "received data is : " + mook_SendData.Form1.Word;
                    }
                }
            }
            ReceThread.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ReceThread != null)
                ReceThread.Abort();
        }
    }
}
