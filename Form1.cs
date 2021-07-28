using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_In_Words
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btesc_Click(object sender, EventArgs e) => textBox2.Clear();

        private void Btenter_Click(object sender, EventArgs e)
        {
            In_Words in_Words = new In_Words();
            textBox2.Text=in_Words.Begin(textBox1.Text);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для преобразования числа в словесный вид", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
