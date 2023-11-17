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
        public Transactie[] Transacties
        {
            get { return _transacties; }
        }


        private int _aantalTransacties = 0;
        public Rekening(string rekeningnummer)
        {
            Rekeningnummer = rekeningnummer;
        }
        public void VoerTransactieUit(decimal bedrag, string omschrijving)
        {
            _transacties[_aantalTransacties] = new Transactie(bedrag, DateTime.Now, omschrijving);
            _aantalTransacties++;

            Saldo += bedrag;
        }


        //public void ToonTransacties()
        //{
        //    foreach (Transactie item in _transacties)
        //    {
        //        if (item == null)
        //            break;
        //        Console.WriteLine($"{item.Datum} {item.Bedrag} {item.Omschrijving} Saldo:{Saldo}");
        //    }
        //}


        public decimal[] GenereerSaldo()
        {
            decimal[] saldoNaElkeTransactie = new decimal[_aantalTransacties];
            decimal lopendSaldo = 0;
            int index = 0;

            foreach (var transactie in _transacties)
            {
                if (transactie == null || index >= _aantalTransacties)
                    break;

                lopendSaldo += transactie.Bedrag;
                saldoNaElkeTransactie[index++] = lopendSaldo;
            }

            return saldoNaElkeTransactie;
        }


    }
}
