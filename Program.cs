using System;
namespace ExoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Chien rex = new Chien();
            Chat minou = new Chat();

            rex.Parler();  
            minou.Parler();

        }
    }
    public class Animal
    {
        public void Parler()
        {
            Console.WriteLine("L'animal fait un bruit...");
        }
    }

    public class Chien : Animal
    {
        public new void Parler()
        {
            Console.WriteLine("Le chien aboie");
        }
    }

    public class Chat : Animal
    {
        public new void Parler()
        {
            Console.WriteLine("Le chat miaule");
        }
    }
}