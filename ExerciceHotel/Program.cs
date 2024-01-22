<<<<<<< HEAD
﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
=======
﻿using ExerciceHotel.Repositories;
using ExerciceHotel.Models;

Random rnd = new();

for (int i = 0; i < 20; i++)
{
    new Chambre();
}

Console.WriteLine($@"Que voulez vous faire ?
1. Ajouter un client
2. Modifier une réservation
3. Annuler une réservation");

switch (Console.ReadLine())
{
    case "1":
        GenericRepository<Client> table = new();
        Console.Write("Quel est son prénom : ");
        string prenom = Console.ReadLine();

        Console.Write("nom ? : ");
        string nom = Console.ReadLine();

        Console.Write("téléphone ? : ");
        string telephone = Console.ReadLine();

        Client client = new(prenom, nom, telephone);

        table.Insert(client);

        Console.Write("Combien de chambre voulez vous ? : ");


        table.Save();
        break;
    case "2":
        break;
    case "3":
        break;
    default:
        break;
}
>>>>>>> cfb5d691bac389cc282fec6bddcd2cff75e2a026
