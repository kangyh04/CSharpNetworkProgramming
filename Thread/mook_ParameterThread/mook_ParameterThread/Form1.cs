using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace mook_ParameterThread
{
    public partial class Form1 : Form
    {
        Thread SumThread = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            SumThread = new Thread(new ParameterizedThreadStart(NumSum));
            SumThread.Start(this.txtNum.Text);
        }

        private void NumSum(object n)
        {
            long sum = 0;
            long k = Convert.ToInt64(n);
            for(long i = 0; i <=k; i++)
            {
                Thread.Sleep(1);
                sum += i;
                this.lblResult.Text = "calculating : " + sum.ToString();
            }

            this.lblResult.Text = "result : " + sum.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SumThread != null)
                SumThread.Abort();
        }
    }
}
