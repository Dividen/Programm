using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word=Microsoft.Office.Interop.Word;
using W=sourse;
using System.IO;

namespace OtherBase
{
    public partial class Selection : Form
    {

        // WordWriter word = new WordWriter();

        public Selection()
        {

            InitializeComponent();
        }


        public void Print_Click(object sender, EventArgs e)
        {
            

            switch (SelectDoc.SelectedIndex)
            {
                case 0:
                    {
                        PrintZapr2(Application.StartupPath + @"\printer\Doc1.docx");
                    }
                    break;
              
                 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string name = Application.StartupPath + @"\documents\Doc1.docx";

        public void PrintZapr2(string pathname)
        {

            int count = 0;
            OrgSQLEntities2 otherorg = DataModul.org;
            Object wordMissing = System.Reflection.Missing.Value;


            var query = from bd in otherorg.Prizivnik
                        where (bd.Повестка == true)
                        select bd;

            if (query == null) MessageBox.Show("Не выбран ни один призывник");
            else
            {

                foreach (Призывник or in query)
                {
                    W.word Word = new W.word(pathname);

                    Word.ReplaceString("FIO", or.Фамилия +" "+ or.Имя +" " + or.Отчество, "all");
                    Word.ReplaceString("UrAdress", or.Домашний_адрес__телефон, "all");

                    if (count == 0)
                    {
                        Word.SaveAs(name);
                        Word.Close();
                        count++;
                    }
                    else if (count == 1)
                    {
                        W.word Word2 = new W.word(name);
                        Word2.copyToWord(ref Word2, Word);
                        Word2.SaveAs(name);
                        Word.wordApplication.NormalTemplate.Saved = true;
                        Word.Close();
                        Word2.wordApplication.NormalTemplate.Saved = true;
                        Word2.Close();
                    }
                }
                System.Diagnostics.Process.Start(name);
            }

        }

        private void Selection_Load(object sender, EventArgs e)
        {

        }
        }
    }


