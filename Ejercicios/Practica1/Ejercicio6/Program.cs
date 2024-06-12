namespace Ejercicio6
{
    using System;
    using System.Text.RegularExpressions;
    //Crear un programa que permita detectar duplicados. Ante una secuencia de n + 2 números enteros, separados por comas, espacios, o guiones,
    //el programa devolverá aquel número, o números, si existen, que aparezca repetidos.
    class ejercicio6
    {
        static string eliminarSimbolos(string texto)
        {
            texto = Regex.Replace(texto, @"[^a-zA-Z]", "");
            
            return texto;
        }
        static void Main(string[] args)
        {
            List<int> introducidos;
            Console.Write("Introduzca secuencia de enteros: ");
            string aux = Console.ReadLine().Trim();

            eliminarSimbolos(aux);
        }
    }
    
}

