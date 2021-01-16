using Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace DAL
{
    [Export(typeof(IGrabador))]
    public class PersistenciaCsv : IGrabador
    {
        public bool Grabar(Estudiante estudiante)
        {
            try
            {
                estudiante.IdEstudiante = new Random().Next(1000, 9999);
                System.IO.File.AppendAllLines("Data.txt",
                    new List<string>
                    {
                    string.Format("{0},{1},{2}",
                    estudiante.IdEstudiante.ToString(),
                    estudiante.NombreEstudiante,
                    estudiante.ApellidoEstudiante)
                    },
                    Encoding.UTF8);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

}