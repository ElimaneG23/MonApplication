using System;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "Elimane", "Becaye", "Abibatou", "Daouda", "Aissatou",
                 "Mamadou", "Fatoumata", "Oumar", "Khadidiatou", "Moussa",
                "Aminata", "Cheikh", "Coumba", "Seynabou", "Ibrahima",
                 "Adama", "Ndeye", "Mame", "Assane", "Pape",
            };
            foreach (var name in names)
            {
                Console.WriteLine("Je m'appelle " + name);


            }
        }

    }
}