namespace Ejercicio2
{
    using System;

    class ejercicio2
    {
        static void Main(string[] args)
        {
            bool bandera = false;
            int conteoIntentos;
            string respuesta;
            string seguir;
            int respuestaEntero;
            Random rnd = new Random();
            int solucion;
            
            
            Console.WriteLine("########### MASTER MIND ############");
            do
            {
                conteoIntentos = 0;
                solucion = rnd.Next(1,6);
                Console.WriteLine(solucion);
                do
                {
                    do
                    {
                        Console.Write("Adivina el número: ");
                        respuesta = Console.ReadLine().Trim();
                        Console.WriteLine("skibidi");
                    } while (!int.TryParse(respuesta, out respuestaEntero));
                
                    if (respuestaEntero == solucion)
                    {
                        conteoIntentos++;
                        bandera = true;
                        Console.WriteLine("Has ganado!!!!!!!!");
                    }
                    else
                    {
                        Console.WriteLine("El numero " + respuesta + " es incorrecto");
                        conteoIntentos++;
                    }
                } while (bandera == false);
                
            Console.WriteLine("Te ha llevado " +conteoIntentos+ " intentos.");
            Console.WriteLine("Quieres seguir jugando(S/N)?");
            seguir = Console.ReadLine().Trim().ToUpper();
            } while (seguir[0]=='S');
            
        }

    }
    
    
    
}

