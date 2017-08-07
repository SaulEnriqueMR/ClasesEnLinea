using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftServices;
using ThriftStructs;

namespace ThriftHandlers
{
    public class ChatHandler : ChatService.Iface
    {
        public void enviarMensaje(TMensaje mensajeEnviado)
        {
            try
            {
                var salon = SalonDeClasesHandler.Salones.First(s => s.Key.Equals(mensajeEnviado.IdSalon)).Value;
                foreach(var conectado in salon.Conectados)
                {
                    conectado.ChatCallbackCliente.recibirMensaje(mensajeEnviado);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
