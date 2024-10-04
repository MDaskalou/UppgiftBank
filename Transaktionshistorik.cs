

namespace SEBBank
{
    public class TransaktionHistorik
    {

        public DateTime förstaTransaktion { get; set; }

        public DateTime sistaTransaktion { get; set; }

        public TransaktionHistorik()
            {
            //initierar med nuvarande tid som standard
                 förstaTransaktion = DateTime.Now;
                sistaTransaktion = DateTime.Now;
            }
        public void UppdateraSistaTransaktionen()
        {
            sistaTransaktion = DateTime.Now;
        }

    }
}
