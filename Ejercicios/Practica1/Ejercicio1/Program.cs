namespace Ejercicios{
    using System;

    class Ejercicio1
    {
        static void Main(string [] args)
        {
            List<int> divisoresEnteros = new List<int>();
            Console.Write("Introduce un Entero:  ");
            int entero = int.Parse(Console.ReadLine());

            for (int i = 1; i < entero; i++)
            {
                if (entero % i == 0)
                {
                    divisoresEnteros.Add(i);
                }
            }
            Console.Write("Divisores enteros: ");
            for (int j = 0; j < divisoresEnteros.Count; j++)
            {
                Console.Write(divisoresEnteros[j]);

                if (j < divisoresEnteros.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            
        }
    }
}

