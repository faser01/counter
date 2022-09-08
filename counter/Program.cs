using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Counter
{
    class Num
    {
        private long[] _num = new long[7];
        private long count = 0;
        private long[] CreateNum()
        {
            for (int i = 0; i < _num.Length; i++)
            {
                _num[i] = count + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                count++;
            }
            return _num;
        }
        private string[] Convert()
        {
            _num = CreateNum();
            string[] ArrToStr = new string[_num.Length];
            for (int i = 0; i < _num.Length; i++)
            {
                ArrToStr[i] = _num[i].ToString();
            }
            return ArrToStr;
        }
        private void WriteFile()
        {
            string[] number = Convert();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Log.txt";
            for (int i = 0; i < number.Length; i++)
            {
                File.AppendAllText(path, number[i] + "\n");
            }

        }
        public void PrintNum()
        {
            WriteFile();
            _num = CreateNum();
            for (int i = 0; i < _num.Length; i++)
                Console.WriteLine("Число "+_num[i]);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Num _number = new Num();
            _number.PrintNum();
        }
    }
}