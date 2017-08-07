using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftStructs;

namespace ThriftServices
{
    public partial class PresentacionService
    {
        public interface ISync
        {
            void enviarPresentacion(TPresentacion tPresentacion);
            void avanzarDiapositiva(int idSalon);
            void regresarDiapositiva(int idSalon);
        }

        public interface Iface : ISync
        {
#if SILVERLIGHT
      IAsyncResult Begin_enviarPresentacion(AsyncCallback callback, object state, TPresentacion tPresentacion);
      void End_enviarPresentacion(IAsyncResult asyncResult);
#endif
#if SILVERLIGHT
      IAsyncResult Begin_avanzarDiapositiva(AsyncCallback callback, object state, int idSalon);
      void End_avanzarDiapositiva(IAsyncResult asyncResult);
#endif
#if SILVERLIGHT
      IAsyncResult Begin_regresarDiapositiva(AsyncCallback callback, object state, int idSalon);
      void End_regresarDiapositiva(IAsyncResult asyncResult);
#endif
        }

        public class Client : IDisposable, Iface
        {
            public Client(TProtocol prot) : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                iprot_ = iprot;
                oprot_ = oprot;
            }

            protected TProtocol iprot_;
            protected TProtocol oprot_;
            protected int seqid_;

            public TProtocol InputProtocol
            {
                get { return iprot_; }
            }
            public TProtocol OutputProtocol
            {
                get { return oprot_; }
            }


            #region " IDisposable Support "
            private bool _IsDisposed;

            // IDisposable
            public void Dispose()
            {
                Dispose(true);
            }


            protected virtual void Dispose(bool disposing)
            {
                if (!_IsDisposed)
                {
                    if (disposing)
                    {
                        if (iprot_ != null)
                        {
                            ((IDisposable)iprot_).Dispose();
                        }
                        if (oprot_ != null)
                        {
                            ((IDisposable)oprot_).Dispose();
                        }
                    }
                }
                _IsDisposed = true;
            }
            #endregion



#if SILVERLIGHT
      public IAsyncResult Begin_enviarPresentacion(AsyncCallback callback, object state, TPresentacion tPresentacion)
      {
        return send_enviarPresentacion(callback, state, tPresentacion);
      }

      public void End_enviarPresentacion(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void enviarPresentacion(TPresentacion tPresentacion)
            {
#if !SILVERLIGHT
                send_enviarPresentacion(tPresentacion);

#else
        var asyncResult = Begin_enviarPresentacion(null, null, tPresentacion);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_enviarPresentacion(AsyncCallback callback, object state, TPresentacion tPresentacion)
#else
            public void send_enviarPresentacion(TPresentacion tPresentacion)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("enviarPresentacion", TMessageType.Oneway, seqid_));
                enviarPresentacion_args args = new enviarPresentacion_args();
                args.TPresentacion = tPresentacion;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }


#if SILVERLIGHT
      public IAsyncResult Begin_avanzarDiapositiva(AsyncCallback callback, object state, int idSalon)
      {
        return send_avanzarDiapositiva(callback, state, idSalon);
      }

      public void End_avanzarDiapositiva(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void avanzarDiapositiva(int idSalon)
            {
#if !SILVERLIGHT
                send_avanzarDiapositiva(idSalon);

#else
        var asyncResult = Begin_avanzarDiapositiva(null, null, idSalon);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_avanzarDiapositiva(AsyncCallback callback, object state, int idSalon)
#else
            public void send_avanzarDiapositiva(int idSalon)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("avanzarDiapositiva", TMessageType.Oneway, seqid_));
                avanzarDiapositiva_args args = new avanzarDiapositiva_args();
                args.IdSalon = idSalon;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }


#if SILVERLIGHT
      public IAsyncResult Begin_regresarDiapositiva(AsyncCallback callback, object state, int idSalon)
      {
        return send_regresarDiapositiva(callback, state, idSalon);
      }

