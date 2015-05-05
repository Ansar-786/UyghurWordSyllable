using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoghumParchilash
{

        public class Syllable2
        {
            public string[] getSyllable(string Word)
            {
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
                int key = 0;
                string str = Word;
                string str2 = Word;
                int length = Word.Length;
                if ((length > 0x31) || (length < 2))
                {
                    dictionary2.Clear();
                }
                for (int i = 0; i <= (length - 1); i++)
                {
                    char chr = str.Substring(0, 1).ToCharArray()[0];
                    str = Word.Substring(i + 1, length - (i + 1));
                    if (this.isVowel(chr))
                    {
                        key++;
                        dictionary.Add(key, i);
                        if (key > 1)
                        {
                            switch ((dictionary[key] - dictionary[key - 1]))
                            {
                                case 2:
                                    dictionary2.Add(key - 1, str2.Substring(0, 2));
                                    str2 = str2.Substring(2, str2.Length - dictionary2[key - 1].Length);
                                    break;

                                case 3:
                                    dictionary2.Add(key - 1, str2.Substring(0, 3));
                                    str2 = str2.Substring(3, str2.Length - dictionary2[key - 1].Length);
                                    break;

                                case 4:
                                    dictionary2.Add(key - 1, str2.Substring(0, 4));
                                    str2 = str2.Substring(4, str2.Length - dictionary2[key - 1].Length);
                                    break;
                                case 5:
                                    dictionary2.Add(key - 1, str2.Substring(0, 5));
                                    str2 = str2.Substring(5, str2.Length - dictionary2[key - 1].Length);
                                    break;
                            }
                        }
                    }
                }
                dictionary2.Add(key, str2);
                if (!(((key != 1) || this.isOneSyllable(Word)) && this.isOneSyllable(str2)))
                {
                    dictionary2.Clear();
                }
                string[] strArray = new string[dictionary2.Count];
                for (int j = 1; j < (dictionary2.Count + 1); j++)
                {
                    try
                    {
                        strArray[j - 1] = dictionary2[j];
                    }
                    catch (Exception)
                    {
                    }
                }
                return strArray;
            }

            private bool isConsonant(char chr)
            {
                int num = chr;
                if ((((((num != 0x67e) && (num != 0x62a)) && ((num != 0x686) && (num != 0x62e))) && (((num != 0x633) && (num != 0x634)) && ((num != 0x641) && (num != 0x642)))) && ((((num != 0x643) && (num != 0x6be)) && ((num != 0x628) && (num != 0x62f))) && (((num != 0x631) && (num != 0x632)) && ((num != 0x698) && (num != 0x62c))))) && ((((num != 0x63a) && (num != 0x6af)) && ((num != 0x6ad) && (num != 0x644))) && (((num != 0x645) && (num != 0x646)) && ((num != 0x6cb) && (num != 0x64a)))))
                {
                    return false;
                }
                return true;
            }

            private bool isOneSyllable(string Word)
            {
                string str = Word;
                int length = Word.Length;
                if ((length > 4) || (length < 2))
                {
                    return false;
                }
                for (int i = 1; i <= length; i++)
                {
                    char chr = str.Substring(0, 1).ToCharArray()[0];
                    str = str.Substring(1, str.Length - 1);
                    if ((i == 2) && this.isConsonant(chr))
                    {
                        return false;
                    }
                    if ((i != 2) && this.isVowel(chr))
                    {
                        return false;
                    }
                }
                return true;
            }

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


