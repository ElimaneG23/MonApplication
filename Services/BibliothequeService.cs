using System;
using System.Collections.Generic;
using System.Linq;
using MyNewApp.Model;

namespace MyNewApp.Services
{
    public class BibliothequeService
    {
        private readonly List<Livre> livres;
        private readonly List<Personne> personnes;

        public BibliothequeService(List<Livre> livres, List<Personne> personnes)
        {
            this.livres = livres ?? new List<Livre>();
            this.personnes = personnes ?? new List<Personne>();
        }

        public void AfficherLivres()
        {
            Console.WriteLine("\n--- Liste des livres ---");
            if (livres.Count == 0)
            {
                Console.WriteLine("Aucun livre.");
                return;
            }
            foreach (var livre in livres)
            {
                livre.AfficherLivres();
            }
        }

        public void AjouterLivre()
        {
            Console.Write("Titre : ");
            var titre = LireTexteValide(min: 2, max: 150);

            Console.Write("Auteur : ");
            var auteur = LireTexteValide(min: 2, max: 150);

            var isbn = LireEntierPositif("ISBN : ");

            livres.Add(new Livre(titre, auteur, isbn));
            Console.WriteLine("Livre ajouté avec succès !");
        }

        public void RechercherLivre()
        {
            Console.Write("Entrez le titre à rechercher : ");
            var recherche = Console.ReadLine()?.Trim() ?? string.Empty;

            var resultat = livres
                .Where(l => l.Titre.Contains(recherche, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultat.Count == 0)
            {
                Console.WriteLine("Aucun livre trouvé avec ce titre.");
                return;
            }

            foreach (var livre in resultat)
            {
                livre.AfficherLivres();
            }
        }

        public void TrierLivres()
        {
            livres.Sort((l1, l2) => string.Compare(l1.Auteur, l2.Auteur, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Livres triés par ordre alphabétique des auteurs.");
            foreach (var livre in livres)
            {
                Console.WriteLine($"Auteur: {livre.Auteur}");
                Console.WriteLine($"Titre: {livre.Titre}");
                Console.WriteLine("\n------------------------\n");
            }
        }

        public void AfficherPersonnes()
        {
            Console.WriteLine("\n--- Liste des personnes ---");
            if (personnes.Count == 0)
            {
                Console.WriteLine("Aucune personne.");
                return;
            }
            foreach (var personne in personnes)
            {
                personne.AfficherPersonne();
            }
        }

        public void EmprunterLivre()
        {
            Console.Write("Entrez le nom de la personne empruntant le livre : ");
            var nomPersonne = Console.ReadLine()?.Trim() ?? string.Empty;
            var personne = personnes.Find(p => p.Nom.Equals(nomPersonne, StringComparison.OrdinalIgnoreCase));
            if (personne == null)
            {
                Console.WriteLine($"{nomPersonne} n'est pas inscrit dans la bibliothèque.");
                return;
            }

            Console.Write("Entrez le titre du livre à emprunter : ");
            var titreLivre = Console.ReadLine()?.Trim() ?? string.Empty;
            var livre = livres.Find(l => l.Titre.Equals(titreLivre, StringComparison.OrdinalIgnoreCase));
            if (livre == null)
            {
                Console.WriteLine("Livre non trouvé.");
                return;
            }

            try
            {
                livre.MarquerEmprunte();
                Console.WriteLine($"{personne.Prenom} {personne.Nom} a emprunté le livre '{livre.Titre}'.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AjouterPersonne()
        {
            Console.Write("Nom : ");
            var nom = LireTexteValide(min: 2, max: 150);

            Console.Write("Prénom : ");
            var prenom = LireTexteValide(min: 2, max: 150);

            Console.Write("Email : ");
            var email = LireEmailValide();

            personnes.Add(new Personne(nom, prenom, email));
            Console.WriteLine($"{nom} a été ajouté avec succès !");
        }

        private static string LireTexteValide(int min, int max)
        {
            while (true)
            {
                var input = Console.ReadLine()?.Trim() ?? string.Empty;
                if (input.Length >= min && input.Length <= max) return input;
                Console.Write($"Nombre de caractères invalide. Remettez une valeur ({min}-{max}) : ");
            }
        }

        private static int LireEntierPositif(string invite)
        {
            while (true)
            {
                Console.Write(invite);
                if (int.TryParse(Console.ReadLine(), out var value) && value > 0) return value;
                Console.WriteLine("Veuillez entrer un nombre entier positif valide.");
            }
        }

        private static string LireEmailValide()
        {
            while (true)
            {
                var email = Console.ReadLine()?.Trim() ?? string.Empty;
                if (email.Length >= 4 && email.Length <= 155 && email.Contains("@")) return email;
                Console.Write("Email invalide (doit contenir @ et avoir entre 4 et 155 caractères). Remettez un Email : ");
            }
        }
    }
}