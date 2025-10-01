using System;
using System.Runtime.CompilerServices;
using myNewApp.Model;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personne> personnes = new List<Personne>();
            Personne personne1 = new Personne("Gueye", "Elimane", "elimaneg@gmail.com");
            Personne personne2 = new Personne("Dia", "Matel", "cdia424g@gmail.com");
            Personne personne3 = new Personne("Seck", "Pablo", "sckpablo1g@gmail.com");
            Personne personne4 = new Personne("Ndiaye", "Daouda", "dndiayeg@gmail.com");
            Personne personne5 = new Personne("Sow", "Lamine", "sowlamine4g@gmail.com");
            personnes.AddRange(personne1, personne2, personne3, personne4, personne5);

            List<Livre> bibliotheque = new List<Livre>();
            Livre livre1 = new Livre("1984", "George Orwell", 123456);
            Livre livre2 = new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 789012);
            Livre livre3 = new Livre("Fahrenheit 451", "Ray Bradbury", 345678);
            Livre livre4 = new Livre("Brave New World", "Aldous Huxley", 901234);
            Livre livre5 = new Livre("Les Misérables", "Victor Hugo", 567890);
            bibliotheque.AddRange(livre1, livre2, livre3, livre4, livre5);

            Console.WriteLine("Bienvenue dans la gestion de bibliothèque !");
            Console.WriteLine("-----------------------------------------");

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("Choisissez une option : ");
                Console.WriteLine("1. Afficher tous les livres");
                Console.WriteLine("2. Ajouter un livre");
                Console.WriteLine("3. Rechercher un livre par titre");
                Console.WriteLine("4. Trier par auteurs ");
                Console.WriteLine("5. Liste des personnes");
                Console.WriteLine("6. Emprunter un livre");
                Console.WriteLine("7. Ajouter une personne");
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
                        Bibliotheque.EmprunterLivre(bibliotheque, personnes);
                        break;
                    case "7":
                        Bibliotheque.AjouterPersonne(personnes);
                        break;
                    case "8":
                        continuer = false;
                        Console.WriteLine("Au revoir !");
                        break;
                }
            }
        }
    }


    class Bibliotheque
    {

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
            while (titre.Length < 4 || titre.Length > 150)
            {
                Console.Write("Nombre de caractères invalide. Remettez un Titre : ");
                titre = Console.ReadLine();
            }

            Console.Write("Auteur : ");
            string auteur = Console.ReadLine();
            while (auteur.Length < 4 || auteur.Length > 150)
            {
                Console.Write("Nombre de caracteres invalide. Remettez un auteur : ");
                titre = Console.ReadLine();
            }

            int annee;
            while (true)
            {
                Console.Write("ISBN : ");
                if (int.TryParse(Console.ReadLine(), out annee))
                    break;
                else
                    Console.WriteLine("Veuillez  entrer un nombre valide pour l'année.");
            }

            bibliotheque.Add(new Livre(titre, auteur, annee));
            Console.WriteLine("Livre ajouté avec succès !");
        }


        public static void RechercherLivre(List<Livre> bibliotheque)
        {
            Console.Write("Entrez le titre à rechercher : ");
            string recherche = Console.ReadLine();

            var resultat = bibliotheque.FindAll(l => l.Titre.ToLower().Contains(recherche.ToLower()));
    
            if (resultat.Count == 0)
                Console.WriteLine("Aucun livre trouvé avec ce titre.");
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

        public static void AfficherPersonnes(List<Personne> personnes)
        {
            Console.WriteLine("\n--- Liste des personnes ---");
            foreach (var personne in personnes)
            {
                personne.AfficherPersonne();
            }

        }

        public static void EmprunterLivre(List<Livre> bibliotheque, List<Personne> personnes)
        {
            Console.Write("Entrez le nom de la personne empruntant le livre : ");
            string nomPersonne = Console.ReadLine();
            
            var personne = personnes.Find(p => p.Nom.Equals(nomPersonne, StringComparison.OrdinalIgnoreCase));
            if (personne == null)
            {
                Console.WriteLine($"{nomPersonne} n'est pas inscrit dans la bibliothèque.");
                Console.Write("Entrez un nom qui figure dans la liste de la bibliotheque : ");
                nomPersonne = Console.ReadLine();
            } else
            {
                Console.WriteLine($"Bienvenue {personne.Prenom} {personne.Nom} !");
            }

            Console.Write("Entrez le titre du livre à emprunter : ");
            string titreLivre = Console.ReadLine();

            var livre = bibliotheque.Find(l => l.Titre.Equals(titreLivre, StringComparison.OrdinalIgnoreCase));
            if (livre == null)
            {
                Console.WriteLine("Livre non trouvé.");
                return;
            }

            bibliotheque.Remove(livre);
            Console.WriteLine($"{personne.Prenom} {personne.Nom} a emprunté le livre '{livre.Titre}'.");
        }

        public static void AjouterPersonne(List<Personne> personnes)
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            while (nom.Length < 4 || nom.Length > 150)
            {
                Console.Write("Nombre de caractères invalide. Remettez un Nom : ");
                nom = Console.ReadLine();
            }

            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            while (prenom.Length < 4 || prenom.Length > 150)
            {
                Console.Write("Nombre de caracteres invalide. Remettez un Prénom : ");
                prenom = Console.ReadLine();
            }

            Console.Write("Email : ");
            string email = Console.ReadLine();
            while (email.Length < 4 || email.Length > 155 || !email.Contains("@"))
            {
                Console.Write("Email invalide (doit contenir @ et avoir entre 4 et 15 caractères). Remettez un Email : ");
                email = Console.ReadLine();

                personnes.Add(new Personne(nom, prenom, email));
                Console.WriteLine("Personne ajoutée avec succès !");
            }
        }
    }
}