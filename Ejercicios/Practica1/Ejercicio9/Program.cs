namespace Ejercicio9
{
    using System;
    using System.Text.RegularExpressions;

    //Escribir un programa que acepte entradas como cadenas de texto. El programa debe reconocer los enteros positivos, los enteros negativos, los flotantes positivos,
    //los flotantes negativos, y debe hacer una salida ordenada de cada grupo de números. Se sugiere hacer una clase base Numero, para enteros y flotantes, y siendo los nodos
    //terminales de la jerarquía FlotantePositivo y FlotanteNegativo. Al menos debe haber un método abstracto en Numero, que sirva para imprimir cada tipo de número por pantalla.
    //El método estático Numero.Crea(s) debe crear el objeto de la clase adecuada según el parámetro s (cadena de caracteres), que se le pase.
    
    class ejercicio9
    {
        static void Main(string[] args)
        {
            int prueba;
            float prueba2;
            bool bandera = true;
            string valor;
            numero nuevoNumero;
            List<enteroPositivo> listaEnterosPositivos = new List<enteroPositivo>();
            List<enteroNegativo> listaEnterosNegativos = new List<enteroNegativo>();
            List<flotantePositivo> listaflotantesPositivos = new List<flotantePositivo>();
            List<flotanteNegativo> listaflotantesNegativos = new List<flotanteNegativo>();
            do
            {
                do
                {
                    Console.Write("Introduzca valor: ");
                    valor = Console.ReadLine().Trim();
                } while (!int.TryParse(valor, out prueba) && !float.TryParse(valor,out prueba2) && valor!="");
                

                if (valor == "")
                {
                    bandera = false;
                }
                else
                {
                    nuevoNumero = numero.crea(valor);
                    nuevoNumero.imprimirTipo();
                    if (nuevoNumero is enteroPositivo)
                    {
                        listaEnterosPositivos.Add((enteroPositivo)nuevoNumero);
                    } else if (nuevoNumero is enteroNegativo)
                    {
                        listaEnterosNegativos.Add((enteroNegativo)nuevoNumero);
                    } else if (nuevoNumero is flotantePositivo)
                    {
                        listaflotantesPositivos.Add((flotantePositivo)nuevoNumero);
                    } else 
                    {
                        listaflotantesNegativos.Add((flotanteNegativo)nuevoNumero);
                    }
                    
                    
                }
            } while (bandera);
            
            Console.WriteLine(" VOLCADO ");
            Console.Write("Enteros Positivos: ");
            for (int i = 0; i < listaEnterosPositivos.Count(); i++)
            {
                
                if (i == listaEnterosPositivos.Count() - 1)
                {
                    Console.Write(listaEnterosPositivos[i].valor);
                }
                else
                {
                    Console.Write(listaEnterosPositivos[i].valor+ ", ");
                }
            }
            Console.Write("\nEnteros Negativos: ");
            for (int i = 0; i < listaEnterosNegativos.Count(); i++)
            {
                if (i == listaEnterosNegativos.Count() - 1)
                {
                    Console.Write(listaEnterosNegativos[i].valor);
                }
                else
                {
                    Console.Write(listaEnterosNegativos[i].valor+ ", ");
                }
            }
            Console.Write("\nFlotantes Positivos: ");
            for (int i = 0; i < listaflotantesPositivos.Count(); i++)
            {
                if (i == listaflotantesPositivos.Count() - 1)
                {
                    Console.Write(listaflotantesPositivos[i].valor);
                }
                else
                {
                    Console.Write(listaflotantesPositivos[i].valor+ ", ");
                }
            }
            Console.Write("\nFlotantes Negativos: ");
            for (int i = 0; i < listaflotantesNegativos.Count(); i++)
            {
                if (i == listaflotantesNegativos.Count() - 1)
                {
                    Console.Write(listaflotantesNegativos[i].valor);
                }
                else
                {
                    Console.Write(listaflotantesNegativos[i].valor+ ", ");
                }
            }
        }
    }

    abstract class numero
    {
        public string valor { get; }
        
        /*public numero(string valor)
        {
            this.valor = valor;
        }*/

        public abstract void imprimirTipo();

        
        public static numero crea(string valor)
        {
            int auxEntero;
            float auxFlotante;
            if (int.TryParse(valor, out auxEntero))
            {
                if (auxEntero >= 0)
                {
                    enteroPositivo nuevo = new enteroPositivo(auxEntero);
                    return nuevo;
                }
                else
                {
                    enteroNegativo nuevo = new enteroNegativo(auxEntero);
                    return nuevo;
                }
                
            } else if (float.TryParse(valor, out auxFlotante))
            {
                if (auxFlotante >= 0.0)
                {
                    flotantePositivo nuevo = new flotantePositivo(auxFlotante);
                    return nuevo;
                }
                else
                {
                    flotanteNegativo nuevo = new flotanteNegativo(auxFlotante);
                    return nuevo;
                }
                
            }
            else
            {
                throw new Exception("Que ha pasado?");
            }
        }

    }

    class entero : numero
    {
        public int valor { get; set; }

        public entero(int valor)
        {
            this.valor = valor;
        }
        
        public override void imprimirTipo()
        {
            Console.WriteLine("entero");
        }
    }

    class enteroPositivo : entero
    {
        
        public enteroPositivo(int valor) : base(valor)
        {
            
        }
        public override void imprimirTipo()
        {
            Console.WriteLine("entero positivo");
        }
    }
    class enteroNegativo : entero
    {
        public enteroNegativo(int valor) : base(valor)
        {
            
        }
        public override void imprimirTipo()
        {
            Console.WriteLine("entero negativo");
        }
    }

    class flotante : numero
    {
        public float valor { get; set; }

        public flotante(float valor)
        {
            this.valor = valor;
        }

        public override void imprimirTipo()
        {
            Console.WriteLine("flotante");
        }
    }

    class flotantePositivo : flotante
    {
       

        public flotantePositivo(float valor) :  base(valor)
        {
            
        }
        public override void imprimirTipo()
        {
            Console.WriteLine("flotante positivo");
        }
    }
    
    class flotanteNegativo : flotante
    {
       

        public flotanteNegativo(float valor) :  base(valor)
        {
            
        }
        public override void imprimirTipo()
        {
            Console.WriteLine("flotante negativo");
        }
    }
}

