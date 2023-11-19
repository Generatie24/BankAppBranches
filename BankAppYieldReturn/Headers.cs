using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppYieldReturn
{
    public static class Headers
    {
        public static string DatumHeader { get; } = "Datum van transactie".PadRight(20);
        public static string BedragHeader { get; } = "Bedrag".PadLeft(20);
        public static string Spatie { get; } = "     ".PadLeft(5);
        public static string OmschrijvingHeader { get; } = "Omschrijving".PadRight(20);
        public static string SaldoTekstHeader { get; } = "Saldo".PadLeft(20);

        public static string ShowHeadre()
        {
            return Headers.DatumHeader + Headers.BedragHeader + Headers.Spatie + Headers.OmschrijvingHeader + Headers.SaldoTekstHeader;
        }

    }
}
