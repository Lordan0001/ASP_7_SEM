using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormForSimplex.ServiceReference1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormForSimplex
{
    public partial class Form1 : Form
    {
        SimplexSoapClient obj;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A a1 = new A();
            A a2 = new A();

            a1.s = Convert.ToString(textBoxAS.Text);
            a1.k = Convert.ToInt32(textBoxAK.Text);
            a1.f = float.Parse(textBoxAF.Text);


            a2.s = Convert.ToString(textBoxBS.Text);
            a2.k = Convert.ToInt32(textBoxBK.Text);
            a2.f = float.Parse(textBoxBF.Text);

            var a3 = obj.Sum(a1, a2);
            string result = $"s = {a3.s} k = {a3.k} f = {a3.f}";
            MessageBox.Show(result);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obj = new SimplexSoapClient();
        }
    }
}
