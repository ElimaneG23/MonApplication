using System;

namespace MyNewApp.Model
{
    public class Personne
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string Email { get; }

        public Personne(string nom, string prenom, string email)
        {
            if (string.IsNullOrWhiteSpace(nom)) throw new ArgumentException("Nom requis", nameof(nom));
            if (string.IsNullOrWhiteSpace(prenom)) throw new ArgumentException("Prénom requis", nameof(prenom));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) throw new ArgumentException("Email invalide", nameof(email));

            Nom = nom.Trim();
            Prenom = prenom.Trim();
            Email = email.Trim();
        }

        public void AfficherPersonne()
        {
            Console.WriteLine($"Nom: {Nom}, Prénom: {Prenom}, Email: {Email}");
        }
    }
}