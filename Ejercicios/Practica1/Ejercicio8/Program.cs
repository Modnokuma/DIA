namespace Ejercicio8
{
    using System;
    using System.Text.RegularExpressions;
    //Supondremos que existe una representación canónica de números de teléfono que sigue el siguiente formato: 999-999 99 99. En realidad, es posible encontrar números de teléfono
    //con varios formatos, por ejemplo, con letras en lugar de números. Estas letras se asocian a los números de la siguiente forma:
    //2 = ABC  3 = DEF 4 = GHI 5 = JKL 6 = MNO 7 = PQRS 8 = TUV 9 = WXYZ
    //Así, el número de teléfono GAL 2323BE es en su representación canónica: 425-23 23 23. Crear un programa que acepte números de teléfono (hasta detectar la cadena vacía) y
    //los convierta a sus representaciones canónicas, visualizándolas por consola, y con un asterisco a continuación en caso de que estén repetidas con respecto a las ya introducidas.
    //Utilice una clase para representar los números de teléfono, y sobrecargue el método ToString() para generar la versión canónica
    
    class ejercicio8
    {
        
        static void Main(string[] args)
        {
            List<telefono> listaTelefonos = new List<telefono>();
            bool bandera = false;
            
            while (!bandera)
            {
                    Console.Write("Introduzca un tlf. formato libre: ");
                    string cadena = Console.ReadLine().Trim();
                    //cadena = cadena.Replace(" ", "");
                    cadena = eliminarCaracteres(cadena);
                    if (cadena == "")
                    {
                        bandera = true;
                    }
                    else
                    {
                        telefono numeroTelf = new telefono(cadena);
                        // Por defecto, el método Contains de la lista utiliza la comparación por referencia, lo que significa que solo considerará iguales a los objetos que sean exactamente
                        // la misma instancia.
                       // if (!listaTelefonos.Contains(numeroTelf.)) 
                        if (!listaTelefonos.Any(t=> t.numTelefono == numeroTelf.numTelefono))
                        {
                            Console.WriteLine("1");
                            listaTelefonos.Add(numeroTelf);
                            Console.WriteLine(numeroTelf.ToString());
                        }
                        else
                        {
                            Console.WriteLine("2");
                            Console.WriteLine(numeroTelf.ToString() + " *");
                        }
                    }
            }

            for (int i = 0; i < listaTelefonos.Count; i++)
            {
                Console.WriteLine(listaTelefonos[i]);
            }
        }
        static string eliminarCaracteres(string texto)
        {
            texto = Regex.Replace(texto, @"[^0-9a-zA-Z]", "");
            return texto;
        }
    }

    class telefono
    {
        private Dictionary<char,int> dic = new Dictionary<char, int>();
        
        
        public string numTelefono { get; set; }

        public telefono(string numTelefono)
        {
            this.numTelefono = numTelefono;
            cargarDiccionario();
            obtenerNumeroReal();
        }

        private void cargarDiccionario()
        {
            dic.Add('A',2);
            dic.Add('B',2);
            dic.Add('C',2);
            dic.Add('D',3);
            dic.Add('E',3);
            dic.Add('F',3);
            dic.Add('G',4);
            dic.Add('H',4);
            dic.Add('I',4);
            dic.Add('J',5);
            dic.Add('K',5);
            dic.Add('L',5);
            dic.Add('M',6);
            dic.Add('N',6);
            dic.Add('O',6);
            dic.Add('P',7);
            dic.Add('Q',7);
            dic.Add('R',7);
            dic.Add('S',8);
            dic.Add('T',8);
            dic.Add('U',8);
            dic.Add('V',9);
            dic.Add('X',9);
            dic.Add('Y',9);
            dic.Add('Z',9);
        }

        private void obtenerNumeroReal()
        {
            string aux = String.Empty;
            //¿Porque 9 y no numTelf.Count? Porque si introduces mas de 9 estaria mal
            for (int i = 0; i < 9; i++)
            {
                //por cada char del numTelefono se pasa por el diccionario [SI ESTA EN EL DIC] y se obtiene el real
                if (dic.ContainsKey(numTelefono[i]))
                {
                    aux += dic[numTelefono[i]];
                }
                else
                {
                    aux += numTelefono[i];
                }
                
                
            }
            //Tras obtener el num.tlfo real lo guardamos
            numTelefono = aux;
        }
        public override string ToString()
        {
            string toRet = String.Empty;
           
            
            for (int i = 0; i < numTelefono.Count(); i++)
            {
                if (i == 3)
                {
                    toRet+= "-" + numTelefono[i]; 
                }

                else if (i == 5 || i == 7)
                {
                    toRet+= " " + numTelefono[i];
                }
                else
                {
                    toRet += numTelefono[i];
                }
            }
            return toRet;
        }
    }
}

