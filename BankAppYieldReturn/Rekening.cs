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
            Console.WriteLine("Zonder Yield");

            decimal[] saldoArray = BerekenSaldo();

            
            Console.WriteLine(Headers.ShowHeader());
            foreach (decimal saldo in saldoArray)
            {
                if (i < _transacties.Length && _transacties[i] != null)
                {
                    Transactie transactie = _transacties[i];
                   
                    string datum = transactie.Datum.ToShortDateString().PadRight(vasteLengte);
                    string bedrag = transactie.Bedrag.ToString("C").PadLeft(vasteLengte);
                   
                    string omschrijving = transactie.Omschrijving.PadRight(vasteLengte);
                    string saldoTekst = saldo.ToString("C").PadLeft(vasteLengte);

                    Console.WriteLine($"{datum} {bedrag} {"".PadLeft(5)} {omschrijving} {saldoTekst}");
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
