using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += async (sender, e) =>
            {
                await TestMethodAsync();
                MessageBox.Show("Task complete");
            };

        }

        async Task TestMethodAsync()
        {
            // just a delay
            await Task.Delay(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
    
