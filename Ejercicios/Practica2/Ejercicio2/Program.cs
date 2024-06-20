using System.Runtime.InteropServices.ComTypes;

namespace Ejercicio2
{
    using System;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Text;
    using System.Xml.Linq;
    
    class ejercicio2
    {
           static void Main(string[] args)
        {
            Console.WriteLine("Iniciando sistema de gestión de puerto...");

            // Crear una instancia de controlPuerto
            controlPuerto puerto = new controlPuerto();

            // Añadir camiones a la flota
            Console.WriteLine("\nAñadiendo camiones a la flota:");
            puerto.añadirCamion(new camion("pequeño"));
            puerto.añadirCamion(new camion("grande"));
            puerto.añadirCamion(new camion("pequeño"));
            puerto.añadirCamion(new camion("grande"));

            // Crear contenedores para el barco
            List<contenedor> contenedoresBarco1 = new List<contenedor>
            {
                new contenedor(800),
                new contenedor(1500),
                new contenedor(800),
                new contenedor(1500),
                new contenedor(800),
                new contenedor(800)
            };

            // Crear un barco con los contenedores
            Console.WriteLine("\nCreando barco con contenedores:");
            barco barco1 = new barco(contenedoresBarco1);
            Console.WriteLine($"Barco creado con {barco1.listaContenedores.Count} contenedores");

            // Distribuir los contenedores
            Console.WriteLine("\nDistribuyendo contenedores:");
            distribucion dist = puerto.distribuirContenedores(barco1);

            // Imprimir resultados de la distribución
            Console.WriteLine("\nResultados de la distribución:");
            foreach (var viaje in dist.Viajes)
            {
                Console.WriteLine($"\nViaje: {viaje.nombre}");
                foreach (var camion in viaje.ListaCamiones)
                {
                    Console.WriteLine($"  Camión {camion.tipoCamion}: {camion.contenedores.Count} contenedores, peso total: {camion.pesoActual}kg");
                    foreach (var contenedor in camion.contenedores)
                    {
                        Console.WriteLine($"    Contenedor: {contenedor.peso}kg");
                    }
                }
            }

            // Crear otro barco con más contenedores para una segunda prueba
            List<contenedor> contenedoresBarco2 = new List<contenedor>
            {
                new contenedor(800),
                new contenedor(1500),
                new contenedor(800),
                new contenedor(1500),
                new contenedor(800),
                new contenedor(800),
                new contenedor(1500),
                new contenedor(800)
            };

            Console.WriteLine("\nCreando segundo barco con más contenedores:");
            barco barco2 = new barco(contenedoresBarco2);
            Console.WriteLine($"Segundo barco creado con {barco2.listaContenedores.Count} contenedores");

            // Distribuir los contenedores del segundo barco
            Console.WriteLine("\nDistribuyendo contenedores del segundo barco:");
            distribucion dist2 = puerto.distribuirContenedores(barco2);

            // Imprimir resultados de la segunda distribución
            Console.WriteLine("\nResultados de la segunda distribución:");
            foreach (var viaje in dist2.Viajes)
            {
                Console.WriteLine($"\nViaje: {viaje.nombre}");
                foreach (var camion in viaje.ListaCamiones)
                {
                    Console.WriteLine($"  Camión {camion.tipoCamion}: {camion.contenedores.Count} contenedores, peso total: {camion.pesoActual}kg");
                    foreach (var contenedor in camion.contenedores)
                    {
                        Console.WriteLine($"    Contenedor: {contenedor.peso}kg");
                    }
                }
            }

            Console.WriteLine("\nPruebas completadas. Presione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }

    class contenedor
    {
        public double peso { get; }

        public contenedor(double peso)
        {
            this.peso = peso;
        }
    }

    class barco
    {
        public List<contenedor> listaContenedores = new List<contenedor>();

        public barco(List<contenedor> listaContenedores)
        {
            this.listaContenedores = listaContenedores;
        }
    }
    class camion
    {
        public string tipoCamion { get; }
        public double pesoKgCamion { get; }
        public double pesoActual { get; set; }
        public bool disponible { get; set; }
        public List<contenedor> contenedores { get; }

        public camion(string tipoCamion)
        {
            this.tipoCamion = tipoCamion;
            disponible = true;
            pesoActual = 0;
            contenedores = new List<contenedor>();

            if (tipoCamion == "pequeño")
            {
                this.pesoKgCamion = 1000;
            }
            else
            {
                this.pesoKgCamion = 2000;
            }
        }

        public bool puedeLLevar(contenedor c)
        {
            double pesoNuevo = pesoActual + c.peso;

            if (pesoNuevo >= pesoKgCamion)
            {
                return false;
            }

            return true;
        }

        public bool entraAlgunContenedorMas()
        {
            bool toRet = true;

            // Si en un camion grande hay un contenedor grande no entran mas.
            if (tipoCamion=="grande" && pesoActual==1500)
            {
                toRet = false;
            }
            //SI en un camion pequeño ya hay un contenedor no entran mas.
            else if( tipoCamion=="pequeño" && pesoActual!=0)
            {
                toRet = false;
            }

            return toRet;
        }
        public void añadirContenedor(contenedor c)
        {
            if (puedeLLevar(c))
            {
                contenedores.Add(c);
                pesoActual += c.peso;
            }
            else
            {
                Console.WriteLine($"No entra en el camion {c}");
            }
        }
    }

    class viaje
    {
        public List<camion> ListaCamiones;
        public string nombre { get; }

        public viaje(string nombre)
        {
            this.nombre = nombre;
            this.ListaCamiones = new List<camion>();
        }

        public void añadirCamion(camion c)
        {
            ListaCamiones.Add(c);
        }
        public void borrarCamion(camion c)
        {
            ListaCamiones.Remove(c);
        }
    }

    class controlPuerto
    {
        private List<camion> flotaCamiones;

        public controlPuerto()
        {
            flotaCamiones = new List<camion>();
            cargarDatosXML();
        }

        public void añadirCamion(camion c)
        {
            flotaCamiones.Add(c);
            guardarDatosXML();
        }

        public void borrarCamion(camion c)
        {
            flotaCamiones.Remove(c);
            guardarDatosXML();
        }

        public void cargarDatosXML()
        {
            if (File.Exists("datos_puerto.xml"))
            {
                XElement raiz = XElement.Load("datos_puerto.xml");
                flotaCamiones = raiz.Elements("Camion")
                    .Select(c => new camion(
                        (string)c.Element("tipoCamion")
                    )).ToList();
            }
        }

        public void guardarDatosXML()
        {
            var raiz = new XElement("FlotaCamiones",
                flotaCamiones.Select(c => new XElement("Camion",
                        new XElement("tipoCamion", c.tipoCamion),
                        new XElement("pesoKgCamion", c.pesoKgCamion),
                        new XElement("pesoActual", c.pesoActual)
                    )
                ));
            raiz.Save("datos_puerto.xml");
        }

        public distribucion distribuirContenedores(barco b)
        {
            distribucion dist = new distribucion();
            List<contenedor> contenedoresPendientes = new List<contenedor>(b.listaContenedores);
            viaje viajeNuevo = new viaje($"Viaje: {dist.Viajes.Count + 1}");


            while (contenedoresPendientes.Any())
            {
                //Reiniciamos todos los camiones
                foreach (camion c in flotaCamiones)
                {
                    c.disponible = true;
                    c.pesoActual = 0;
                    c.contenedores.Clear();
                }

                foreach (camion c in flotaCamiones)
                {
                    // Este camion esta disponible?
                    if (c.disponible)
                    {
                        foreach (contenedor contenedor in contenedoresPendientes.ToList())
                        {
                            // Este camion puede llevar este contenedor?
                            if (c.puedeLLevar(contenedor))
                            {
                                c.añadirContenedor(contenedor);
                                contenedoresPendientes.Remove(contenedor);
                                viajeNuevo.añadirCamion(c);



                                // Este camion puede llevar algun otro?
                                if (!c.entraAlgunContenedorMas())
                                {
                                    c.disponible = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            dist.Viajes.Add(viajeNuevo);

            guardarDistribucionXML(dist);
            return dist;
        }


        private void guardarDistribucionXML(distribucion dist)
        {
            var raiz = new XElement("Distribucion",
                dist.Viajes.Select(v => new XElement("Viaje",
                    new XAttribute("nombre", v.nombre),
                    v.ListaCamiones.Select(c => new XElement("Camion",
                        new XElement("tipoCamion", c.tipoCamion),
                        new XElement("pesoKgCamion", c.pesoKgCamion),
                        new XElement("pesoActual", c.pesoActual),
                        new XElement("Contenedores",
                            c.contenedores.Select(cont => new XElement("Contenedor",
                                new XElement("peso", cont.peso)
                            ))
                        )
                    ))
                ))
            );
            raiz.Save("distribucion.xml");
        }
    }
    class distribucion
    {
        public List<viaje> Viajes { get; set; } = new List<viaje>();
    }


}
    

