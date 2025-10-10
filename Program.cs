using System;
using System.Collections.Generic;
using Csharp.Models;

namespace Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Livre> bibliotheque = new List<Livre>
            {
                new Livre { Titre = "1984", Auteur = "George Orwell", ISBN = 123456 },
                new Livre { Titre = "Le Petit Prince", Auteur = "Antoine de Saint-Exupéry", ISBN = 789012 },
                new Livre { Titre = "Fahrenheit 451", Auteur = "Ray Bradbury", ISBN = 345678 },
                new Livre { Titre = "Brave New World", Auteur = "Aldous Huxley", ISBN = 901234 },
                new Livre { Titre = "Les Misérables", Auteur = "Victor Hugo", ISBN = 567890 }
            };

            List<Personne> personnes = new List<Personne>
            {
                new Personne { Id = 1, Nom = "Gueye", Prenom = "Elimane", Email = "elimaneg@gmail.com" },
                new Personne { Id = 2, Nom = "Dia", Prenom = "Matel", Email = "cdia424g@gmail.com" },
                new Personne { Id = 3, Nom = "Seck", Prenom = "Pablo", Email = "sckpablo1g@gmail.com" },
                new Personne { Id = 4, Nom = "Ndiaye", Prenom = "Daouda", Email = "dndiayeg@gmail.com" },
                new Personne { Id = 5, Nom = "Sow", Prenom = "Lamine", Email = "sowlamine4g@gmail.com" }
            };


            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Afficher tous les livres");
                Console.WriteLine("2. Ajouter un livre");
                Console.WriteLine("3. Rechercher un livre par titre");
                Console.WriteLine("4. Trier par auteurs");
                Console.WriteLine("5. Afficher toutes les personnes");
                Console.WriteLine("6. Ajouter une personne");
                Console.WriteLine("7. Emprunter un livre");
                Console.WriteLine("8. Quitter");

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
                        Bibliotheque.AfficherPersonnes(personnes);
                        break;
                    case "6":
                        Bibliotheque.AjouterPersonne(personnes);
                        break;
                    case "7":
                        Bibliotheque.EmprunterLivre(bibliotheque, personnes);
                        break;
                    case "8":
                        continuer = false;
                        Console.WriteLine("Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Option invalide, réessayez.");
                        break;
                }
            }
        }
    }

    class Bibliotheque
    {
        // Affichage des livres
        public static void AfficherLivres(List<Livre> bibliotheque)
        {
            Console.WriteLine("\n--- Liste des livres ---");
            foreach (var livre in bibliotheque)
                Console.WriteLine(livre); // ToString() est appelé automatiquement
        }

        // Ajouter un livre
        public static void AjouterLivre(List<Livre> bibliotheque)
        {
            try
            {
                Console.Write("Titre : ");
                string titre = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(titre) || titre.Length < 4)
                {
                    Console.Write("Titre invalide. Réessayez : ");
                    titre = Console.ReadLine();
                }

                Console.Write("Auteur : ");
                string auteur = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(auteur) || auteur.Length < 4)
                {
                    Console.Write("Auteur invalide. Réessayez : ");
                    auteur = Console.ReadLine();
                }

                int isbn;
                while (true)
                {
                    Console.Write("ISBN (nombre) : ");
                    if (int.TryParse(Console.ReadLine(), out isbn))
                        break;
                    else
                        Console.WriteLine("ISBN invalide. Réessayez.");
                }

                bibliotheque.Add(new Livre { Titre = titre, Auteur = auteur, ISBN = isbn });
                Console.WriteLine("Livre ajouté avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout du livre : " + ex.Message);
            }
        }

        // Rechercher un livre par titre
        public static void RechercherLivre(List<Livre> bibliotheque)
        {
            try
            {
                Console.Write("Entrez le titre à rechercher : ");
                string recherche = Console.ReadLine();

                var resultat = bibliotheque.FindAll(l => l.Titre.ToLower().Contains(recherche.ToLower()));
                if (resultat.Count == 0)
                    Console.WriteLine("Aucun livre trouvé.");
                else
                    resultat.ForEach(l => Console.WriteLine(l)); // ToString()
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la recherche : " + ex.Message);
            }
        }

        // Trier les livres par auteur
        public static void TrierLivres(List<Livre> bibliotheque)
        {
            try
            {
                bibliotheque.Sort((l1, l2) => l1.Auteur.CompareTo(l2.Auteur));
                Console.WriteLine("Livres triés par auteurs :");
                bibliotheque.ForEach(l => Console.WriteLine(l)); // ToString()
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du tri : " + ex.Message);
            }
        }

        // Affichage des personnes
        public static void AfficherPersonnes(List<Personne> personnes)
        {
            Console.WriteLine("\n--- Liste des personnes ---");
            foreach (var p in personnes)
                Console.WriteLine(p); // ToString()
        }

        // Ajouter une personne avec ID automatique
        public static void AjouterPersonne(List<Personne> personnes)
        {
            try
            {
                Console.Write("Nom : ");
                string nom = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(nom) || nom.Length < 2)
                {
                    Console.Write("Nom invalide. Réessayez : ");
                    nom = Console.ReadLine();
                }

                Console.Write("Prénom : ");
                string prenom = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(prenom) || prenom.Length < 2)
                {
                    Console.Write("Prénom invalide. Réessayez : ");
                    prenom = Console.ReadLine();
                }

                Console.Write("Email : ");
                string email = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                {
                    Console.Write("Email invalide. Réessayez : ");
                    email = Console.ReadLine();
                }

                int nouvelId = personnes.Count > 0 ? personnes[^1].Id + 1 : 1; // ID automatique
                personnes.Add(new Personne { Id = nouvelId, Nom = nom, Prenom = prenom, Email = email });

                Console.WriteLine("Personne ajoutée avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout de la personne : " + ex.Message);
            }
        }

        // Emprunter un livre par ID de la personne
        public static void EmprunterLivre(List<Livre> bibliotheque, List<Personne> personnes)
        {
            try
            {
                if (personnes.Count == 0 || bibliotheque.Count == 0)
                {
                    Console.WriteLine("Aucun livre ou personne disponible pour emprunter.");
                    return;
                }

                Console.WriteLine("Liste des personnes inscrites :");
                foreach (var p in personnes)
                    Console.WriteLine(p); // ToString()

                Personne personne = null;
                while (personne == null)
                {
                    Console.Write("Entrez l'ID de la personne empruntant le livre : ");
                    if (int.TryParse(Console.ReadLine(), out int idPersonne))
                    {
                        personne = personnes.Find(p => p.Id == idPersonne);
                        if (personne == null)
                            Console.WriteLine("Aucune personne trouvée avec cet ID, veuillez réessayer.");
                    }
                    else
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un nombre.");
                    }
                }

                Console.WriteLine($"\nBienvenue {personne.Prenom} {personne.Nom} !");
                Console.WriteLine("Liste des livres disponibles :");
                foreach (var livre in bibliotheque)
                    Console.WriteLine(livre); // ToString()

                Livre livreEmprunte = null;
                while (livreEmprunte == null)
                {
                    Console.Write("Entrez le titre du livre à emprunter : ");
                    string titreLivre = Console.ReadLine();
                    livreEmprunte = bibliotheque.Find(l => l.Titre.Equals(titreLivre, StringComparison.OrdinalIgnoreCase));

                    if (livreEmprunte == null)
                        Console.WriteLine("Livre non trouvé, veuillez réessayer.");
                }

                Console.WriteLine($"{personne.Prenom} {personne.Nom} a emprunté : {livreEmprunte.Titre} par {livreEmprunte.Auteur}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue : {ex.Message}");
            }

        }
    }
}
