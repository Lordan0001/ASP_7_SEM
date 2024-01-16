using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class SumWebForm : System.Web.UI.Page
    {
        private Server server;
        protected void Page_Load(object sender, EventArgs e)
        {
            server = new Server();
        }
        protected void Sum_Click(object sender, EventArgs e)
        {

            A a1 = new A();
            A a2 = new A();

            a1.s = Convert.ToString(a_s.Text);
            a1.k = Convert.ToInt32(a_k.Text);
            a1.f = float.Parse(a_f.Text);


            a2.s = Convert.ToString(b_s.Text);
            a2.k = Convert.ToInt32(b_k.Text);
            a2.f = float.Parse(b_f.Text);

            var a3 = server.Sum(a1, a2);
            string resultString = $"s = {a3.s} k = {a3.k} f = {a3.f}";
            result.Text = resultString;

        }
    }
}