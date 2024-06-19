using System.Runtime.Serialization.Json;

namespace Ejercicio1
{
    using System;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Text;
    using System.Xml.Linq;
    
    //Una tienda de reparaciones de electrónica tiene distintos tipos de aparatos contemplados para su reparación: Radios, Televisores, Reproductores de DVD y adaptadores de TDT,
    //cada uno con su tarifa de reparación por hora (5, 10, 10 y 5 euros, respectivamente). De todos los aparatos se guarda su nº de serie, su modelo y su precio de reparación por hora.
    //De las radios se guardan las bandas que es capaz de manejar (AM/FM o ambas), de los televisores sus pulgadas, de los reproductores de DVD si reproducen Blue-Ray y también si graban o no,
    //y en su caso el tiempo de grabación; y de los adaptadores de TDT el tiempo máximo de grabación si la soporta. Una reparación toma el precio por horas para el aparato, y lo aplica en
    //segmentos de media hora, haciendo la oportuna conversión. Si la reparación lleva una hora o menos, se considera sustitución de piezas, y se respeta el precio por hora estipulado para
    //el aparato. En caso de superar la hora, entonces se trata de una reparación compleja, y se cobra aplicando un sobreprecio del 25% a los precios por hora trabajada asignados para
    //cada aparato. Todas las reparaciones tienen un precio base de 10€, y el precio de las piezas se cobra aparte de las horas trabajadas. Debe haber una jerarquía de clases para los aparatos
    //y para las reparaciones. Las reparaciones creadas serán guardadas automáticamente en reparaciones.xml al finalizar la ejecución, y recuperados, de existir el fichero, al finalizarla. Debe
    //haber una jerarquía de clases para los aparatos y para las reparaciones. Las reparaciones creadas serán guardadas automáticamente en reparaciones.xml al finalizar la ejecución, y
    //recuperados, de existir el fichero, al finalizarla.
    
    class ejercicio1
    {
        private static List<reparacion> reparaciones = new List<reparacion>();
        
