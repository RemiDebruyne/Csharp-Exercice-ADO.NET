using ExerciceHotelV2.Models;
using ExerciceHotelV2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2
{
    internal class IHM
    {
        private readonly GenericRepository<Client> _clientRepository;
        private readonly GenericRepository<Reservation> _reservationRepository;
        private readonly GenericRepository<Chambre> _chambreRepository;
        private readonly GenericRepository<ChambreReservation> _reservationChambreRepository;

        public IHM()
        {
            _clientRepository = new GenericRepository<Client>();
            _reservationRepository = new GenericRepository<Reservation>();
            _chambreRepository = new GenericRepository<Chambre>();
            _reservationChambreRepository = new GenericRepository<ChambreReservation>();
        }

        private void AfficherMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Menu Principal =====\n");
            Console.WriteLine("1. Afficher la liste des clients");
            Console.WriteLine("2. Ajouter un client");
            Console.WriteLine("3. Liste des réservations d'un client");
            Console.WriteLine("4. Afficher les chambres disponibles");
            Console.WriteLine("5. Ajouter une réservation");
            Console.WriteLine("6. Annuler une réservation");
            Console.WriteLine("7. Liste des réservations");

            Console.WriteLine("0. Quitter\n");

            Console.Write("Votre choix : ");
        }

        public void AfficherClients()
        {
            Console.Clear();
            Console.WriteLine("===== Liste des clients (A-Z) =====\n");
            List<Client> clients = _clientRepository.GetAll().OrderBy(c => c.Nom).ToList();

            clients.ForEach(c => Console.WriteLine($"{c.Id} - {c.Nom.ToUpper()} {c.Prenom}"));

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();

        }

        public void ListerReservationsClient()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des réservations du client ===");

            Console.Write("Nom : ");
            string nom = Console.ReadLine()!;
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine()!;

            Client client = _clientRepository.Get(c => c.Prenom == prenom);

            List<Reservation> reservations = (List<Reservation>)_reservationRepository.GetAll().Where(r => r.Client.Id == client.Id);
        }

        public void AjouterClient()
        {
            Console.Clear();
            Console.WriteLine("===== Ajouter un client =====\n");
            Console.Write("Nom : ");
            string nom = Console.ReadLine()!;
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine()!;
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine()!;

            Client client = new Client()
            {
                Prenom = prenom,
                Nom = nom,
                Telephone = telephone,
            };

            _clientRepository.Add(client);

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();


        }

        public void Start()
        {
            while (true)
            {
                AfficherMenu();
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1":
                        AfficherClients();
                        break;
                    case "2":
                        AjouterClient();
                        break;
                    case "3":
                        ListerReservationsClient();
                        break;
                    case "4":
                        AfficherChambresDisponibles();
                        break;
                    case "5":
                        AjouterReservation();
                        break;
                    case "6":
                        AnnulerReservation();
                        break;
                    case "7":
                        AfficherReservations();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Erreur de saisie");
                        Console.Clear();
                        break;
                }

            }
        }
    }
}