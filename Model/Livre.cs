namespace Csharp.Models
{
    public class Livre
    {
        public int Id { get; set; } // Optionnel si tu veux gérer par ID
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int ISBN { get; set; }

        // ToString() pour affichage simple
        public override string ToString()
        {
            return $"Titre: {Titre} | Auteur: {Auteur} | ISBN: {ISBN}";
        }
    }
}
