using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtherBase
{
    public partial class OtchetRoziskTekst : Form
    {
        public OtchetRoziskTekst()
        {
            InitializeComponent();
        }

        private void OtchetRoziskTekst_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
