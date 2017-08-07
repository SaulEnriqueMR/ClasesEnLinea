using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftCallbacks;
using ThriftStructs;

namespace ThriftHandlers
{
    class Conexion
    {
        public TSocket Transporte;
        public TBinaryProtocol ProtocoloBinario { set; get; }

        public TMultiplexedProtocol ChatCallbackProtocolo { set; get; }
        public TMultiplexedProtocol SalonCallbackProtocolo { set; get; }
        public TMultiplexedProtocol PresentacionCallbackProtocolo { set; get; }

        public ChatCallback.Client ChatCallbackCliente { set; get; }
        public SalonDeClasesCallback.Client SalonCallbackCliente { set; get; }
        public PresentacionCallback.Client PresentacionCallbackCliente { set; get; }

        public string DireccionIP { set; get; }
        public int IdCuenta { set; get; }
        public string Nombre { set; get; }

        public Conexion(TConexion conexion)
        {
            DireccionIP = conexion.DireccionIP;
            IdCuenta = conexion.IdCuenta;
            Transporte = new TSocket(DireccionIP, 9091);
            Transporte.Open();

            ProtocoloBinario = new TBinaryProtocol(Transporte);

            ChatCallbackProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(ChatCallback));
            SalonCallbackProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(SalonDeClasesCallback));
            PresentacionCallbackProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(PresentacionCallback));

            ChatCallbackCliente = new ChatCallback.Client(ChatCallbackProtocolo);
            SalonCallbackCliente = new SalonDeClasesCallback.Client(SalonCallbackProtocolo);
            PresentacionCallbackCliente = new PresentacionCallback.Client(PresentacionCallbackProtocolo);

            Nombre = conexion.Nombre;
        }
    }
}
