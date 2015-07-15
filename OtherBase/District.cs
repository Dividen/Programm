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
    public partial class District : Form
    {
        OrgSQLEntities2 org = new OrgSQLEntities2();

        public void Refreshh()
        {
            районBindingSource.DataSource = org.Район.ToList();
        }
        public District()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = (int.Parse(районDataGridView.CurrentRow.Cells["IDDistrict"].Value.ToString()));
            Район delet = org.Район.Where(p => p.IDРайона == index).First();
            org.Район.DeleteObject(delet);
            org.SaveChanges();
            Refreshh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sotrud = new Район();
            using (var context = new OrgSQLEntities2())
            {
                context.CreateObjectSet<Район>().Attach(sotrud);
                context.ObjectStateManager.ChangeObjectState(sotrud, EntityState.Added);
                context.SaveChanges();
            }
            org.SaveChanges();
            Refreshh();
        }

        private void District_Load(object sender, EventArgs e)
        {
            Refreshh();
        }
    }
}
