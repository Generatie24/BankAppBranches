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
            Console.WriteLine("Zonder Yield");

            decimal[] saldoArray = BerekenSaldo();
            decimal total = 0;

            Console.WriteLine(Headers.ShowHeader());

            foreach (decimal saldo in saldoArray)
            {
                if (i < _transacties.Length && _transacties[i] != null)
                {
                    Transactie transactie = _transacties[i];
                    var showdetail = Headers.ShowDetail(transactie, saldo);

                    Console.WriteLine(showdetail);
                    total = saldo;
                }
                else
                {
                    break;
                }

                i++;
            }
            Console.WriteLine();

            Console.WriteLine(Headers.ShowFooter(53, total));
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
