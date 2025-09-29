using System;
using System.Runtime.CompilerServices;
using myNewApp.Model;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Livre> bibliotheque = new List<Livre>();
            Livre livre1 = new Livre("1984", "George Orwell", 123456);
            Livre livre2 = new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 789012);
            Livre livre3 = new Livre("Fahrenheit 451", "Ray Bradbury", 345678);
            Livre livre4 = new Livre("Brave New World", "Aldous Huxley", 901234);
            Livre livre5 = new Livre("Les Misérables", "Victor Hugo", 567890);
            bibliotheque.AddRange(livre1, livre2, livre3, livre4, livre5);

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("\n--- Gestion Bibliothèque ---");
                Console.WriteLine("1. Afficher tous les livres");
                Console.WriteLine("2. Ajouter un livre");
                Console.WriteLine("3. Rechercher un livre par titre");
                Console.WriteLine("4. Trier par ");
                Console.WriteLine("5. Quitter");
                Console.Write("Choisissez une option : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Bibliotheque.AfficherLivres(bibliotheque);
                        break;
                    case "2":
                        Bibliotheque.AjouterLivre(bibliotheque);
                        break;

                    case "3":
                        Bibliotheque.RechercherLivre(bibliotheque);
                        break;
                    case "4":
                        Bibliotheque.TrierLivres(bibliotheque);
                        break;
                    case "5":
                        continuer = false;
                        Console.WriteLine("Au revoir !");
                        break;
                    
                }
            }
        }
    }


    class Bibliotheque
    {
        private static int isbn;
        public List<Livre> Livres = new List<Livre>();

        public static void AfficherLivres(List<Livre> bibliotheque)
        {

            Console.WriteLine("\n--- Liste des livres ---");
            foreach (var livre in bibliotheque)
            {
                livre.AfficherLivres();
            }

        }

        public static void AjouterLivre(List<Livre> bibliotheque)
        {
            Console.Write("Titre : ");
            string titre = Console.ReadLine();
            while(titre.Length < 4 || titre.Length > 150)
            {
                Console.Write("Nombre de caractères invalide. Remettez un Titre : ");
                titre = Console.ReadLine();
            }

            Console.Write("Auteur : ");
            string auteur = Console.ReadLine();
            while(auteur.Length < 4 || auteur.Length > 150)
            {
                Console.Write("Nombre de caracteres invalide. Remettez un auteur : ");
                titre = Console.ReadLine();
            }

            int annee;
            while (true)
            {
                Console.Write("ISBN : ");
                if (int.TryParse(Console.ReadLine(), out isbn))
                    break;
                else
                    Console.WriteLine("Veuillez entrer un nombre valide pour l'année.");
            }

            bibliotheque.Add(new Livre(titre, auteur, isbn));
            Console.WriteLine("Livre ajouté avec succès !");
        }


        public static void RechercherLivre(List<Livre> bibliotheque)
        {
            Console.Write("Entrez le titre à rechercher : ");
            string recherche = Console.ReadLine();

            var resultat = bibliotheque.FindAll(l => l.Titre.ToLower().Contains(recherche.ToLower()));
           
            foreach (var livre in resultat)
                livre.AfficherLivres();

        }
        public static void TrierLivres(List<Livre> bibliotheque)
        {
            bibliotheque.Sort((l1, l2) => l1.Auteur.CompareTo(l2.Auteur));
            Console.WriteLine("Livres triés par ordre alphabetique des auteurs.");

            foreach (var livre in bibliotheque)
            {
                Console.WriteLine($"Auteur: {livre.Auteur}");
                Console.WriteLine($"Titre: {livre.Titre}");
                Console.WriteLine($"\n------------------------\n");
            }

        }
    }
}