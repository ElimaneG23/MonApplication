
namespace myNewApp.Model;

class Livre
{
    internal static object bibliotheque;
    public string Titre;
    public string Auteur;
    public int ISBN;

   

    public Livre(string titre, string auteur, int isbn)
    {
        Titre = titre;
        Auteur = auteur;
        ISBN = isbn;


    }
    public void AfficherLivres()
    {
        Console.WriteLine($"Voici le livre intutilé {Titre}, Auteur: {Auteur}, ISBN: {ISBN}");
    }

}
