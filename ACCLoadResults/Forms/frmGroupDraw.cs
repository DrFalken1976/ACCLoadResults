using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACCLoadResults.Forms
{
    public partial class frmGroupDraw : Form
    {
        public frmGroupDraw()
        {
            InitializeComponent();
        }

        private void frmGroupDraw_Load(object sender, EventArgs e)
        {

            DomainUpDown.DomainUpDownItemCollection Items = GroupNum.Items;

            Items.Add(2);
            Items.Add(3);
            Items.Add(4);


        }
    }
}
