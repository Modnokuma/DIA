using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numeroPosiciones;
        string respuesta;

        Console.WriteLine("######### SUCESION FIBONACHI #########");

        do
        {
            Console.Write("Numero de elementos?: ");
            respuesta = Console.ReadLine().Trim();
        } while (!(int.TryParse(respuesta, out numeroPosiciones)) || numeroPosiciones <= 0);

        var fibonacci = Enumerable.Range(1, numeroPosiciones)
            .Select(x => Fib(x))
            .ToList();

        Console.WriteLine(string.Join(", ", fibonacci));
    }

    static int Fib(int n)
    {
        return n switch
        {
            1 => 1,
            2 => 1,
            _ => Fib(n - 1) + Fib(n - 2)
        };
    }
}