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

            int vasteLengte = 20;

            Rekening rekening = new Rekening("123-456789-01");

            rekening.VoerTransactieUit(5000.00m, "Storting");
            rekening.VoerTransactieUit(-300.00m, "Geld opname");
            rekening.VoerTransactieUit(-500.00m, "Geld opname");
            rekening.VoerTransactieUit(500.00m, "Storting");
            rekening.VoerTransactieUit(-600.00m, "Geld opname");

            int i = 0;

            var saldoArray = rekening.GenereerSaldo();
            foreach (decimal saldo in saldoArray)
            {
                if (i < rekening.Transacties.Length && rekening.Transacties[i] != null)
                {
                    Transactie transactie = rekening.Transacties[i];

                    string datum = transactie.Datum.ToShortDateString().PadRight(vasteLengte); 
                    string bedrag = transactie.Bedrag.ToString("C").PadLeft(vasteLengte);
                    string omschrijving = transactie.Omschrijving.PadRight(vasteLengte);
                    string saldomschrijving = "Saldo na transactie:".PadRight(vasteLengte);
                    string saldoTekst = saldo.ToString("C").PadLeft(vasteLengte);
                    Console.WriteLine($"{datum} {bedrag} {omschrijving} {saldomschrijving} {saldoTekst}");
                }
                else
                {
                    break;
                }

                i++;
            }

        }
    }
}
