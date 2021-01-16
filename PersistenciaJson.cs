using Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace DAL
{
    [Export(typeof(IGrabador))]
    public class PersistenciaJson : IGrabador
    {
        public bool Grabar(Estudiante estudiante)
        {
            try
            {
                estudiante.IdEstudiante = new Random().Next(1000, 9999);

                {
                    var data = string.Format("{{\"EstudianteId\":{0}, \"Nombre\":{1},\"Apellido\":{2}}}",
                               estudiante.IdEstudiante.ToString(),
                               estudiante.NombreEstudiante,
                               estudiante.ApellidoEstudiante);
                    System.IO.File.AppendAllLines("Data.json",
                   new List<string>
                   {
                       data
                   },
                    Encoding.UTF8);
                }
            }

            catch
            {
                return false;
            }
            return true;

        }
    }
}

