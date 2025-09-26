using System;
using System.Runtime.CompilerServices;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque maBibliotheque = new Bibliotheque();

            Livre livre1 = new Livre { Titre = "1984", Auteur = "George Orwell", ISBN = 123456789 };
            Livre livre2 = new Livre { Titre = "Phedre", Auteur = "Jean Racine", ISBN = 123456789 };
            Livre livre3 = new Livre { Titre = "Une Si Longue Lettre", Auteur = "Mariama ba", ISBN = 123456789 };
            Livre livre4 = new Livre { Titre = "L'os de Mor Lam", Auteur = "Birago Diop", ISBN = 123456789 };
            Livre livre5 = new Livre { Titre = "Vol de nuit", Auteur = "Antoine de Saint-Exupéry", ISBN = 123456789 };
            Livre livre6 = new Livre { Titre = "Le Petit Prince", Auteur = "Antoine de Saint-Exupéry", ISBN = 987654321 };

            maBibliotheque.AfficherLivres();

            maBibliotheque.AjouterLivre(livre4);
            maBibliotheque.AjouterLivre(livre6);
            maBibliotheque.AjouterLivre(livre3);

            maBibliotheque.RechercherLivre("1984");
            maBibliotheque.RechercherLivre("Le Seigneur des Anneaux");

            maBibliotheque.SupprimerLivre(livre4.Titre);

           
        }

    }
    class Livre
    {
        public string Titre;
        public string Auteur;
        public int ISBN;

        
    }

    class Bibliotheque
    {
        public List<Livre> Livres = new List<Livre>();

        public void AjouterLivre(Livre livre)
        {
            Livres.Add(livre);
            Console.WriteLine($"Livre '{livre.Titre}' ajouté à la bibliothèque.");
        }

        public void AfficherLivres()
        {

            foreach (var livre in Livres)
            {
                Console.WriteLine($"Titre: {livre.Titre}, Auteur: {livre.Auteur}, ISBN: {livre.ISBN}");
            }
            
        }

        public void RechercherLivre(string titre)
        {
            var livreTrouve = Livres.Find(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));
            if (livreTrouve != null)
            {
                Console.WriteLine($"Livre trouvé: Titre: {livreTrouve.Titre}, Auteur: {livreTrouve.Auteur}, ISBN: {livreTrouve.ISBN}");
            }
            else
            {
                Console.WriteLine("Livre non trouvé.");
            }
        }
        public void SupprimerLivre(string titre)
        {
            var livreASupprimer = Livres.Find(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));
            if (livreASupprimer != null)
            {
                Livres.Remove(livreASupprimer);
                Console.WriteLine($"Livre '{titre}'a été supprimé de la bibliothèque.");
            }
            else
            {
                Console.WriteLine("Livre non trouvé.");
            }
        }
    }
}