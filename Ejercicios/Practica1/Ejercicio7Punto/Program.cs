namespace Ejercicio7Punto
{
    using System;
    using System.Text.RegularExpressions;

    // Crea la clase Punto. Esta clase contendrá propiedades de solo lectura para las coordenadas X e Y. Debe proporcionar también un método ToString()
    // , y un objeto estático llamado Centro, con las coordenadas 0, 0. Crea la clase Linea. Estará compuesta por dos objetos Punto, el inicio y el final.
    // Debe soportar también un método ToString(), y dos propiedades de solo lectura que devuelvan el inicio y el final. Cree un programa que pida cuatro coordenadas,
    // cree dos objetos Punto y un objeto Linea, y visualice los tres por pantalla.
    
    class ejercicio7Punto
    {
        static void Main(string[] args)
        {
            int x, y;
            
            Console.WriteLine("Punto 1");
            Console.Write("\nCoordenada X: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Coordenada Y: ");
            y = Convert.ToInt32(Console.ReadLine());

            Punto inicio = new Punto(x, y);
            
            Console.WriteLine("\nPunto 2");
            Console.Write("\nCoordenada X: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Coordenada Y: ");
            y = Convert.ToInt32(Console.ReadLine());

            Punto final = new Punto(x, y);

            Linea linea = new Linea(inicio, final);
            
            Console.WriteLine("Volcado");
            Console.WriteLine(inicio.ToString());
            Console.WriteLine(final.ToString());
            Console.WriteLine(linea.ToString());

        }
    }

    class Punto
    {
        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Punto Centro = new Punto(0, 0);
        
        public int y { get; }
        public int x { get; }

        // Con lambdasv '=>'
        public override string ToString() => $"({this.x}, {this.y})";
    }

    class Linea
    {
        public Punto inicio { get; }
        public Punto final { get; }

        public Linea(Punto inicio, Punto final)
        {
            this.inicio = inicio;
            this.final = final;
        }
        
        public override string ToString()
        {
            return this.inicio.ToString() + " - " + this.final.ToString();
        }
    }
}

