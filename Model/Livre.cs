using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Models
{
    public class Livre
    {
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int ISBN { get; set; }

        public Livre() { }
        public void AfficherLivres()
        {
            Console.WriteLine($"Voici le livre intutilé : {Titre}");
            Console.WriteLine($"Auteur : {Auteur}");
            Console.WriteLine($"ISBN : {ISBN}");
            Console.WriteLine("-------------------");
        }

    }
}
