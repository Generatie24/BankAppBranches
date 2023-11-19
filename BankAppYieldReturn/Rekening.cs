using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppYieldReturn
{
    public class Rekening
    {
        public string Rekeningnummer { get; set; }
        public decimal Saldo { get; set; }
        private Transactie[] _transacties = new Transactie[100];

        private int i = 0; // aantal transacties
        public Rekening(string rekeningnummer)
        {
            Rekeningnummer = rekeningnummer;
        }
        public void VoerTransactieUit(decimal bedrag, string omschrijving)
        {
            _transacties[i] = new Transactie(bedrag, DateTime.Now, omschrijving);
            i++;

            Saldo += bedrag;
            
        }

        public void ToonTransacties()
        {
            int i = 0;
            int vasteLengte = 20;

            decimal[] saldoArray = BerekenSaldo();

            string datumHeader = "Datum van transactie".PadRight(vasteLengte);
            string bedragHeader = "Bedrag".PadLeft(vasteLengte);
            string spatie = "     ".PadLeft(5);
            string omschrijvingHeader = "Omschrijving".PadRight(vasteLengte);
            string saldoTekstHeader = "Saldo".PadLeft(vasteLengte);

            Console.WriteLine($"{datumHeader} {bedragHeader} {spatie} {omschrijvingHeader} {saldoTekstHeader}");

            foreach (decimal saldo in saldoArray)
            {
                if (i < _transacties.Length && _transacties[i] != null)
                {
                    Transactie transactie = _transacties[i];
                   
                    string datum = transactie.Datum.ToShortDateString().PadRight(vasteLengte);
                    string bedrag = transactie.Bedrag.ToString("C").PadLeft(vasteLengte);
                   

                    string omschrijving = transactie.Omschrijving.PadRight(vasteLengte);
                    string saldoTekst = saldo.ToString("C").PadLeft(vasteLengte);
                    Console.WriteLine($"{datum} {bedrag} {spatie} {omschrijving} {saldoTekst}");
                }
                else
                {
                    break;
                }

                i++;
            }
            
        }

        public decimal[] BerekenSaldo()
        {
            decimal[] saldoNaTransactie = new decimal[i];
            decimal Saldo = 0;
            int index = 0;

            foreach (var transactie in _transacties)
            {
                if (transactie == null || index >= i)
                {
                    break;
                }
                   
                Saldo += transactie.Bedrag;
                saldoNaTransactie[index++] = Saldo;
            }
           
            return saldoNaTransactie;
            
        }
    }
}
