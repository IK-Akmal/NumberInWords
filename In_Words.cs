using System;
using System.Windows.Forms;

namespace Number_In_Words
{


    class In_Words
    {
        private readonly string[,] Arr_1 = { { "","один","два","три","четыре","пять","шесть","семь","восемь","девять"},
                                                  {"","одна","две","три","четыре","пять","шесть","семь","восемь","девять"}};

        private readonly string[] Arr_2 = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };

        private readonly string[] Arr_3 = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };

        private readonly string[] Arr_4 = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };

        private readonly string[,] Arr_5 =
        {
       {"","",""},
       {"тысяча","тысячи","тысяч"},
       {"миллион","миллиона","миллионов"},
       {"миллиард","милиарда","миллиардов"},
       {"триллион","триллиона","триллионов"},
       {"квадриллион","квадриллиона","квадриллионов"},
       {"квинтиллион","квинтиллиона","квинтиллионов"},
       {"секстиллион","секстиллиона","секстиллионов"},
       {"септиллион","септиллиона","септиллионов"},
       {"октиллион","октиллиона","октиллионов"},
       {"нониллион","нониллиона","нониллионов"},
       {"дециллион","дециллиона","дециллионов"},
       {"ундециллион","ундециллиона","ундециллионов"},
       {"дуодециллион","дуодециллиона","дуодециллионов"},
       {"тредециллион","тредециллиона","тредециллионов"},
       {"кваттуордециллион","кваттуордециллиона","кваттуордециллионов"}
    };
        private ushort Key = 0;
        private string Text;
        private ushort _Temp;
        private enum Type
        {
            Masculine,
            Feminine,
        }
        public string Begin(string Temp)
        {
            try
            {
                if (string.IsNullOrEmpty(Temp) || Temp == "0")
                    return "ноль";
                for (; !string.IsNullOrEmpty(Temp); Temp = Temp.Remove(Temp.Length > 3 ? Temp.Length - 3 : 0, Temp.Length < 3 ? Temp.Length : 3))
                {
                    _Temp = Convert.ToUInt16(Temp.Substring(Temp.Length > 3 ? Temp.Length - 3 : 0));
                    switch (Key)
                    {
                        case 0:
                            For_hundred_digit_numbers(_Temp);
                            break;
                        case 1:
                            Processing(_Temp, Key, In_Words.Type.Feminine);
                            break;
                        default:
                            Processing(_Temp, Key, In_Words.Type.Masculine);
                            break;
                    }
                    ++Key;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Text;
        }

        private void Processing(int x, int keys, In_Words.Type type)
        {
            string str = string.Empty;
            if (x / 100 > 0)
            {
                str = str + Arr_4[x / 100] + " ";
                if (x % 100 == 0)
                    str = str + Arr_5[keys, 2] + " ";
            }
            x %= 100;
            if (x < 20 && x > 9)
            {
                Text = str + Arr_2[x % 10] + " " + Arr_5[keys, 2] + " " + Text;
            }
            else
            {
                if (x > 19 && x < 100)
                {
                    str = str + Arr_3[(x - x % 10) / 10] + " ";
                    if (x % 10 == 0)
                        str = str + Arr_5[keys, 2] + " ";
                }
                x %= 10;
                switch (x)
                {
                    case 0:
                        Text = str + Text;
                        break;
                    case 1:
                        str = str + Arr_1[(int)type, x] + " " + Arr_5[keys, 0] + " ";
                        goto case 0;
                    case 2:
                    case 3:
                    case 4:
                        str = str + Arr_1[(int)type, x] + " " + Arr_5[keys, 1] + " ";
                        goto case 0;
                    default:
                        str = str + Arr_1[(int)type, x] + " " + Arr_5[keys, 2] + " ";
                        goto case 0;
                }
            }
        }

        private void For_hundred_digit_numbers(int x)
        {
            string str = string.Empty;
            if (x / 100 > 0)
                str = str + Arr_4[x / 100] + " ";
            x %= 100;
            if (x < 20 && x > 9)
            {
                Text = str + Arr_2[x % 10] + " " + Text;
            }
            else
            {
                if (x > 19 && x < 100)
                    str = str + Arr_3[(x - x % 10) / 10] + " ";
                x %= 10;
                if (x > 0 && x < 10)
                    str = str + Arr_1[0, x] + " ";
                Text = str + Text;
            }
        }
       

    }
}


