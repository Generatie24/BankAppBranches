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

            int transactieIndex = 0;

            foreach (var saldo in rekening.GenereerSaldo())
            {
                if (transactieIndex < rekening.Transacties.Length && rekening.Transacties[transactieIndex] != null)
                {
                    var transactie = rekening.Transacties[transactieIndex];

                    string datum = transactie.Datum.ToShortDateString().PadRight(vasteLengte); // Gebruik ToShortDateString() voor een kortere datum
                    string bedrag = transactie.Bedrag.ToString("C").PadLeft(vasteLengte); // "C" voor valutaformattering
                    string omschrijving = transactie.Omschrijving.PadRight(vasteLengte);
                    string saldomschrijving = "Saldo na transactie:".PadRight(vasteLengte);
                    string saldoTekst = saldo.ToString("C").PadLeft(vasteLengte); // "C" voor valutaformattering


                    Console.WriteLine($"{datum} {bedrag} {omschrijving} {saldoTekst} {saldomschrijving} {saldo}");
                    //Console.WriteLine($"{transactie.Datum} {transactie.Bedrag} {transactie.Omschrijving} Saldo na transactie:..... {saldo}");

                }
                else
                {
                    break;
                }

                transactieIndex++;
            }

        }
    }
}
