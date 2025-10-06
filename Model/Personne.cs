class Personne
{
    public string Nom;
    public string Prenom;
    public string Email;

    public Personne(string nom, string prenom, string email)
    {
        Nom = nom;
        Prenom = prenom;
        Email = email;

    }

    public void AfficherPersonne()
    {
        Console.WriteLine($"Nom: {Nom}");
        Console.WriteLine($"Prénom: {Prenom}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine("-------------------");
    }


}