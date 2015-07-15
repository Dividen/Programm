using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Be.Timvw.Framework.ComponentModel;
using Be.Timvw.Framework.Collections.Generic;

namespace OtherBase
{
    public partial class ПризывникForm : Form
    {
        OrgSQLEntities2 org = new OrgSQLEntities2();
        PrizivJournal pj = new PrizivJournal();
        OtsrochJournal oj = new OtsrochJournal();
        PPGVUJournal ppg = new PPGVUJournal();
        ObsledovanieJournal jo = new ObsledovanieJournal();
        RoziskJournal rz = new RoziskJournal();
        Selection print = new Selection();
        Parents par = new Parents();

       public  bool select=false;

        public ПризывникForm()
        {
            InitializeComponent();
        }
        public System.Data.Objects.ObjectQuery<Призывник> LoadContent()
        {
            if (select == true)
            {
                var query = from bd in org.Prizivnik
                            where (bd.IDОтсрочки == 9)
                            select bd;
                return query as System.Data.Objects.ObjectQuery<Призывник>;
            }
            else
            {
                var query = from bd in org.Prizivnik
                            select bd;
                return query as System.Data.Objects.ObjectQuery<Призывник>;
            }
                
        }
        public void AddID()
        {
            var sotrud = new Призывник();
            using (var context = new OrgSQLEntities2())
            {
                context.CreateObjectSet<Призывник>().Attach(sotrud);
                context.ObjectStateManager.ChangeObjectState(sotrud, EntityState.Added);
                context.SaveChanges();
            }
            org.SaveChanges();
        }    

        public void Refreshh()
        {
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(LoadContent().Execute(System.Data.Objects.MergeOption.AppendOnly));
        }

        public void Check()
        {
            if (DataModul.key == 1)
            {

                foreach (DataGridViewRow r in ПризывникDataGridView.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if (c.Value != null) c.ReadOnly = true;
                    }
                }
                toolStripButton1.Enabled = false;
            }
        }         

        private void ПризывникForm_Load(object sender, EventArgs e)
        {
            org.ExecuteStoreCommand("update Prizivnik set Повестка = 0 ");
            if (DataModul.key == 1)
            {
                toolStripButton1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
            }

            Refreshh();
            ВоенкоматBindingSource.DataSource = org.Voenkomat.ToList();
            годностиBindingSource.DataSource = org.Годности.ToList();
            районBindingSource.DataSource = org.Район.ToList();
            отсрочкаBindingSource.DataSource = org.Отсрочка.ToList();
            Check();
           
        }

        public System.Data.Objects.ObjectQuery<Призывник> Screach()
        {
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    {
                        var query1 = org.Prizivnik.Where(p => p.Фамилия.Contains(toolStripTextBox1.Text));
                        return query1 as System.Data.Objects.ObjectQuery<Призывник>;
                    }
                case 1:
                    {
                        var query2 = org.Prizivnik.Where(p => p.Имя.Contains(toolStripTextBox1.Text));
                        return query2 as System.Data.Objects.ObjectQuery<Призывник>;
                    }
                case 2:
                    {
                        var query3 = org.Prizivnik.Where(p => p.Отчество.Contains(toolStripTextBox1.Text));
                        return query3 as System.Data.Objects.ObjectQuery<Призывник>;
                    }
                
                case 3:
                    {
                        var query5 = org.Prizivnik.Where(p => p.Дата_прибытия_в_военкомат.Value.Date.ToString().Contains(toolStripTextBox1.Text));
                        return query5 as System.Data.Objects.ObjectQuery<Призывник>;
                    }
                case 4:
                    {
                        var query6 = org.Prizivnik.Where(p => EntityFunctions.TruncateTime(p.Дата_последнего_изменения.Value) == Convert.ToDateTime(toolStripTextBox1.Text).Date);
                        return query6 as System.Data.Objects.ObjectQuery<Призывник>;
                        
                    }
                case 5:
                    {
                        var query6 = org.Prizivnik.Where(p => p.профессия.Contains(toolStripTextBox1.Text));
                        return query6 as System.Data.Objects.ObjectQuery<Призывник>;
                    }

                case 6:
                    {
                        var query6 = org.Prizivnik.Where(p => p.Фактический_адрес_телефон.Contains(toolStripTextBox1.Text));
                        return query6 as System.Data.Objects.ObjectQuery<Призывник>;
                    }
                case 7:
                    {
                        var query6 = org.Prizivnik.Where(p => p.Семейное_положение.Contains(toolStripTextBox1.Text));
                        return query6 as System.Data.Objects.ObjectQuery<Призывник>;
                    }

            }
            return null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Screach() == null) MessageBox.Show("Введите сроку для поиска");
            else
                ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(Screach().Execute(System.Data.Objects.MergeOption.AppendOnly));
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            org.Prizivnik.Context.ExecuteStoreCommand("DECLARE @MyCounter int; set @MyCounter=(select MAX([IDПризывника]) from Призывник);DBCC CHECKIDENT(Призывник,Reseed,@MyCounter)");
            AddID();
            Refreshh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index=(int.Parse(ПризывникDataGridView.CurrentRow.Cells["IDПризывникa"].Value.ToString()));
            Призывник delet = org.Prizivnik.Where(p => p.IDПризывника == index).First();
            org.Prizivnik.DeleteObject(delet);
            org.SaveChanges();
            Refreshh();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Refreshh();
        }

        private void ПризывникBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
            Check();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int index = int.Parse(ПризывникDataGridView.CurrentRow.Cells[0].Value.ToString());
            Обследование ob = new Обследование {IDПризывника=index};
            org.Обследование.AddObject(ob);
            org.Prizivnik.Where(p => p.IDПризывника == index).First().IDОтсрочки = 5;
            org.SaveChanges();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index=int.Parse(обследованиеDataGridView.CurrentRow.Cells[0].Value.ToString());
            Обследование remov = org.Обследование.Where(p => p.IDобследования == index).First();
            org.Обследование.DeleteObject(remov);
            org.SaveChanges();
            Refresh();
        }

        private void призывToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pj.ShowDialog();
        }

        private void отсрочкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oj.ShowDialog();
        }

        private void пПГВУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ppg.ShowDialog();
        }

        private void архивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select = true;
            ПризывникBindingSource.DataSource = new SortableBindingList<Призывник>(LoadContent().Execute(System.Data.Objects.MergeOption.AppendOnly));
        }

        private void обследованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = int.Parse(ПризывникDataGridView.CurrentRow.Cells[0].Value.ToString());
            Розыск ob = new Розыск { IDПризывника = index };
            org.Розыск.AddObject(ob);
            org.Prizivnik.Where(p => p.IDПризывника == index).First().IDОтсрочки = 4;
            org.SaveChanges();
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = int.Parse(розыскDataGridView.CurrentRow.Cells[0].Value.ToString());
            Розыск remov = org.Розыск.Where(p => p.IDРозыска == index).First();
            org.Розыск.DeleteObject(remov);
            org.SaveChanges();
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
        }

        private void розыскToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rz.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            org.SaveChanges();
            DataModul.org = org;
            print.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ПризывникDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите призывника");
            }
            else
            {
                par.index = int.Parse(ПризывникDataGridView.CurrentRow.Cells["IDПризывникa"].Value.ToString());
                par.ShowDialog();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AddID();
            Refreshh();
        }
    }
}
