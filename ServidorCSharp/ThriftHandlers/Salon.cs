using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftHandlers
{
    class Salon
    {
        public List<Conexion> Conectados { set; get; }
        public string DireccionMaestro { set; get; }

        public Salon()
        {
            Conectados = new List<Conexion>();
        }

        public void AgregarMaestro(Conexion maestro)
        {
            Conectados.Add(maestro);
            DireccionMaestro = maestro.DireccionIP;
        }

        public void AgregarAlumno(Conexion alumno)
        {
            Conectados.Add(alumno);
        }

        public void Remover(int idCuenta)
        {
            var indice = Conectados.FindIndex(c => c.IdCuenta.Equals(idCuenta));
            Conectados.RemoveAt(indice);
        }

        public List<string> ObtenerListaConectados()
        {
            List<string> usuariosConectados = new List<string>();
            foreach (var usuarioConectado in Conectados)
            {
                usuariosConectados.Add(usuarioConectado.Nombre);
            }
            return usuariosConectados;
        }
    }
}
