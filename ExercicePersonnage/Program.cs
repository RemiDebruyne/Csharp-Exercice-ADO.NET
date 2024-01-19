using ExercicePersonnage.Data;
using ExercicePersonnage.Models;

Console.WriteLine($@"
  ____                      _   _                  
 |  _ \ ___ _ __ ___  ___ | \ | | __ _  __ _  ___ 
 | |_) / _ \ '__/ __|/ _ \|  \| |/ _` |/ _` |/ _ \
 |  __/  __/ |  \__ \ (_) | |\  | (_| | (_| |  __/
 |_|   \___|_|  |___/\___/|_| \_|\__,_|\__, |\___|
                                       |___/       ");

Console.WriteLine();

Console.WriteLine($@"	1. Créer un personnage
	2. Mettre à jour un personnage
	3. Afficher tous les personnages
	4. Taper un personnage
	5. Afficher les personnages ayant des PVs (PV + armure) supérieurs à la moyenne");

void CreerPersonnage()
{
    string pseudo = Console.ReadLine();
    int pv = int.Parse(Console.ReadLine());
    int armure = int.Parse(Console.ReadLine());
    int dmg = int.Parse(Console.ReadLine());
    Personnage personnage = new()
    {
        Pseudo = pseudo,
        Pv = pv,
        Armure = armure,
        Dmg = dmg,
    };

    using var context = new PersonnageContext();

        context.Personnages.Add(personnage);

    context.SaveChanges();

}

while (true)
{
    switch (Console.ReadLine())
    {
        case "1":
            CreerPersonnage();
            break;
        case "2":

            break;
        case "3":
            break;
        case "4":
            break;
        case "5":
            break;
        default:
            Console.WriteLine("Valeur incorrecte");
            break;
    }
}
