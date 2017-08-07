using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftServices;

namespace ClienteCSharp
{
    class Conexion
    {
        public static TSocket Transporte;
        public static TBinaryProtocol ProtocoloBinario;

        public static TMultiplexedProtocol CuentaServiceProtocolo;
        public static TMultiplexedProtocol ExperienciaEducativaServiceProtocolo;
        public static TMultiplexedProtocol SalonDeClasesServiceProtocolo;
        public static TMultiplexedProtocol ChatServiceProtocolo;
        public static TMultiplexedProtocol PresentacionServiceProtocolo;

        public static CuentaService.Client CuentaServiceCliente;
        public static ExperienciaEducativaService.Client ExperienciaEducativaServiceCliente;
        public static SalonDeClasesService.Client SalonDeClasesServiceCliente;
        public static ChatService.Client ChatServiceCliente;
        public static PresentacionService.Client PresentacionServiceCliente;

        public static bool EstaConectado = false;

        public static void Conectar()
        {
            Transporte = new TSocket("localhost", 9090);
            Transporte.Open();

            ProtocoloBinario = new TBinaryProtocol(Transporte);

            CuentaServiceProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(CuentaService));
            ExperienciaEducativaServiceProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(ExperienciaEducativaService));
            SalonDeClasesServiceProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(SalonDeClasesService));
            ChatServiceProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(ChatService));
            PresentacionServiceProtocolo = new TMultiplexedProtocol(ProtocoloBinario, nameof(PresentacionService));

            CuentaServiceCliente = new CuentaService.Client(CuentaServiceProtocolo);
            ExperienciaEducativaServiceCliente = new ExperienciaEducativaService.Client(ExperienciaEducativaServiceProtocolo);
            SalonDeClasesServiceCliente = new SalonDeClasesService.Client(SalonDeClasesServiceProtocolo);
            ChatServiceCliente = new ChatService.Client(ChatServiceProtocolo);
            PresentacionServiceCliente = new PresentacionService.Client(PresentacionServiceProtocolo);

            EstaConectado = true;
        }
    }
}
