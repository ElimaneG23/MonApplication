namespace Csharp.Models
{
    public class Personne
    {
        public int Id { get; set; } // ID automatique
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        // ToString() pour affichage simple
        public override string ToString()
        {
            return $"ID: {Id} | Nom: {Nom} | Prénom: {Prenom} | Email: {Email}";
        }
    }
}
