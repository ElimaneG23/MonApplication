using System;
namespace ArayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string? prenom;
            string? nom;
            string? adreesse;

            Console.WriteLine("Entrer votre prenom");
            prenom = Console.ReadLine();
            Console.WriteLine("Entrer votre nom");
            nom = Console.ReadLine();
            Console.WriteLine("Entrer votre adresse");
            adreesse = Console.ReadLine();
            Console.WriteLine("Prenom : " + prenom );
            Console.WriteLine("Nom : " + nom );
            Console.WriteLine("Adresse : " + adreesse );
            
        }
    }
}