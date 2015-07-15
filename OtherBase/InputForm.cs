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
    public partial class InputForm : Form
    {

        SpecialPom sp = new SpecialPom();
        ПризывникForm priziv = new ПризывникForm();
        PrizivJournal pj = new PrizivJournal();
        OtsrochJournal oj = new OtsrochJournal();
        PPGVUJournal ppg = new PPGVUJournal();
        ObsledovanieJournal obj = new ObsledovanieJournal();
        RoziskJournal rz = new RoziskJournal();
        OtchetRoziskTekst otsh = new OtchetRoziskTekst();
        FailedMissions fl = new FailedMissions();
        RoziskLForm roziskl = new RoziskLForm();
        RoziskNForm roziskn = new RoziskNForm();
        RoziskUForm rozisku = new RoziskUForm();
        PrizivnikFormOtsch p = new PrizivnikFormOtsch();
        HealthCategory h = new HealthCategory();
        District d = new District();

        public InputForm()
        {
            InitializeComponent();
        }

        private void организацийToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void призывникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            priziv.select = false;
            priziv.ShowDialog();
        }

        private void сотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void военкоматовToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void принадлежностиРайоновToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pj.ShowDialog();
        }

        private void районовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void обследованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oj.ShowDialog();
        }

        private void пПГВУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ppg.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            priziv.select = true;
            priziv.ShowDialog();
        }

        private void обследованийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.ShowDialog();
        }

        private void поОбследованиямToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void розыскToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rz.ShowDialog();
        }

        private void контроляToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void текстильщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otsh.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fl.ShowDialog();
        }

        private void южнопортовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rozisku.ShowDialog();
        }

        private void нижегородскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            roziskn.ShowDialog();
        }

        private void лефортовоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            roziskl.ShowDialog();
        }

        private void призывниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.ShowDialog();
        }

        private void районыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.ShowDialog();
        }

        private void категорииГодностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            h.ShowDialog();
        }

        private void специальныеПометкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sp.ShowDialog();
        }

        private void призывToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Otsroch ot = new Otsroch();
            ot.ShowDialog();
        }

        private void отчетПоВсемуПризывуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Othet ot = new Othet();
            ot.ShowDialog();
        }

        private void неГодныеАрхивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Obsledov ob = new Obsledov();
            ob.ShowDialog();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        

    }
}
