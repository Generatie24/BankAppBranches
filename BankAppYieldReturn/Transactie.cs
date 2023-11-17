using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppYieldReturn
{
    public class Transactie
    {
        public decimal Bedrag { get; set; }
        public DateTime Datum { get; set; }
        public string Omschrijving { get; set; }
        public Transactie(decimal bedrag, DateTime datum, string omschrijving)
        {
            Bedrag = bedrag;
            Datum = datum;
            Omschrijving = omschrijving;
        }
    }
}