        static void Main(string[] args)
        {
            cargarDatos();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("########### Menu Principal ############");
                Console.WriteLine("1. Nueva Reparacion");
                Console.WriteLine("2. Mostrar Reparaciones");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        añadirReparacion();
                        break;
                    case "2":
                        mostrarReparaciones();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default: Console.WriteLine("Opcion Invalida...");
                        break;
                }
            }
            guardarDatos();
        }

        public static void añadirReparacion()
        {
            string numSerie;
            string modelo;
            bool bandaAM;
            bool bandaFM;
            bool grava;
            bool bluray;
            double pulgadas, tiempo, precioPiezas, tiempoMaxGrabaTDT, tiempoGrabaDVD;
            bool bandera = false;
            reparacion r;
            while (!bandera)
            {
                Console.WriteLine("\nQue aparato se va a reparar?");
                Console.WriteLine("1. Radio");
                Console.WriteLine("2. TV");
                Console.WriteLine("3. DVD");
                Console.WriteLine("4. TDT");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion: ");
                
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Introduce el numero de serie: ");
                        numSerie = Console.ReadLine();
                        Console.Write("Introduce el modelo: ");
                        modelo = Console.ReadLine();
                        Console.Write("Acepta Bandas AM?: ");
                        bandaAM = bool.Parse(Console.ReadLine());
                        Console.Write("Acepta Bandas FM?: ");
                        bandaFM = bool.Parse(Console.ReadLine());
                        Console.Write("Cuanto tiempo ha durardo la reparacion: ");
                        tiempo = double.Parse(Console.ReadLine());
                        Console.Write("Cuanto han costado las piezas: ");
                        precioPiezas = double.Parse(Console.ReadLine());
                        
                        radio nuevaRadio = new radio(modelo, numSerie, bandaAM, bandaFM);
                        r = new reparacion(tiempo, nuevaRadio, precioPiezas);
                        reparaciones.Add(r);
                        break;
                    case "2":
                        Console.Write("Introduce el numero de serie: ");
                        numSerie = Console.ReadLine();
                        Console.Write("Introduce el modelo: ");
                        modelo = Console.ReadLine();
                        Console.Write("Introduzca las pulgadas: ");
                        pulgadas = Double.Parse(Console.ReadLine());
                        Console.Write("Cuanto tiempo ha durardo la reparacion: ");
                        tiempo = double.Parse(Console.ReadLine());
                        Console.Write("Cuanto han costado las piezas: ");
                        precioPiezas = double.Parse(Console.ReadLine());
                        
                        television nuevaTV = new television(modelo, numSerie, pulgadas);
                        r = new reparacion(tiempo, nuevaTV, precioPiezas);
                        reparaciones.Add(r);
                        break;
                    case "3":
                        Console.Write("Introduce el numero de serie: ");
                        numSerie = Console.ReadLine();
                        Console.Write("Introduce el modelo: ");
                        modelo = Console.ReadLine();
                        Console.Write("Acepta blurays?: ");
                        bluray = bool.Parse(Console.ReadLine());
                        Console.Write("Es capaz de grabar?: ");
                        grava = bool.Parse(Console.ReadLine());
                        Console.Write("Durante cuanto tiempo graba?: ");
                        tiempoGrabaDVD = double.Parse(Console.ReadLine());
                        Console.Write("Cuanto tiempo ha durardo la reparacion: ");
                        tiempo = double.Parse(Console.ReadLine());
                        Console.Write("Cuanto han costado las piezas: ");
                        precioPiezas = double.Parse(Console.ReadLine());
                        
                        dvd nuevoDVD = new dvd(modelo, numSerie, bluray, grava, tiempoGrabaDVD);
                        r = new reparacion(tiempo, nuevoDVD, precioPiezas);
                        reparaciones.Add(r);
                        break;
                    case "4":
                        Console.Write("Introduce el numero de serie: ");
                        numSerie = Console.ReadLine();
                        Console.Write("Introduce el modelo: ");
                        modelo = Console.ReadLine();
                        Console.Write("Es capaz de grabar?: ");
                        grava = bool.Parse(Console.ReadLine());
                        Console.Write("Durante cuanto tiempo graba?: ");
                        tiempoMaxGrabaTDT = double.Parse(Console.ReadLine());
                        Console.Write("Cuanto tiempo ha durardo la reparacion: ");
                        tiempo = double.Parse(Console.ReadLine());
                        Console.Write("Cuanto han costado las piezas: ");
                        precioPiezas = double.Parse(Console.ReadLine());
                        
                        tdt nuevoTDT = new tdt(modelo, numSerie,grava, tiempoMaxGrabaTDT);
                        r = new reparacion(tiempo, nuevoTDT, precioPiezas);
                        reparaciones.Add(r);
                        break;
                    case "5":
                        bandera = true;
                        break;
                    default: Console.WriteLine("Opcion Invalida...");
                        break;
                }
            }

        }
         
        public static void mostrarReparaciones()
        {
            Console.WriteLine("########### Lista de Reparaciones ############");
            for (int i = 0; i < reparaciones.Count; i++)
            {
                Console.WriteLine($"Modelo: {reparaciones[i].aparato.modelo}");
                Console.WriteLine($"Tiempo: {reparaciones[i].tiempo}");
                Console.WriteLine($"Precio Piezas: {reparaciones[i].precioPiezas}");
                Console.WriteLine($"Precio Final: {reparaciones[i].precioReparacionFinal}");
               
            }
        }   
        public static void guardarDatos()
        {
            var raiz = new XElement("Reparaciones",
                from aux in reparaciones
                select new XElement("Reparacion",
                    new XElement("Aparato",
                        new XElement("NumeroSerie", aux.aparato.numeroSerie),
                        new XElement("Modelo", aux.aparato.modelo),
                        new XElement("TarifaReparacion", aux.aparato.tarifaReparacion),
                        aux.aparato is radio ? new XElement("BandaAM", ((radio)aux.aparato).bandaAM): null,
                        aux.aparato is radio ? new XElement("BandaFM", ((radio)aux.aparato).bandaFM): null,
                        aux.aparato is television ? new XElement("Pulgadas", ((television)aux.aparato).pulgadas):null,
                        aux.aparato is dvd ? new XElement("Bluray", ((dvd)aux.aparato).bluray):null,
                        aux.aparato is dvd ? new XElement("Graba", ((dvd)aux.aparato).graba):null,
                        aux.aparato is dvd ? new XElement("TiempoGrabacion", ((dvd)aux.aparato).tiempoGrabacion):null,
                        aux.aparato is tdt ? new XElement("GrabaTDT", ((tdt)aux.aparato).grabaTDT):null,
                        aux.aparato is tdt ? new XElement("TiempoGrabacion", ((tdt)aux.aparato).tiempoMaxGrabacion):null
                        ),
                    
                    new XElement("Tiempo", aux.tiempo),
                    new XElement("PrecioPiezas", aux.precioPiezas)
                )
            );
            
            raiz.Save("reparaciones.xml");
        }

        public static void cargarDatos()
        {
            if (File.Exists("reparaciones.xml"))
            {
                XElement raiz = XElement.Load("reparaciones.xml");
                reparaciones = (from aux in raiz.Elements("Reparacion")
                    select new reparacion
                    (
                        (double)aux.Element("Tiempo"),
                        crearAparato(aux.Element("Aparato")),
                        (double)aux.Element("PrecioPiezas")
                    )).ToList();
            }
        }
        private static aparatoElectronico crearAparato(XElement aparato)
        {
            string numeroSerie = (string)aparato.Element("NumeroSerie");
            string modelo = (string)aparato.Element("Modelo");
            string tarifaReparacion = (string)aparato.Element("TarifaReparacion");

            if (aparato.Element("BandaAM") is not null && aparato.Element("BandaFM") is not null)
            {
                bool bandaAM = (bool)aparato.Element("BandaAM");
                bool bandaFM = (bool)aparato.Element("BandaFM");

                radio r = new radio(modelo, numeroSerie, bandaAM, bandaFM);
                return r;
            } else if (aparato.Element("Pulgadas") is not null)
            {
                double pulgadas = (double)aparato.Element("Pulgadas");
                
                television t = new television(modelo, numeroSerie, pulgadas);
                return t;
            }  else if (aparato.Element("Bluray") is not null && aparato.Element("Graba") is not null && aparato.Element("TiempoGrabacion") is not null)
            {
                bool bluray = (bool)aparato.Element("Bluray");
                bool graba = (bool)aparato.Element("Graba");
                double tiempoGrabacion = (double)aparato.Element("TiempoGrabacion");
                
                dvd d = new dvd(modelo, numeroSerie, bluray, graba, tiempoGrabacion);
                return d;
            }
            else if (aparato.Element("GrabaTDT") is not null && aparato.Element("TiempoGrabacion") is not null)
            {
                bool grabaTDT = (bool)aparato.Element("GrabaTDT");
                double tiempoGrabacion = (double)aparato.Element("TiempoGrabacion");
                tdt td = new tdt(modelo, numeroSerie, grabaTDT, tiempoGrabacion);
                return td;
            }
            else
            {
                throw new Exception("ha pasado algo ");
            }
        }
    }
    
    

    class reparacion
    {
        public double tiempo { get; set; }
        public aparatoElectronico aparato { get; set; }
        public const double precioReparacionBASE = 10;
        public double precioReparacionFinal { get; set; }
        public double precioPiezas { get; set; }
        public reparacion(double tiempo, aparatoElectronico aparato, double precioPiezas)
        {
            this.tiempo = tiempo;
            this.aparato = aparato;
            this.precioPiezas = precioPiezas;
            calcularPrecioFinal();
        }

        public void calcularPrecioFinal()
        {
            if (tiempo <= 1)
            {
                //sustitucion de piezas
                precioReparacionFinal = precioReparacionBASE + (aparato.tarifaReparacion*tiempo) + precioPiezas;
            }
            else
            {
                //reparacion compleja +%25
                precioReparacionFinal = precioReparacionBASE + (aparato.tarifaReparacion * 1.25 * tiempo) + precioPiezas;
            }
        }
    }

    /*class sustitucionPiezas : reparacion
    {
        public sustitucionPiezas(int tiempo) : base(tiempo)
        {
            
        }
    }

    class reparacionCompleja : reparacion
    {
        public reparacionCompleja(int tiempo) : base(tiempo)
        {
            
        }
    }*/
    abstract class aparatoElectronico
    {
        
        public string modelo { get; set; }
        public string numeroSerie { get; set; }
        public double tarifaReparacion { get; set; }

        public aparatoElectronico(string modelo, string numeroSerie, double tarifaReparacion)
        {
            this.modelo = modelo;
            this.numeroSerie = numeroSerie;
            this.tarifaReparacion = tarifaReparacion;
        }
    }
    
    class radio : aparatoElectronico
    {
        public bool bandaAM { get; set; }
        public bool bandaFM { get; set; }
        public radio(string modelo, string numeroSerie, bool bandaAM, bool bandaFM): base(modelo, numeroSerie,5)
        {
            this.bandaAM = bandaAM;
            this.bandaFM = bandaFM;
        }
    }

    class television : aparatoElectronico
    {
        public double pulgadas { get; set; }
        public television(string modelo, string numeroSerie, double pulgadas): base(modelo, numeroSerie,10)
        {
            this.pulgadas = pulgadas;
        }
    }
    
    class dvd : aparatoElectronico
    {
        public bool bluray { get; set; }
        public bool graba { get; set; }
        public double tiempoGrabacion { get; set; }
        
        public dvd(string modelo, string numeroSerie, bool bluray, bool graba, double tiempoGrabacion): base(modelo, numeroSerie,10)
        {
            this.bluray = bluray;
            this.graba = graba;

            if (graba)
            {
                this.tiempoGrabacion = tiempoGrabacion;
            }
        }
    }
    
    class tdt : aparatoElectronico
    {
        public bool grabaTDT { get; set; }
        public double tiempoMaxGrabacion { get; set; }
        
        public tdt(string modelo, string numeroSerie, bool grabaTDT, double tiempoMaxGrabacion): base(modelo, numeroSerie,5)
        {
            this.grabaTDT = grabaTDT;
            
            if (grabaTDT)
            {
                this.tiempoMaxGrabacion = tiempoMaxGrabacion;
            }
        }
    }
}


