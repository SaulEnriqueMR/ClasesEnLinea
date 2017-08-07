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

namespace ThriftCallbacks
{
    public partial class PresentacionCallback
    {
        public interface ISync
        {
            void recibirPresentacion(TPresentacion tPresentacion);
            void enAvanzarDiapositiva();
            void enRegresarDiapositiva();
        }

        public interface Iface : ISync
        {
#if SILVERLIGHT
      IAsyncResult Begin_recibirPresentacion(AsyncCallback callback, object state, TPresentacion tPresentacion);
      void End_recibirPresentacion(IAsyncResult asyncResult);
#endif
#if SILVERLIGHT
      IAsyncResult Begin_enAvanzarDiapositiva(AsyncCallback callback, object state);
      void End_enAvanzarDiapositiva(IAsyncResult asyncResult);
#endif
#if SILVERLIGHT
      IAsyncResult Begin_enRegresarDiapositiva(AsyncCallback callback, object state);
      void End_enRegresarDiapositiva(IAsyncResult asyncResult);
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
      public IAsyncResult Begin_recibirPresentacion(AsyncCallback callback, object state, TPresentacion tPresentacion)
      {
        return send_recibirPresentacion(callback, state, tPresentacion);
      }

      public void End_recibirPresentacion(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void recibirPresentacion(TPresentacion tPresentacion)
            {
#if !SILVERLIGHT
                send_recibirPresentacion(tPresentacion);

#else
        var asyncResult = Begin_recibirPresentacion(null, null, tPresentacion);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_recibirPresentacion(AsyncCallback callback, object state, TPresentacion tPresentacion)
#else
            public void send_recibirPresentacion(TPresentacion tPresentacion)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("recibirPresentacion", TMessageType.Oneway, seqid_));
                recibirPresentacion_args args = new recibirPresentacion_args();
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
      public IAsyncResult Begin_enAvanzarDiapositiva(AsyncCallback callback, object state)
      {
        return send_enAvanzarDiapositiva(callback, state);
      }

      public void End_enAvanzarDiapositiva(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void enAvanzarDiapositiva()
            {
#if !SILVERLIGHT
                send_enAvanzarDiapositiva();

#else
        var asyncResult = Begin_enAvanzarDiapositiva(null, null);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_enAvanzarDiapositiva(AsyncCallback callback, object state)
#else
            public void send_enAvanzarDiapositiva()
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("enAvanzarDiapositiva", TMessageType.Oneway, seqid_));
                enAvanzarDiapositiva_args args = new enAvanzarDiapositiva_args();
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }


#if SILVERLIGHT
      public IAsyncResult Begin_enRegresarDiapositiva(AsyncCallback callback, object state)
      {
        return send_enRegresarDiapositiva(callback, state);
      }

      public void End_enRegresarDiapositiva(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void enRegresarDiapositiva()
            {
#if !SILVERLIGHT
                send_enRegresarDiapositiva();

#else
        var asyncResult = Begin_enRegresarDiapositiva(null, null);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_enRegresarDiapositiva(AsyncCallback callback, object state)
#else
            public void send_enRegresarDiapositiva()
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("enRegresarDiapositiva", TMessageType.Oneway, seqid_));
                enRegresarDiapositiva_args args = new enRegresarDiapositiva_args();
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
                processMap_["recibirPresentacion"] = recibirPresentacion_Process;
                processMap_["enAvanzarDiapositiva"] = enAvanzarDiapositiva_Process;
                processMap_["enRegresarDiapositiva"] = enRegresarDiapositiva_Process;
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

            public void recibirPresentacion_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                recibirPresentacion_args args = new recibirPresentacion_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.recibirPresentacion(args.TPresentacion);
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

            public void enAvanzarDiapositiva_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                enAvanzarDiapositiva_args args = new enAvanzarDiapositiva_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.enAvanzarDiapositiva();
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

            public void enRegresarDiapositiva_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                enRegresarDiapositiva_args args = new enRegresarDiapositiva_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.enRegresarDiapositiva();
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
        public partial class recibirPresentacion_args : TBase
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

            public recibirPresentacion_args()
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
                    TStruct struc = new TStruct("recibirPresentacion_args");
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
                StringBuilder __sb = new StringBuilder("recibirPresentacion_args(");
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
        public partial class enAvanzarDiapositiva_args : TBase
        {

            public enAvanzarDiapositiva_args()
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
                    TStruct struc = new TStruct("enAvanzarDiapositiva_args");
                    oprot.WriteStructBegin(struc);
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
                StringBuilder __sb = new StringBuilder("enAvanzarDiapositiva_args(");
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class enRegresarDiapositiva_args : TBase
        {

            public enRegresarDiapositiva_args()
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
                    TStruct struc = new TStruct("enRegresarDiapositiva_args");
                    oprot.WriteStructBegin(struc);
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
                StringBuilder __sb = new StringBuilder("enRegresarDiapositiva_args(");
                __sb.Append(")");
                return __sb.ToString();
            }

        }

    }
}
