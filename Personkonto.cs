

namespace SEBBank
{
    public class PersonKonto : Bank
    {
        //TransaktionHistorik Nemo = new TransaktionHistorik() {förstaTransaktion = DateTime.Now, sistaTransaktion = DateTime.Now };
        
        public PersonKonto(int kontoNummer, string kontoInnehavare) : base (kontoNummer, kontoInnehavare, 5000,Nemo ) 
        {
        }



       /public TransaktionHistorik transaktionHistorik;
    }
    public class Sparkonto : Bank
    {
        public Sparkonto(int kontoNummer, string kontoInnehavare) : base(kontoNummer, kontoInnehavare, 20000) // Startsaldo 20000 kr
        {
        }

        public TransaktionHistorik transaktionHistorik;

    }
    public class Investeringskonto : Bank
    {
        public Investeringskonto(int kontoNummer, string kontoInnehavare) : base(kontoNummer, kontoInnehavare, 10000) // Startsaldo 10000 kr
        {
        }

        public TransaktionHistorik transaktionHistorik;

    }


}
