using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using ThriftHandlers;
using ThriftServices;

namespace ServidorCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Iniciando servidor...");

                var handlerCuenta = new CuentaHandler();
                var handlerExperienciaEducativa = new ExperienciaEducativaHandler();
                var handlerSalonDeClases = new SalonDeClasesHandler();
                var handlerChat = new ChatHandler();
                var handlerPresentacion = new PresentacionHandler();

                var processorCuenta = new CuentaService.Processor(handlerCuenta);
                var processorExperienciaEducativa = new ExperienciaEducativaService.Processor(handlerExperienciaEducativa);
                var processorSalonDeClases = new SalonDeClasesService.Processor(handlerSalonDeClases);
                var processorChat = new ChatService.Processor(handlerChat);
                var processorPresentacion = new PresentacionService.Processor(handlerPresentacion);

                var processor = new TMultiplexedProcessor();

                processor.RegisterProcessor(nameof(CuentaService), processorCuenta);
                processor.RegisterProcessor(nameof(ExperienciaEducativaService), processorExperienciaEducativa);
                processor.RegisterProcessor(nameof(SalonDeClasesService), processorSalonDeClases);
                processor.RegisterProcessor(nameof(ChatService), processorChat);
                processor.RegisterProcessor(nameof(PresentacionService), processorPresentacion);

                TServerTransport transporte = new TServerSocket(9090);
                TServer servidor = new TThreadPoolServer(processor, transporte);
                Console.WriteLine("Servidor iniciado...");
                servidor.Serve();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.Read();
            }
        }
    }
}
