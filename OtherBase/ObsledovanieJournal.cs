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
    public partial class ObsledovanieJournal : Form
    {
        OrgSQLEntities2 or = new OrgSQLEntities2();

        public ObsledovanieJournal()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            var query = from i in or.Обследование
                        from j in or.Prizivnik
                        where ((i.IDПризывника == j.IDПризывника) && (j.IDОтсрочки == 5))
                        select new {i.IDобследования,j.Имя,j.Фамилия,j.Отчество,j.Дата_Рождения,i.Дата_направления,i.Кто_направил,i.Диагноз,i.Лечебное_учереждение,i.Дата_получения_акта,i.Номер_протокола,i.Решение_ПК,i.Дата_передачи_в_2_ОТД,i.Дата_обращения_за_ВБ,i.Дата_получения_ВБ,i.Примечание,i.Дата_прибытия_после_обследования};
            dataGridView1.DataSource = new SortableBindingList<object>(query);
        }

        private void ObsledovanieJournal_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reload();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            or.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reload();
            //or.Refresh(System.Data.Objects.RefreshMode.ClientWins, dataGridView1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             var query = from i in or.Обследование
                        from j in or.Prizivnik
                        where ( (i.IDПризывника == j.IDПризывника) && (j.IDОтсрочки == 5) &&  (j.Имя.Contains(textBox1.Text) || j.Фамилия.Contains(textBox1.Text) || j.Отчество.Contains(textBox1.Text)))  
                        select new {i.IDобследования,j.Имя,j.Фамилия,j.Отчество,j.Дата_Рождения,i.Дата_направления,i.Кто_направил,i.Диагноз,i.Лечебное_учереждение,i.Дата_получения_акта,i.Номер_протокола,i.Решение_ПК,i.Дата_передачи_в_2_ОТД,i.Дата_обращения_за_ВБ,i.Дата_получения_ВБ,i.Примечание,i.Дата_прибытия_после_обследования};
            dataGridView1.DataSource = new SortableBindingList<object>(query);
        }

     
    }
}
