using System;
using DALMarisol;
using Entities;
using Interface;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace DALMarisol
{
    class Program
    {
        readonly CompositionContainer contenedor;
        private Program ()
            {
            var catalogo = new AggregateCatalog();
            catalogo.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            contenedor = new CompositionContainer(catalogo);
            this.contenedor.ComposeParts(this);
        }

        [Import(typeof(IGrabador))]
        public static IGrabador PersistenciaCsv{ get; set; }
        public static IGrabador persistenciaJson;

        static void Main(string[] args)
        {
            var programa = new Program();
            programa.RealizarTrabajo();
        }

        private void RealizarTrabajo()
        {
            Console.WriteLine("Inversion de control");

            var estudiante = new Estudiante
            {
                NombreEstudiante = "Marina",
                ApellidoEstudiante = "Valarezo"
            };


            if (PersistenciaCsv.Grabar(estudiante))
            {
                Console.WriteLine("Se grabo!");
            }
        }

       
        }

    }

