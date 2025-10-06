
using System;

namespace MyNewApp.Model
{
    public class Livre
    {
        public string Titre { get; }
        public string Auteur { get; }
        public int ISBN { get; }
        public bool EstEmprunte { get; private set; }

        public Livre(string titre, string auteur, int isbn)
        {
            if (string.IsNullOrWhiteSpace(titre)) throw new ArgumentException("Titre requis", nameof(titre));
            if (string.IsNullOrWhiteSpace(auteur)) throw new ArgumentException("Auteur requis", nameof(auteur));
            if (isbn <= 0) throw new ArgumentOutOfRangeException(nameof(isbn), "ISBN doit être positif");

            Titre = titre.Trim();
            Auteur = auteur.Trim();
            ISBN = isbn;
            EstEmprunte = false;
        }

        public void MarquerEmprunte()
        {
            if (EstEmprunte) throw new InvalidOperationException("Livre déjà emprunté");
            EstEmprunte = true;
        }

        public void MarquerRetour()
        {
            EstEmprunte = false;
        }

        public void AfficherLivres()
        {
            Console.WriteLine($"Titre: {Titre}, Auteur: {Auteur}, ISBN: {ISBN}" + (EstEmprunte ? " [Emprunté]" : ""));
        }
    }
}
