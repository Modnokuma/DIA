namespace Ejercicio4
{
    using System;

    class ejercicio4
    {
        static void Main(string[] args)
        {
            int aux;
            int ant = 0;
            int act = 1;
            int numeroPosiciones;
            string respuesta;
            int[] fibo;
            Console.WriteLine("######### SUCESION FIBONACHI #########");

            do
            {
                Console.Write("Numero de elementos?: ");
                respuesta = Console.ReadLine().Trim();
            } while (!(int.TryParse(respuesta, out numeroPosiciones)) || numeroPosiciones<=0);

            for (int i = 1; i <= numeroPosiciones; i++)
            {
                
                aux = ant + act;
                if (i >= 2)
                {
                    ant = act;
                    act = aux;
                }

                
                Console.Write(aux);
                if (i != numeroPosiciones)
                {
                    Console.Write(", ");
                }

            }
        }
    }
}