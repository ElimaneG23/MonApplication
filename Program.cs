using System;

class Programme
{
    static void Main()
    {
        // Changer la couleur du texte
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Bienvenue dans le mini programme C# ===");
        Console.ResetColor(); // Remet les couleurs par défaut

        // Demander le nom de l'utilisateur
        Console.Write("Quel est ton prénom ? ");
        string prenom = Console.ReadLine();

        // Effacer l'écran après la saisie
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bonjour " + prenom + " !");
        Console.ResetColor();

        // Demander l'âge
        Console.Write("Quel âge as-tu ? ");
        string ageTexte = Console.ReadLine();

        // Essayer de convertir en entier
        int age;
        if (int.TryParse(ageTexte, out age))
        {
            Console.WriteLine("Tu as " + age + " ans.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("L'âge saisi n'est pas valide !");
            Console.ResetColor();
        }

        // Attendre que l'utilisateur appuie sur une touche
        Console.WriteLine("\nAppuie sur une touche pour quitter...");
        ConsoleKeyInfo touche = Console.ReadKey();
        Console.WriteLine("\nTu as appuyé sur : " + touche.Key);
    }
}
