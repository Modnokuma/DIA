namespace Ejercicio5
{
    // Crear un programa que permita detectar palabras o incluso frases palíndromas. La entrada se realizará por teclado, y la salida por pantalla.
    // Dicha salida consistirá en las letras "T" si es palínromo, y "F" si no lo es. El programa ignorará mayúsculas o minúsculas, así como cualquier
    // símbolo que no pertenezca al abecedario.
    using System;
    using System.Text.RegularExpressions;
    
    class ejercicio5
    {
        static string eliminarSimbolos(string palindromo)
        {
            palindromo = Regex.Replace(palindromo, @"[^a-zA-Z]", "");
            return palindromo;
        }
        
        static void Main(string[] args)
        {
            string palindromo, invertido;
            bool bandera = true;
            Console.WriteLine("###### PALINDROMOS ######");
            

            while (bandera)
            {
                Console.Write("Introduzca un posible palindromo: ");
                palindromo = Console.ReadLine().Trim().ToLower();
           
                palindromo = eliminarSimbolos(palindromo);
                invertido = new string(palindromo.Reverse().ToArray());


                if (palindromo == invertido)
                {
                    Console.WriteLine("T");
                }
                else
                {
                    Console.WriteLine("F");
                }
                
                Console.Write("Quieres introducir otro?(S/N): ");
                string aux = Console.ReadLine().Trim().ToUpper();
                
                if (aux[0] != 'S')
                {
                    bandera = false;
                }
            }

        }
    }
    
}

