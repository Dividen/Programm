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
    public partial class Parents : Form
    {
        OrgSQLEntities2 content = new OrgSQLEntities2();

        public int index;

        public Parents()
        {
            InitializeComponent();
        }

        public void Refr()
        {
            призывникBindingSource.DataSource = content.Prizivnik.Where(p => p.IDПризывника == index).ToList();
            типРодстваBindingSource.DataSource = content.ТипРодства.ToList();
        }

        private void Parents_Load(object sender, EventArgs e)
        {
            Refr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Родитель newRod = new Родитель();
            newRod.IDПризывника = index;
            content.Родитель.AddObject(newRod);
            content.SaveChanges();
            Refr();
        }

    }
}
