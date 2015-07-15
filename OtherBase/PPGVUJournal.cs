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
    public partial class PPGVUJournal : Form
    {
        OrgSQLEntities2 or = new OrgSQLEntities2();

        public PPGVUJournal()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(or.Prizivnik.Where(p => p.IDОтсрочки == 3).ToList());    
        }

        private void PPGVUJournal_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(or.Prizivnik.Where(p => p.IDОтсрочки == 3 && (p.Имя.Contains(textBox1.Text) || p.Фамилия.Contains(textBox1.Text) || p.Отчество.Contains(textBox1.Text))));    
        }
    }
}
