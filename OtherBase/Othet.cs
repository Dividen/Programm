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
    public partial class Othet : Form
    {
        OrgSQLEntities2 content = new OrgSQLEntities2();

        public Othet()
        {
            InitializeComponent();
        }

        public int SelectOt(int chal)
        {
            var query = from n in content.Prizivnik
                        where (n.IDГодности == chal)
                        select n;
            return query.Count();

        }
        private void Othet_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Отчет по всему призыву");
            listBox1.Items.Add("Есть отсрочка="+SelectOt(1));
            listBox1.Items.Add("Находятся В розыске=" + SelectOt(4));
            listBox1.Items.Add("На Призыв=" + SelectOt(2));
            listBox1.Items.Add("Списано=" + SelectOt(9));
            listBox1.Items.Add("На обследовании=" + SelectOt(9));

        }
    }
}
