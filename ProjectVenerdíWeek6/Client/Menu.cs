using ProjectVenerdíWeek6.Core.Models;
using ProjectVenerdíWeek6.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectVenerdíWeek6.Core.Models.Polizza;

namespace ProjectVenerdíWeek6.Client
{
    class Menu
    {
        private static MainBL mainBL = new MainBL(new EFCustomerRepository(), new EFPolizzaRepository());
        internal static void Start()
        {
            Console.WriteLine("***Benvenuto***\n");
            bool continuare = true;
            int scelta;

            while (continuare)
            {
                Console.WriteLine("\nPremi 1 per inserire un nuovo cliente.");
                Console.WriteLine("Premi 2 per inserire una polizza per un cliente giá esistente.");
                Console.WriteLine("Premi 3 per visualizzare le polizze di un cliente.");
                Console.WriteLine("Premi 4 per posticcipare la data di scadenza.");
                Console.WriteLine("Premi 0 per uscire");

                do
                {
                    Console.WriteLine("Fai la tua scelta");
                } while (!int.TryParse(Console.ReadLine(), out scelta));

                switch (scelta)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            AddNewClient();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine();
                            AddPolizzaAlCliente();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine();
                            ShowPolizzaCliente();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine();
                            //CambioData();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("***Arrivederci!***");
                            continuare = false;
                            break;
                        }
                }
            }
        }

        private static void ShowPolizzaCliente()
        {
            //var customers = mainBL.FetchAllClients();
            //Customer customer;           

            int num;
            Console.WriteLine("Inserisci il numero del cliente di cui vuoi vedere le sue polizze:\n");
            ShowAllClients();
            do
            {
                Console.WriteLine("Inserisci il numero:");

            } while (!int.TryParse(Console.ReadLine(), out num) || num < 0);


            var customer = GetCustomerById(num);

            if (customer == null)
            {
                Console.WriteLine("Il cliente non esiste nel database!");
            }
            else
            {
                //TODO - Ho numero di cliente salvato nel customer, poi accedo al cliente e alle sue polizze e le stampo
                //provavo con il ciclo Foreach ma mi dava errore 
            }


        }

        private static Customer GetCustomerById(int num)
        {
            var customer = mainBL.GetByCode(num);
            return customer;
        }

        private static void AddPolizzaAlCliente()
        {
            Customer customer = ShowAllClients();


            int codice;
            do
            {
                Console.WriteLine("Inserisci il numero della polizza:\n");

            } while (!int.TryParse(Console.ReadLine(), out codice) || codice < 0);

            DateTime dt = new DateTime();
            do
            {
                Console.WriteLine("Inserisci la data di scadenza della polizza:\n");

            } while (!DateTime.TryParse(Console.ReadLine(), out dt) || dt < DateTime.Now);

            decimal rata;
            Console.Write("Inserisci rata mensile della polizza.\n");

            while (!decimal.TryParse(Console.ReadLine(), out rata) || rata < 0)
            {
                Console.WriteLine("Devi inserire un valore valido!");
            }

            int tipoAs;
            bool isInt;
            do
            {
                Console.WriteLine("Scegli il tipo della assicurazione");
                foreach (var t in Enum.GetValues(typeof(EnumTipo)))
                {
                    Console.WriteLine($"Premi {(int)t} per {(EnumTipo)t}");
                }
                isInt = int.TryParse(Console.ReadLine(), out tipoAs);

            } while (!isInt || tipoAs < 0 || tipoAs > 3);

            Polizza polizza = new Polizza
            {
                NumeroPolizza = codice,
                DataScadenza = dt,
                RataMensile = rata,
                Tipo = (EnumTipo)tipoAs,
                Customer = customer,
                CustomerId = customer.Id
            };

            bool isAdded = mainBL.AddPolizza(polizza);
            if (isAdded)
            {
                Console.WriteLine("La polizza assegnata con successo!");
            }
            else
            {
                Console.WriteLine("Errore! La polizza non é stata aggiunta!");
            }

        }

        private static Customer ShowAllClients()
        {
            List<Customer> customers = mainBL.FetchAllClients();

            int i = 1;
            foreach (var c in customers)
            {
                Console.WriteLine($"Premi {i} per cliente con Codice Fiscale: {c.CodiceFiscale}, Nome: {c.Nome}, Cognome: {c.Cognome}");
                i++;
            }

            bool isInt;
            int customerScelto;
            do
            {
                Console.WriteLine("A quale customer vuoi aggiungere una polizza?Oppure vedere le sue polizze?");

                isInt = int.TryParse(Console.ReadLine(), out customerScelto);

            } while (!isInt || customerScelto <= 0 || customerScelto > customers.Count);

            return customers.ElementAt(customerScelto - 1);

        }

        private static void AddNewClient()
        {
            String codiceFiscale = String.Empty;
            String nome = String.Empty;
            String cognome = String.Empty;


            do
            {
                Console.WriteLine("Inserisci il codice fiscale di 16 cifre:\n");
                codiceFiscale = Console.ReadLine();

            } while (String.IsNullOrEmpty(codiceFiscale));

            do
            {
                Console.WriteLine("Inserisci il nome:\n");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));

            do
            {
                Console.WriteLine("Inserisci il cognome:\n");
                cognome = Console.ReadLine();

            } while (String.IsNullOrEmpty(cognome));


            Customer customer = new Customer
            {
                CodiceFiscale = codiceFiscale,
                Nome = nome,
                Cognome = cognome,

            };


            bool isAdded = mainBL.AddCustomer(customer);
            if (isAdded)
            {
                Console.WriteLine("Il customer aggiunto con successo!");
            }
            else
            {
                Console.WriteLine("Errore! Il customer non é stato aggiunto!");
            }

        }


    }
}
