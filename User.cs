

namespace SEBBank
{
    public class User
    {
        public string Namn { get; set; }

        public string Email { get; set; }

        public PersonKonto personKonto;

        public Sparkonto sparKonto;

        public Investeringskonto investeringsKonto;

        public User(string namn, string email )
        {
            Namn = namn;
            Email = email;

            personKonto = new PersonKonto(1001,namn);
           // TransaktionHistorik transaktionHistorik = new TransaktionHistorik();
            //personKonto.transaktionHistorik = transaktionHistorik;

            sparKonto = new Sparkonto(1002, namn);
            //sparKonto.transaktionHistorik = transaktionHistorik;

            investeringsKonto = new Investeringskonto(1003,namn);
            //investeringsKonto.transaktionHistorik = transaktionHistorik;


        }


    }
}
