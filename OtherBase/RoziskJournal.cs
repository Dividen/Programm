using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Be.Timvw.Framework.ComponentModel;
using Be.Timvw.Framework.Collections.Generic;

namespace OtherBase
{
    public partial class RoziskJournal : Form
    {
        OrgSQLEntities2 org = new OrgSQLEntities2();

        public RoziskJournal()
        {
            InitializeComponent();
        }


        public void Reload()
        {
            var query = (from i in org.Розыск
                         from j in org.Prizivnik
                         from z in org.Район
                         where ((j.IDОтсрочки == 4) && (j.Район == z.IDРайона) && (i.IDПризывника == j.IDПризывника))
                         select new { j.IDПризывника, j.Фамилия, j.Имя, j.Отчество, j.Дата_Рождения, z.Название, j.Домашний_адрес__телефон, j.Место_работы_должность_телефон, j.Место_обучения, i.Номер_этапа, i.Дата_прибытия, i.Результат, i.Отметка_о_прибытии,i.Направление_в_ОВД,i.Примечание });

            dataGridView1.DataSource = new SortableBindingList<object>(query);
        }

        private void RoziskJournal_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = (from i in org.Розыск
                         from j in org.Prizivnik
                         from z in org.Район
                         where ((j.IDОтсрочки == 4) && (j.Район == z.IDРайона) && (i.IDПризывника == j.IDПризывника) &&  ( (j.Имя.Contains(textBox1.Text) || j.Фамилия.Contains(textBox1.Text) || j.Отчество.Contains(textBox1.Text))))
                         select new { j.IDПризывника, j.Фамилия, j.Имя, j.Отчество, j.Дата_Рождения, z.Название, j.Домашний_адрес__телефон, j.Место_работы_должность_телефон, j.Место_обучения, i.Номер_этапа, i.Дата_прибытия, i.Результат, i.Отметка_о_прибытии });
            dataGridView1.DataSource = new SortableBindingList<object>(query);
        }
    }
}
