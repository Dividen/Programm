using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Be.Timvw.Framework.Collections.Generic;
using Be.Timvw.Framework.ComponentModel;

namespace OtherBase
{
    public partial class OtsrochJournal : Form
    {
        OrgSQLEntities2 or = new OrgSQLEntities2();
        public OtsrochJournal()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(or.Prizivnik.Where(p => p.IDОтсрочки == 1).ToList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        private void OtsrochJournal_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(or.Prizivnik.Where(p => p.IDОтсрочки == 1 && (p.Имя.Contains(textBox1.Text) || p.Фамилия.Contains(textBox1.Text) || p.Отчество.Contains(textBox1.Text))));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        
    }
}
