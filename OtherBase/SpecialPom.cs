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
    public partial class SpecialPom : Form
    {
        OrgSQLEntities2 org = new OrgSQLEntities2();
        public SpecialPom()
        {
            InitializeComponent();
        }

        public void Refreshh()
        {

            отсрочкаBindingSource.DataSource = org.Отсрочка.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sotrud = new Отсрочка();
            using (var context = new OrgSQLEntities2())
            {
                context.CreateObjectSet<Отсрочка>().Attach(sotrud);
                context.ObjectStateManager.ChangeObjectState(sotrud, EntityState.Added);
                context.SaveChanges();
            }
            org.SaveChanges();
            Refreshh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = (int.Parse(отсрочкаDataGridView.CurrentRow.Cells["IDOtsroch"].Value.ToString()));
            Отсрочка delet = org.Отсрочка.Where(p => p.IDОтсрочки == index).First();
            org.Отсрочка.DeleteObject(delet);
            org.SaveChanges();
            Refreshh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
        }

        private void SpecialPom_Load(object sender, EventArgs e)
        {
            Refreshh();
        }
    }
}
