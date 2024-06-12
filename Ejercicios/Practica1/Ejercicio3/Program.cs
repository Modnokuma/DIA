namespace Ejercicio3
{
    using System;

    class ejercicio3
    {
        static void Main(string[] args)
        {
            int a,b,c;
            int resultado;
            Console.WriteLine("######## TERNA PITAGORICA ########");
            
            Console.Write("Introduce el primer número: ");
            a = int.Parse(Console.ReadLine().Trim());
            Console.Write("Introduce el segundo número: ");
            b = int.Parse(Console.ReadLine().Trim());
            Console.Write("Introduce el tercer número: ");
            c = int.Parse(Console.ReadLine().Trim());
            //Convert.ToInt32( Console.ReadLine() )
            
            Console.WriteLine((a*a)+" + "+(b*b)+ " = " +(c*c));
            if ((a * a) + (b * b) == (c * c))
            {
                Console.WriteLine("\nEs una terna pitagorica");
            }
            else
            {
                Console.WriteLine("\nNo es una terna pitagorica");
            }
        }
    }
    
}

