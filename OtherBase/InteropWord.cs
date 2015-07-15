using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace sourse
{
    class word
    {
        Object wordMissing = System.Reflection.Missing.Value;
        Object wordTrue = true;
        Object wordFalse = false;
        public Word.Table tables;

        //рабочие параметры
        // если использовать Word.Application и Word.Document получим предупреждение от компиллятора
        public Word._Application wordApplication;
        public Word._Document wordDocument;
        Object templatePathObj;

        // определяет поведение в случае ошибки при поиске и замене строки, по умолчанию открытый документ и приложенеи Word закрываются
        public bool CloseIFReplaceFailed = true;

        /// <summary>
        /// возвращает количество таблиц в документе
        /// </summary>
        /// <returns></returns>
        public int tableCount()
        {
            return wordDocument.Tables.Count;
        }


        public bool runMacros(string macros)
        {
            try
            {
                wordApplication.Run(macros);
                return true;
            }
            catch
            {
                MessageBox.Show(@"Ошибка  макроса");
                return false;
            }
        }

        // фиксированные параметры для передачи приложению Word

        public void copyToWord(ref word MainDoc, word secondDoc)
        {
            Word.Range wordrange = secondDoc.wordApplication.ActiveDocument.Range(
           secondDoc.wordApplication.ActiveDocument.Content.Start,
           secondDoc.wordApplication.ActiveDocument.Content.End);
            wordrange.Copy();
            Word.Range w = MainDoc.wordApplication.ActiveDocument.Range(
            MainDoc.wordApplication.ActiveDocument.Content.End - 1,
            MainDoc.wordApplication.ActiveDocument.Content.End);
            w.Paste();
        }

        public void GetFont(Font _font)
        {
            Word.Range w = wordApplication.ActiveDocument.Range(
        wordApplication.ActiveDocument.Content.Start,
        wordApplication.ActiveDocument.Content.End);
            w.Font.Name = _font.Name;
            w.Font.Size = _font.Size;
        }

        public bool Visible
        {
            get
            {
                if (documentClosed()) { throw new Exception("Ошибка при попытке изменить видимость Microsoft Word. Программа или документ уже закрыты."); }
                return wordApplication.Visible;

            }
            set
            {
                if (documentClosed()) {throw new Exception("Ошибка при попытке изменить видимость Microsoft Word. Программа или документ уже закрыты."); }
                wordApplication.Visible = value;
            }
            // завершение public bool Visible
        }

        // конструктор, создаем по шаблону, потом возможно расширение другими вариантами
        public word()
        {
            wordApplication = new Word.Application();


            //создаем ноый документ методом приложения Word по поути к шаблону документа
            try
            {
                  wordDocument = wordApplication.Documents.Add(ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing);
                  
            }
            // если произошла ошибка, то приложение Word надо закрыть
            catch (Exception error)
            {
                wordApplication.Quit(ref wordMissing, ref  wordMissing, ref wordMissing);
                wordApplication = null;
                throw new Exception("Ошибка. Не удалось открыть шаблон документа MS Word. " + error.Message);
            }
            // завершение createFromTemplate(string templatePath)
        }
        public word(string templatePath)
        {
            CreateFromTemplate(templatePath);
        }

        // создаем приложение Word и открывает новый документ по заданному файлу шаблона
        public void CreateFromTemplate(string templatePath)
        {
            //создаем обьект приложения word
           
                wordApplication = new Word.Application();
                wordApplication.Visible = false;
            

            // создаем путь к файлу используя имя файла
            templatePathObj = templatePath;

            //создаем ноый документ методом приложения Word по поути к шаблону документа
            try
            {
                wordDocument = wordApplication.Documents.Open(templatePath);
                //wordDocument = wordApplication.Documents.Add(ref templatePathObj,ref wordMissing, ref wordMissing, true);
            }
            // если произошла ошибка, то приложение Word надо закрыть
            catch (Exception error)
            {
                wordApplication.Quit(ref wordMissing, ref  wordMissing, ref wordMissing);
                wordApplication = null;
                throw new Exception("Ошибка. Не удалось открыть шаблон документа MS Word. " + error.Message);
            }
            // завершение createFromTemplate(string templatePath)
        }

        public void SaveAs(string filename)
        {
            wordDocument.SaveAs2(filename, wordMissing, wordMissing, wordMissing);
        }

        public bool GetTable(int count)
        {
            try
            {
                var table = wordDocument.Tables[count];
                tables = table;
                return true;
            }
            catch
            {
                MessageBox.Show(@"Не получилось выявить таблицу");
                return false;
            }

        }
        public string Seath(string findStr)
        {
            string res = " ";
            object missing;
            missing = Type.Missing;
            object findText = findStr;


            wordApplication.Selection.Find.ClearFormatting();

            if (wordApplication.Selection.Find.Execute(ref findText,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing))
            {
                //  MessageBox.Show("Text found.");
                wordApplication.Selection.Expand(Word.WdUnits.wdLine);


                res = wordApplication.Selection.Text.Remove(wordApplication.Selection.Text.Length - 1, 1);
            }

            return res;
        }

        // ПОИСК И ЗАМЕНА ЗАДАННОЙ СТРОКИ
        public void ReplaceString(string strToFind, string replaceStr, string replaceTypeStr)
        {
            if (documentClosed()) { throw new Exception("Ошибка при выполнении поиска и замены в Microsoft Word. Программа или документ уже закрыты."); }

            // обьектные строки для Word
            object strToFindObj = strToFind;
            object replaceStrObj = replaceStr;
            // диапазон документа Word
            Word.Range wordRange;
            //тип поиска и замены
            object replaceTypeObj;

            if (replaceTypeStr == "all")
            {
                // заменять все найденные вхождения
                replaceTypeObj = Word.WdReplace.wdReplaceAll;
            }
            else if (replaceTypeStr == "one")
            {
                // заменять только первое найденное вхождение
                replaceTypeObj = Word.WdReplace.wdReplaceOne;
            }
            else
            {
                Close();
                throw new Exception("Неизвестный тип поиска и замены в документе Word.");
            }

            try
            {
                // обходим все разделы документа
                for (int i = 1; i <= wordDocument.Sections.Count; i++)
                {
                    // берем всю секцию диапазоном
                    wordRange = wordDocument.Sections[i].Range;

                    // выполняем метод поискаи  замены обьекта диапазона ворд
                    wordRange.Find.Execute(ref strToFindObj, ref wordMissing, ref wordMissing, ref wordMissing,
                    ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref replaceStrObj,
                    ref replaceTypeObj, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing);
                }

            }
            catch (Exception error)
            {
                if (CloseIFReplaceFailed)
                {
                    this.Close();
                }
                throw new Exception("Ошибка при выполнении поиска и замены в документе Word.  " + error.Message);
            }
            // завершение функции поиска и замены SearchAndReplace
        }
        // тоже поиск и замена
        private void WordReplace(string old_str, string new_str)
        {
            foreach (Microsoft.Office.Interop.Word.Range tmpRange in wordDocument.StoryRanges)
            {
                // Set the text to find and replace
                tmpRange.Find.Text = old_str;
                tmpRange.Find.Replacement.Text = new_str;

                // Set the Find.Wrap property to continue (so it doesn't
                // prompt the user or stop when it hits the end of
                // the section)
                tmpRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;

                // Declare an object to pass as a parameter that sets
                // the Replace parameter to the "wdReplaceAll" enum
                object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                object missing = System.Type.Missing;
                // Execute the Find and Replace -- notice that the
                // 11th parameter is the "replaceAll" enum object
                tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref replaceAll,
                    ref missing, ref missing, ref missing, ref missing);
            }
        }


        // закрытие открытого документа и приложения
        public void Close()
        {
            if (documentClosed()) { throw new Exception("Ошибка при попытке закрыть Microsoft Word. Программа или документ уже закрыты."); }

            wordDocument.Close(ref wordFalse, ref  wordMissing, ref wordMissing);
            wordApplication.Quit(ref wordMissing, ref  wordMissing, ref wordMissing);
            wordDocument = null;
            wordApplication = null;
        }

        // если документ уже закрыт, true
        private bool documentClosed()
        {
            if (this.wordApplication == null || this.wordDocument == null) { return true; }
            else { return false; }
        }

        // завершение class WordDocument


    }


}
