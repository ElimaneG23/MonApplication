using System;

class Programme
{
    static void Main()
    {
        Console.WriteLine("Ecrivez votre premier numéro :");
        int numb1;
        while (!int.TryParse(Console.ReadLine(), out numb1))
        {
            Console.WriteLine("Ce n'est pas un numéro valide. Reecrivez votre premier numéro :");
        }

        Console.WriteLine("Ecrivez votre deuxième numéro :");
        int numb2;
        while (!int.TryParse(Console.ReadLine(), out numb2))
        {
            Console.WriteLine("Ce n'est pas un numéro valide. Reecrivez votre deuxième numéro :");
        }



        if (numb1 > numb2)
        {
            Console.WriteLine("Le premier numéro est plus grand");
        }
        else
        {
            Console.WriteLine("Le deuxième numéro est plus grand");
        }

    }
}
