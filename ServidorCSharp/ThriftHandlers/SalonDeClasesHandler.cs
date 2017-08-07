using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftServices;
using ThriftStructs;

namespace ThriftHandlers
{
    public class SalonDeClasesHandler : SalonDeClasesService.Iface
    {
        //Diccionario <idSalon, Diccionario<idCuenta, Conexion>>
        private static Dictionary<int, Salon> salones = new Dictionary<int, Salon>();

        internal static Dictionary<int, Salon> Salones { get => salones; set => salones = value; }

        public string abrirSalon(int idCuenta, int idSalon)
        {
            string resultadoAbrir;
            if(!Salones.ContainsKey(idSalon) && Utilidad.EsMaestro(idCuenta, idSalon))
            {
                var nuevoSalon = new Salon();
                Salones.Add(idSalon, nuevoSalon);
                resultadoAbrir = "ExitoAbrirSalon";
            }
            else
            {
                if (Salones.ContainsKey(idSalon))
                {
                    resultadoAbrir = "SalonAbierto";
                }
                else
                {
                   resultadoAbrir = "NoEresMaestro";
                }
            }
            return resultadoAbrir;
        }

        public List<string> actualizarLista(int idSalon)
        {
            var salon = Salones.First(s => s.Key.Equals(idSalon)).Value;
            var nombresConectados = salon.ObtenerListaConectados();
            return nombresConectados;
        }

        public void expulsar(int idSalon, int idMaestro, string nombre)
        {
            var salon = Salones.First(s => s.Key.Equals(idSalon)).Value;
            var conexion = salon.Conectados.First(c => c.Nombre.Equals(nombre));
            var idExpulsado = conexion.IdCuenta;
            if (!idMaestro.Equals(idExpulsado))
            {
                conexion.SalonCallbackCliente.enExpulsion();
                MandarContactos(idSalon);
            }
        }

        public void MandarContactos(int idSalon)
        {
            var salon = Salones.First(s => s.Key.Equals(idSalon)).Value;
            var conectados = salon.Conectados;
            var nombres = salon.ObtenerListaConectados();
            foreach(var conectado in conectados)
            {
                conectado.SalonCallbackCliente.actualizarConectados(nombres);
            }
        }

        public void salirSalon(int idSalon, int idCuenta)
        {
            var salon = Salones.First(s => s.Key.Equals(idSalon)).Value;
            salon.Remover(idCuenta);
            if(salon.Conectados.Count == 0)
            {
                Salones.Remove(idSalon);
            }
            else
            {
                MandarContactos(idSalon);
            }
            
        }

        public string unirseSalon(TConexion tConexion)
        {
            string resultado;
            try
            {
                Conexion nuevaConexion = new Conexion(tConexion);
                if (Utilidad.EsMaestro(tConexion.IdCuenta, tConexion.IdSalon))
                {
                    var salon = Salones.First(s => s.Key.Equals(tConexion.IdSalon)).Value;
                    salon.AgregarMaestro(nuevaConexion);
                    resultado = "ExitoUnirMaestro";
                    MandarContactos(tConexion.IdSalon);
                }
                else
                {
                    var salon = Salones.First(s => s.Key.Equals(tConexion.IdSalon)).Value;
                    salon.AgregarAlumno(nuevaConexion);
                    resultado = "ExitoUnirAlumno";
                    actualizarLista(tConexion.IdSalon);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                resultado = "ErrorUnir";  
            }
            return resultado;
        }

    }
}
