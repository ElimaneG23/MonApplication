using System;
using System.Collections.Generic;
using MyNewApp.Model;
using MyNewApp.Services;

namespace MyNewApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var livres = new List<Livre>
            {
                new Livre("1984", "George Orwell", 123456),
                new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 789012),
                new Livre("Fahrenheit 451", "Ray Bradbury", 345678),
                new Livre("Brave New World", "Aldous Huxley", 901234),
                new Livre("Les Misérables", "Victor Hugo", 567890)
            };

            var personnes = new List<Personne>
            {
                new Personne("Gueye", "Elimane", "elimaneg@gmail.com"),
                new Personne("Dia", "Matel", "cdia424g@gmail.com"),
                new Personne("Seck", "Pablo", "sckpablo1g@gmail.com"),
                new Personne("Ndiaye", "Daouda", "dndiayeg@gmail.com"),
                new Personne("Sow", "Lamine", "sowlamine4g@gmail.com")
            };

            var service = new BibliothequeService(livres, personnes);

            Console.WriteLine("Bienvenue dans la gestion de bibliothèque !");
            Console.WriteLine("-----------------------------------------");

            var continuer = true;
            while (continuer)
            {
                Console.WriteLine("Choisissez une option : ");
                Console.WriteLine("1. Afficher tous les livres");
                Console.WriteLine("2. Ajouter un livre");
                Console.WriteLine("3. Rechercher un livre par titre");
                Console.WriteLine("4. Trier par auteurs");
                Console.WriteLine("5. Liste des personnes");
                Console.WriteLine("6. Emprunter un livre");
                Console.WriteLine("7. Ajouter une personne");
                Console.WriteLine("8. Quitter");

                var choix = Console.ReadLine()?.Trim();

                switch (choix)
                {
                    case "1":
                        service.AfficherLivres();
                        break;
                    case "2":
                        service.AjouterLivre();
                        break;
                    case "3":
                        service.RechercherLivre();
                        break;
                    case "4":
                        service.TrierLivres();
                        break;
                    case "5":
                        service.AfficherPersonnes();
                        break;
                    case "6":
                        service.EmprunterLivre();
                        break;
                    case "7":
                        service.AjouterPersonne();
                        break;
                    case "8":
                        continuer = false;
                        Console.WriteLine("Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }
    }
}