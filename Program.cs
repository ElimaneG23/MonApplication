using System;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }
    }
    class Student
    {
        string Nom = "Elimane";
        int Age = 35;

        public void AfficherInfos()
        {
            Console.WriteLine("Nom: " + Nom + " est age de" + Age + " ans");
        }
    }
}