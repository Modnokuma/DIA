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
            texto = Regex.Replace(texto, @"[^0-9]", "");
            
            return texto;
        }
        static void Main(string[] args)
        {
            int contador;
            List<char> repetidos = new List<char>();
            
            Console.Write("Introduzca secuencia de enteros: ");
            string aux = Console.ReadLine().Trim();
            string texto = eliminarSimbolos(aux);
            
            
            //Comprobamos los repetidos
            for (int i = 0; i < texto.Count(); i++)
            {
                
                contador = 0;
                for (int j = 0; j < texto.Count(); j++)
                {
                    
                    if (texto[i] == texto[j])
                    {
                        
                        contador++;
                    }
                }

                if (contador >= 2 && !repetidos.Contains(texto[i]))
                {
                    
                    repetidos.Add(texto[i]);
                }
            }
            
            //Mostramos por pantalla los repetidos
            Console.Write("\nDuplicados: ");
            for (int i = 0; i < repetidos.Count(); i++)
            {
                Console.Write(repetidos[i]);

                if (i < repetidos.Count() - 1)
                {
                    Console.Write(", ");
                }
            }
        }
    }
    
}

