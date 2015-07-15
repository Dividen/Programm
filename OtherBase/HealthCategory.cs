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
    public partial class HealthCategory : Form
    {
        OrgSQLEntities2 org = new OrgSQLEntities2();

        public HealthCategory()
        {
            InitializeComponent();
        }

        public void Refreshh()
        {
            годностиBindingSource.DataSource = org.Годности.ToList();
        }

        

        private void HealthCategory_Load(object sender, EventArgs e)
        {
            Refreshh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = (int.Parse(годностиDataGridView.CurrentRow.Cells["IDGodnost"].Value.ToString()));
            Годности delet = org.Годности.Where(p => p.IDГодности == index).First();
            org.Годности.DeleteObject(delet);
            org.SaveChanges();
            Refreshh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sotrud = new Годности();
            using (var context = new OrgSQLEntities2())
            {
                context.CreateObjectSet<Годности>().Attach(sotrud);
                context.ObjectStateManager.ChangeObjectState(sotrud, EntityState.Added);
                context.SaveChanges();
            }
            org.SaveChanges();
            Refreshh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
        }
    }
}
