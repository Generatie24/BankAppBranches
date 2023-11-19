using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppYieldReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Rekening rekening = new Rekening("123-456789-01");

            rekening.VoerTransactieUit(5000.00m, "Storting");
            rekening.VoerTransactieUit(-300.00m, "Geld opname");
            rekening.VoerTransactieUit(-500.00m, "Geld opname");
            rekening.VoerTransactieUit(500.00m, "Storting");
            rekening.VoerTransactieUit(-600.00m, "Geld opname");

            rekening.ToonTransacties();

        }
    }
}