      public void End_regresarDiapositiva(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void regresarDiapositiva(int idSalon)
            {
#if !SILVERLIGHT
                send_regresarDiapositiva(idSalon);

#else
        var asyncResult = Begin_regresarDiapositiva(null, null, idSalon);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_regresarDiapositiva(AsyncCallback callback, object state, int idSalon)
#else
            public void send_regresarDiapositiva(int idSalon)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("regresarDiapositiva", TMessageType.Oneway, seqid_));
                regresarDiapositiva_args args = new regresarDiapositiva_args();
                args.IdSalon = idSalon;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

        }
        public class Processor : TProcessor
        {
            public Processor(ISync iface)
            {
                iface_ = iface;
                processMap_["enviarPresentacion"] = enviarPresentacion_Process;
                processMap_["avanzarDiapositiva"] = avanzarDiapositiva_Process;
                processMap_["regresarDiapositiva"] = regresarDiapositiva_Process;
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
            private ISync iface_;
            protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage msg = iprot.ReadMessageBegin();
                    ProcessFunction fn;
                    processMap_.TryGetValue(msg.Name, out fn);
                    if (fn == null)
                    {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        TApplicationException x = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                        x.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    fn(msg.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void enviarPresentacion_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                enviarPresentacion_args args = new enviarPresentacion_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.enviarPresentacion(args.TPresentacion);
                }
                catch (TTransportException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error occurred in processor:");
                    Console.Error.WriteLine(ex.ToString());
                }
            }

            public void avanzarDiapositiva_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                avanzarDiapositiva_args args = new avanzarDiapositiva_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.avanzarDiapositiva(args.IdSalon);
                }
                catch (TTransportException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error occurred in processor:");
                    Console.Error.WriteLine(ex.ToString());
                }
            }

            public void regresarDiapositiva_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                regresarDiapositiva_args args = new regresarDiapositiva_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.regresarDiapositiva(args.IdSalon);
                }
                catch (TTransportException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error occurred in processor:");
                    Console.Error.WriteLine(ex.ToString());
                }
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class enviarPresentacion_args : TBase
        {
            private TPresentacion _tPresentacion;

            public TPresentacion TPresentacion
            {
                get
                {
                    return _tPresentacion;
                }
                set
                {
                    __isset.tPresentacion = true;
                    this._tPresentacion = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool tPresentacion;
            }

            public enviarPresentacion_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.Struct)
                                {
                                    TPresentacion = new TPresentacion();
                                    TPresentacion.Read(iprot);
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("enviarPresentacion_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (TPresentacion != null && __isset.tPresentacion)
                    {
                        field.Name = "tPresentacion";
                        field.Type = TType.Struct;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        TPresentacion.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("enviarPresentacion_args(");
                bool __first = true;
                if (TPresentacion != null && __isset.tPresentacion)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("TPresentacion: ");
                    __sb.Append(TPresentacion == null ? "<null>" : TPresentacion.ToString());
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class avanzarDiapositiva_args : TBase
        {
            private int _idSalon;

            public int IdSalon
            {
                get
                {
                    return _idSalon;
                }
                set
                {
                    __isset.idSalon = true;
                    this._idSalon = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool idSalon;
            }

            public avanzarDiapositiva_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.I32)
                                {
                                    IdSalon = iprot.ReadI32();
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("avanzarDiapositiva_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (__isset.idSalon)
                    {
                        field.Name = "idSalon";
                        field.Type = TType.I32;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(IdSalon);
                        oprot.WriteFieldEnd();
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("avanzarDiapositiva_args(");
                bool __first = true;
                if (__isset.idSalon)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("IdSalon: ");
                    __sb.Append(IdSalon);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class regresarDiapositiva_args : TBase
        {
            private int _idSalon;

            public int IdSalon
            {
                get
                {
                    return _idSalon;
                }
                set
                {
                    __isset.idSalon = true;
                    this._idSalon = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool idSalon;
            }

            public regresarDiapositiva_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.I32)
                                {
                                    IdSalon = iprot.ReadI32();
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("regresarDiapositiva_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (__isset.idSalon)
                    {
                        field.Name = "idSalon";
                        field.Type = TType.I32;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(IdSalon);
                        oprot.WriteFieldEnd();
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("regresarDiapositiva_args(");
                bool __first = true;
                if (__isset.idSalon)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("IdSalon: ");
                    __sb.Append(IdSalon);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }

    }
}
