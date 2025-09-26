using System;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

        }

    }
    public class Livre
    {
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int isbn { get; set; }

        public Livre(string titre, string auteur, int anneePublication)
        {
            Titre = titre;
            Auteur = auteur;
            isbn = anneePublication;
        }

        public override string ToString()
        {
            return $"{Titre} par {Auteur}, publié en {isbn}";
        }


    }

    public class Bibliotheque
    {
        List<Livre> livres = new List<Livre>();
        public void AjouterLivre(Livre livre)
        {
            livres.Add(livre);
        }
        public void AfficherLivres()
        {
            foreach (var livre in livres)
            {
                Console.WriteLine(livre);
            }

        }
        public void SupprimerLivre(Livre livre)
        {
            livres.Remove(livre);
        }
    }
}