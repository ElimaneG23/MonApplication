using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Models
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        public Personne() { }

        public void AfficherPersonne()
        {
            Console.WriteLine($"Nom: {Nom}");
            Console.WriteLine($"Prénom: {Prenom}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine("-------------------");
        }

    }
}
