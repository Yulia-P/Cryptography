using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Lab05
{
    internal class RoutePerm
    {
        static char[] characters = new char[] {'a','ą','b','c','ć','d','e','ę','f','g','h','i','j','k',
                                               'l','ł','m','n','ń','o','ó','p','r','s','ś','t','u','w',
                                               'y','z','ź','ż'};
        static int N = characters.Length;
        int[] colFx1 = new int[N];
        int[] colFx2 = new int[N];

       
        public string Encrypt(string msg, int key)
        {
            ///кол-во вхождений
            for (int i = 0; i < N; i++)                                                        ///каждая буква алфавита провер. кол-во вхожд во фразе
            {
                colFx1[i] = msg.Where(el => el == characters[i]).Count();                    ///есть вхожд - вывод букву + кол-во
            }


            string result = string.Empty;
            string[] msgInArray = new string[(msg.Length / key) + 1];

            for (int i = 0; i < (msg.Length / key) + 1; i++)
            {
                if (msg.Length - i * key <= key)
                {
                    msgInArray[i] = msg.Substring(i * key);
                    Console.WriteLine("msgInArray[" + i + "] = " + msgInArray[i]);
                    break;
                }
                else
                {
                    msgInArray[i] = msg.Substring(i * key, key);
                    Console.WriteLine("msgInArray[" + i + "] = " + msgInArray[i]);
                }
            }

           for (int i = 0; i < key; i++)
            {
                for (int k = 0; k < msgInArray.Length - 1; k++)
                {
                    if (msgInArray[k].Length <= i) continue;
                    result += msgInArray[k].Substring(i, 1);
                }
            }

            return result;
        }

        public string Decrypt(string msg, int key)
        {
            string result = string.Empty;
            string[] msgInArray = new string[(msg.Length / key) + 1];

            for (int i = 0; i < (msg.Length / key) + 1; i++)
            {
                if (msg.Length - i * key <= key)
                {
                    msgInArray[i] = msg.Substring(i * key);
                    break;
                }
                else
                {
                    msgInArray[i] = msg.Substring(i * key, key);
                }
            }

            for (int i = 0; i < key; i++)
            {
                for (int k = 0; k < msgInArray.Length - 1; k++)
                {
                    if (msgInArray[k].Length <= i) continue;
                    result += msgInArray[k].Substring(i, 1);
                }
            }

            return result;
        }

        public void BuildExcel()
        {
            Excel.Application Excel1 = new Excel.Application();  ///объяв объект
            Excel1.Workbooks.Add();                         ///доб. рабочую книгу

            Excel1.ActiveSheet.Range["A1"].Value = "Исходный символ:";
            Excel1.ActiveSheet.Range["B1"].Value = "Частота:";

            int Yach = 2;
            for (int i = 0; i < colFx1.Length; i++)
            {
                if (colFx1[i] != 0)
                {
                    Excel1.ActiveSheet.Range["A" + Yach].Value = $"{characters[i]}";
                    Excel1.ActiveSheet.Range["B" + Yach].Value = Convert.ToInt32(colFx1[i]);
                    Yach++;
                }
            }
            Excel1.Charts.Add();   ///доб. новую диаграмму
            Excel1.ActiveChart.ChartType = Excel.XlChartType.xlColumnClustered;///столбчатая

            //подписи по оси X
            Excel1.ActiveChart.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
            Excel1.ActiveChart.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = "Частота появления";

            //подписи по оси Y
            Excel1.ActiveChart.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
            Excel1.ActiveChart.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = "Исходные символы Виженера";

            Excel1.Visible = true;
        }
    }
}
