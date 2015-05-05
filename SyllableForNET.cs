using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Imla_Lughet
{
    /// <summary>
    /// ئۇيغۇرچە بوغۇم ئايرىش
    /// <para>تۈزگۈچى:ئابلىمىت قۇربان، ئەلى ئەركىن</para>
    /// </summary>
    public class Syllable
    {

        public Syllable()
        {
            
        }
     
        /// <summary>
        /// بوغۇم ئايرىش
        /// </summary>
        /// <param name="Word"> ئۇيغۇرچە سۆز</param>
        /// <returns></returns>
        public string[] getSyllable(string Word)
        {
            Dictionary<int, int> dicVowelPosition = new Dictionary<int, int>();//سۇزۇق تاۋۇشنىڭ ئورۇنلىرى
            Dictionary<int, string> dicSyllables = new Dictionary<int, string>();//ئايرىۋالغان بۇغۇمنى ساقلايدۇ
            Dictionary<int, int> dicConsCount = new Dictionary<int, int>();//

            int nPositionIndex = 0;
            string tems = Word;
            string temso = Word;//پارچىلىنىش جەريانىدا سۆزنىڭ پارچىلىنىپ بولمىغان قىسمى
            int nWordLength = Word.Length;
            if ((nWordLength > 0x31) || (nWordLength < 2))
            {
                dicSyllables.Clear();
            }
            Boolean blnComVowel = false;//قوشما سوزۇق تاۋۇشمۇ
            Boolean blnFChCons = false;//ئالدىنقى ھەرپنىڭ ئۈزۈك تاۋۇش ياكى ئەمەسلىكىنى ساقلايدۇ
            int iConsCount = 0;

            for (int i = 0; i <= (nWordLength - 1); i++)
            {
                char chrOne = tems.Substring(0, 1).ToCharArray()[0];
                tems = Word.Substring(i + 1, nWordLength - (i + 1));
                MessageBox.Show(tems);
                if (isVowel(chrOne) && !blnComVowel)//سوزۇق تاۋۇشمۇ ياق؟
                {
                    blnComVowel = true;
                    nPositionIndex++;
                    dicVowelPosition.Add(nPositionIndex, i);
                    dicConsCount.Add(nPositionIndex, iConsCount);
                    blnFChCons = false;
                    iConsCount = 0;
                    if (nPositionIndex > 1)
                    {
                        int iDistance = dicVowelPosition[nPositionIndex] - dicVowelPosition[nPositionIndex - 1];//ئىككى سوزۇق تاۋۇشنىڭ ئارلىقىنى ھىساپلايدۇ
                        if (iDistance > 0 && iDistance < 5)
                        {
                            dicSyllables.Add(nPositionIndex - 1, temso.Substring(0, iDistance + dicConsCount[nPositionIndex - 1] - 1));
                            temso = temso.Substring(iDistance + dicConsCount[nPositionIndex - 1] - 1, temso.Length - dicSyllables[nPositionIndex - 1].Length);
                            dicConsCount[nPositionIndex] = dicConsCount[nPositionIndex] - (iDistance - 2);
                        }
                        else
                        {
                            dicSyllables.Add(nPositionIndex - 1, temso.Substring(0, iDistance + dicConsCount[nPositionIndex - 1] - 2));
                            temso = temso.Substring(iDistance + dicConsCount[nPositionIndex - 1] - 2, temso.Length - dicSyllables[nPositionIndex - 1].Length);
                            dicConsCount[nPositionIndex] = dicConsCount[nPositionIndex] - (iDistance - 3);
                        }
                    }
                }
                else//سوزۇق تاۋۇش ئەمەس
                {
                    if (blnFChCons)
                    {
                        iConsCount++;
                    }
                    else
                    {
                        iConsCount = 1;
                    }
                    blnFChCons = true;
                    blnComVowel = false;
                }
            }
            dicSyllables.Add(nPositionIndex, temso);//end
            
            string[] straRet = new string[dicSyllables.Count];
            for (int nCount = 1; nCount < dicSyllables.Count + 1; nCount++)
            {
                straRet[nCount - 1] = dicSyllables[nCount];
            }
            return straRet;
        }

      
             /// <summary>
        /// سۇزۇق تاۋۇشمۇ؟
        /// </summary>
        /// <param name="chr">بىر ھەرىپ</param>
        /// <returns>راست يالغان تىپ</returns>
        private bool isVowel(char chr)
        {
            if ((((chr != 0x627) && (chr != 0x648)) && ((chr != 0x649) && (chr != 0x6d0))) && (((chr != 0x6d5) && (chr != 0x6c6)) && ((chr != 0x6c7) && (chr != 0x6c8))))
            {
                return false;
            }
            return true;
        }

    
           
    }
}
