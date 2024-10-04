

namespace SEBBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool giltigtVal = false;

            while (!giltigtVal)
            {

                Console.WriteLine("Välkommen till SEB!");
                Console.WriteLine("Nedanför har du tre alternativ, välj en av dem");
                Console.WriteLine("1: Personkonto");
                Console.WriteLine("2: Sparkonto");
                Console.WriteLine("3: Invensteringskonto");
                Console.WriteLine("4: Överför pengar mellan konton");


                string userInput = Console.ReadLine();
                int userChoice = Convert.ToInt32(userInput);
                User newUser = new User("Mikael Daskalou", "mikael.daskalou@hotmail.com");
                Console.WriteLine(newUser.personKonto.kontoNummer);

                

                newUser.personKonto.transaktionHistorik.förstaTransaktion = DateTime.Now;
                newUser.personKonto.transaktionHistorik.sistaTransaktion = DateTime.Now;

                newUser.sparKonto.transaktionHistorik.förstaTransaktion = DateTime.Now;


                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Du har valt Personkonto");
                        newUser.personKonto.SkrivUtSaldo(); //visar saldo

                        Hanteratransaktion(newUser.personKonto);  // Fråga om insättning eller uttag


                        break;
                    case 2:
                        Console.WriteLine("Du har valt Sparkonto");
                        newUser.sparKonto.SkrivUtSaldo();

                        Hanteratransaktion(newUser.sparKonto);


                        break;
                    case 3:
                        Console.WriteLine("Du har valt invensteringskonto");
                        newUser.investeringsKonto.SkrivUtSaldo();

                        Hanteratransaktion(newUser.investeringsKonto);

                        break;

                    case 4: // Överför pengar mellan konton
                        HanteraÖverföring(newUser);
                        break;
                    default:
                        Console.WriteLine(" Du har inte valt något av följande, testa igen");
                        break;

                }
            }

            
        }
        static void Hanteratransaktion(Bank konto)
        {

            bool giltigtransaktion = false;

            while(!giltigtransaktion) 
            {

            Console.WriteLine("Vill du sätta in (1) eller ta ut (2) pengar?");
            string väljTransaktion = Console.ReadLine();

            if (väljTransaktion == "1") // Insättning
            {
                Console.WriteLine("Hur mycket vill du sätta in?");
                int placeraInSumma = Convert.ToInt32(Console.ReadLine());
                konto.Deposition(placeraInSumma); // Sätt in pengar
                konto.SkrivUtSaldo(); // Visa uppdaterat saldo
            }
            else if (väljTransaktion == "2") // Uttag
            {
                Console.WriteLine("Hur mycket vill du ta ut?");
                int utMedPengar = Convert.ToInt32(Console.ReadLine());
                konto.TaUtPengar(utMedPengar); // Ta ut pengar
                konto.SkrivUtSaldo(); // Visa uppdaterat saldo
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }


            }
        }

        static void HanteraÖverföring(User user)
        {
            bool giltigÖverföring = false;

            while(!giltigÖverföring)
            {

            
            Console.WriteLine("Vilket konto vill du överföra från?");
            Console.WriteLine("1: Peronkonto");
            Console.WriteLine("2: Sparkonto");
            Console.WriteLine("3: Invensteringskonto");

            int frånkonto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Vilket konto vill du överföra till?");
            Console.WriteLine("1: Peronkonto");
            Console.WriteLine("2: Sparkonto");
            Console.WriteLine("3: Invensteringskonto");

            int tillkonto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur mycket vill du överföra?");

            int summa = Convert.ToInt32(Console.ReadLine());

            // Kontrollera vilket konto som överföringen sker från och till


            Bank frånKonto = null;
            Bank tillKonto = null;

            //Skapa swish sats för rätt konto på användarens val 

            switch (frånkonto)
            {
                case 1:
                    frånKonto = user.personKonto;
                    break;
                case 2:
                    frånKonto = user.sparKonto;
                    break;
                case 3:
                    frånKonto = user.investeringsKonto;
                    break;
                default:
                    Console.WriteLine("Ogiltigt alternativ, välj något annat");
                    break;
            }
            switch (tillkonto)
            {
                case 1:
                    tillKonto = user.personKonto;
                    break;
                case 2:
                    tillKonto = user.sparKonto;
                    break;
                case 3:
                    tillKonto = user.investeringsKonto;
                    break;
                default :
                    Console.WriteLine("Ogiltigt alternativ, välj något annat");
                    break;


            }

            // Kontrollera att användaren inte försöker överföra till samma konto
            if (frånKonto == tillKonto)
            {
                Console.WriteLine("Du kan inte överföra till samma konto.");
                return;
            }

            // Utför överföringen
            if (frånKonto.TaUtPengar(summa))
            {
                tillKonto.Deposition(summa);
                Console.WriteLine($"Överföring av {summa} kr genomförd");
            }
            else
            {
                Console.WriteLine("Överföring misslyckades. Kontrollera saldot på det konto du överför från.");
            }

            // Visa saldo för båda kontona efter överföringen
            frånKonto.SkrivUtSaldo();
            tillKonto.SkrivUtSaldo();
            }
        }
    }
}
