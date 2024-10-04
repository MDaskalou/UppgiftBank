using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBBank
{       //Basklass
    public class Bank
    {

        public int kontoNummer;
        protected string kontoInnehavare;
        protected int saldo;
         public TransaktionHistorik transaktionHistorik {  get; set; }

        //Konstruktor

        public Bank(int kontoNummer, string kontoInnehavare, int startSaldo, TransaktionHistorik TransaktionHistorik) 
        {
            this.kontoNummer = kontoNummer;
            this.kontoInnehavare = kontoInnehavare;
            this.saldo = startSaldo;
            transaktionHistorik = TransaktionHistorik;

        }

        public void Deposition(int summa)
        {
            if (summa > 0)
            {
                saldo += summa;
                Console.WriteLine($"Du har satt in {summa} kr på ditt konto. Nya saldot är {saldo} kr");
                transaktionHistorik.UppdateraSistaTransaktionen();
            }
            else
            {
                Console.WriteLine(" Du kan inte sätta in 0kr eller mindre");
            }
        }

        public bool TaUtPengar(int summa)
        {
            if (summa > 0 && summa <= saldo)
            {
                saldo -= summa;
                Console.WriteLine($"Du har tagit ut {summa} kr från ditt konto. Nya saldot är: {saldo} kr");
                return true;
                transaktionHistorik.UppdateraSistaTransaktionen();

            }
            else
            {
                Console.WriteLine("Ogiltigt belopp eller inte tillräckligt med saldo.");
                return false;
            }
        }

        public void SkrivUtSaldo()
        {
            Console.WriteLine($"Kontonummer: {kontoNummer}, Saldo för {kontoInnehavare}: {saldo} kr");
            transaktionHistorik.UppdateraSistaTransaktionen();

        }






    }
       
   
}
