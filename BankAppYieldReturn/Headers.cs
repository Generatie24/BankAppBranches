using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppYieldReturn
{
    public static class Headers
    {
        public static string DatumHeader { get; } = "Datum van transactie".PadRight(25);
        public static string BedragHeader { get; } = "Bedrag".PadLeft(25);
        public static string Spatie { get; } = "     ".PadRight(5);
        public static string OmschrijvingHeader { get; } = "Omschrijving".PadRight(25);
        public static string SaldoTekstHeader { get; } = "Saldo".PadRight(25);

        public static string ShowHeader()
        {
            return Headers.DatumHeader + Headers.BedragHeader + Headers.Spatie + Headers.OmschrijvingHeader + Headers.SaldoTekstHeader;
        }
        public static string ShowDetail(Transactie transactie, decimal saldo)
        {
            string datum= transactie.Datum.ToShortDateString().PadRight(25);
            string bedrag = transactie.Bedrag.ToString("C").PadLeft(25);
            string omschrijving = transactie.Omschrijving.PadRight(25);
            string saldoTekst = saldo.ToString("C").PadRight(25);
            return $"{datum}{bedrag}{"".PadRight(5)}{omschrijving}{saldoTekst}";
        }
        public static string ShowFooter(int length, decimal saldo)
        {
            return $"Total Saldo op { DateTime.Today.ToShortDateString()} {"".PadRight(length)} {saldo.ToString("C").PadRight(length)}";
        }
    }
}
