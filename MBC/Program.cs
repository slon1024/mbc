using System;
using System.Text;
using MBC.UInteger;

namespace MBC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var first = GetFirstNumber();
            var second = GetSecondNumber();

            Console.WriteLine((first * second).ToString());
            Console.ReadKey();
        }

        private static MbcUInteger GetFirstNumber()
        {
            const string partNumber = "01293749834982023";
            var number = new StringBuilder();
            number.Append("1")
                .Append(partNumber)
                .Append(partNumber)
                .Append(partNumber)
                .Append(number.ToString())
                .Append(number.ToString())
                .Append(number.ToString())
                .Append(number.ToString())
                .Append(number.ToString())
                ;

            return new MbcUInteger(number.ToString());
        }

        private static MbcUInteger GetSecondNumber()
        {
            return new MbcUInteger("3434343434");
        }
    }
}