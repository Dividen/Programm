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
    public partial class PrizivJournal : Form
    {
        OrgSQLEntities2 or = new OrgSQLEntities2();
        public PrizivJournal()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(or.Prizivnik.Where(p => p.IDОтсрочки == 2).ToList());
        }
        private void PrizivJournal_Load(object sender, EventArgs e)
        {
            Reload();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(or.Prizivnik.Where(p => p.IDОтсрочки == 2 && (p.Имя.Contains(textBox1.Text) || p.Фамилия.Contains(textBox1.Text) || p.Отчество.Contains(textBox1.Text))));
        }
    }
}
