using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftServices;
using ThriftStructs;

namespace ThriftHandlers
{
    public class PresentacionHandler : PresentacionService.Iface
    {
        public void avanzarDiapositiva(int idSalon)
        {
            var salon = SalonDeClasesHandler.Salones.First(s => s.Key.Equals(idSalon)).Value;
            var conexiones = salon.Conectados;
            foreach (var conectado in conexiones)
            {
                conectado.PresentacionCallbackCliente.enAvanzarDiapositiva();
            }
        }

        public void enviarPresentacion(TPresentacion tPresentacion)
        {
            var idSalon = tPresentacion.IdSalon;
            var salon = SalonDeClasesHandler.Salones.First(s => s.Key.Equals(idSalon)).Value;
            var conexiones = salon.Conectados;
            foreach(var conectado in conexiones)
            {
                conectado.PresentacionCallbackCliente.recibirPresentacion(tPresentacion);
            }
        }

        public void regresarDiapositiva(int idSalon)
        {
            var salon = SalonDeClasesHandler.Salones.First(s => s.Key.Equals(idSalon)).Value;
            var conexiones = salon.Conectados;
            foreach (var conectado in conexiones)
            {
                conectado.PresentacionCallbackCliente.enRegresarDiapositiva();
            }
        }
    }
}
