using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praqnique1._1
{
    public partial class Form1 : Form
    {
        CPraqnique ObjPraqnique = new CPraqnique();
        public Form1()
        {
            InitializeComponent();
            ObjPraqnique.InitializeData(picCanvas);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            ObjPraqnique.ReadData(txtSide);
            ObjPraqnique.GraphShape1(picCanvas);
            ObjPraqnique.GraphShape2(picCanvas);
            ObjPraqnique.GraphShape3(picCanvas);
            ObjPraqnique.GraphShape4(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjPraqnique.InitializeData(picCanvas);
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
