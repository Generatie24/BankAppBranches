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
            decimal[] saldoNaTransactie = new decimal[i];
            decimal Saldo = 0;
            int index = 0;

            foreach (var transactie in _transacties)
            {
                if (transactie == null || index >= i)
                    break;

                Saldo += transactie.Bedrag;
                saldoNaTransactie[index++] = Saldo;
            }

            return saldoNaTransactie;
        }


    }
}
