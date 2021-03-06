/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftCallbacks
{
    public partial class SalonDeClasesCallback
    {
        public interface ISync
        {
            void actualizarConectados(List<string> conectados);
            void recibirDireccionMaestro(string direccionIPMaestro);
            void enExpulsion();
        }

        public interface Iface : ISync
        {
#if SILVERLIGHT
      IAsyncResult Begin_actualizarConectados(AsyncCallback callback, object state, List<string> conectados);
      void End_actualizarConectados(IAsyncResult asyncResult);
#endif
#if SILVERLIGHT
      IAsyncResult Begin_recibirDireccionMaestro(AsyncCallback callback, object state, string direccionIPMaestro);
      void End_recibirDireccionMaestro(IAsyncResult asyncResult);
#endif
#if SILVERLIGHT
      IAsyncResult Begin_enExpulsion(AsyncCallback callback, object state);
      void End_enExpulsion(IAsyncResult asyncResult);
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
      public IAsyncResult Begin_actualizarConectados(AsyncCallback callback, object state, List<string> conectados)
      {
        return send_actualizarConectados(callback, state, conectados);
      }

      public void End_actualizarConectados(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void actualizarConectados(List<string> conectados)
            {
#if !SILVERLIGHT
                send_actualizarConectados(conectados);

#else
        var asyncResult = Begin_actualizarConectados(null, null, conectados);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_actualizarConectados(AsyncCallback callback, object state, List<string> conectados)
#else
            public void send_actualizarConectados(List<string> conectados)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("actualizarConectados", TMessageType.Oneway, seqid_));
                actualizarConectados_args args = new actualizarConectados_args();
                args.Conectados = conectados;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }


#if SILVERLIGHT
      public IAsyncResult Begin_recibirDireccionMaestro(AsyncCallback callback, object state, string direccionIPMaestro)
      {
        return send_recibirDireccionMaestro(callback, state, direccionIPMaestro);
      }

      public void End_recibirDireccionMaestro(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void recibirDireccionMaestro(string direccionIPMaestro)
            {
#if !SILVERLIGHT
                send_recibirDireccionMaestro(direccionIPMaestro);

#else
        var asyncResult = Begin_recibirDireccionMaestro(null, null, direccionIPMaestro);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_recibirDireccionMaestro(AsyncCallback callback, object state, string direccionIPMaestro)
#else
            public void send_recibirDireccionMaestro(string direccionIPMaestro)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("recibirDireccionMaestro", TMessageType.Oneway, seqid_));
                recibirDireccionMaestro_args args = new recibirDireccionMaestro_args();
                args.DireccionIPMaestro = direccionIPMaestro;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }


#if SILVERLIGHT
      public IAsyncResult Begin_enExpulsion(AsyncCallback callback, object state)
      {
        return send_enExpulsion(callback, state);
      }

      public void End_enExpulsion(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
      }

#endif

            public void enExpulsion()
            {
#if !SILVERLIGHT
                send_enExpulsion();

#else
        var asyncResult = Begin_enExpulsion(null, null);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_enExpulsion(AsyncCallback callback, object state)
#else
            public void send_enExpulsion()
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("enExpulsion", TMessageType.Oneway, seqid_));
                enExpulsion_args args = new enExpulsion_args();
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
                processMap_["actualizarConectados"] = actualizarConectados_Process;
                processMap_["recibirDireccionMaestro"] = recibirDireccionMaestro_Process;
                processMap_["enExpulsion"] = enExpulsion_Process;
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

            public void actualizarConectados_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                actualizarConectados_args args = new actualizarConectados_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.actualizarConectados(args.Conectados);
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

            public void recibirDireccionMaestro_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                recibirDireccionMaestro_args args = new recibirDireccionMaestro_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.recibirDireccionMaestro(args.DireccionIPMaestro);
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

            public void enExpulsion_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                enExpulsion_args args = new enExpulsion_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                try
                {
                    iface_.enExpulsion();
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
        public partial class actualizarConectados_args : TBase
        {
            private List<string> _conectados;

            public List<string> Conectados
            {
                get
                {
                    return _conectados;
                }
                set
                {
                    __isset.conectados = true;
                    this._conectados = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool conectados;
            }

            public actualizarConectados_args()
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
                                if (field.Type == TType.List)
                                {
                                    {
                                        Conectados = new List<string>();
                                        TList _list0 = iprot.ReadListBegin();
                                        for (int _i1 = 0; _i1 < _list0.Count; ++_i1)
                                        {
                                            string _elem2;
                                            _elem2 = iprot.ReadString();
                                            Conectados.Add(_elem2);
                                        }
                                        iprot.ReadListEnd();
                                    }
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
                    TStruct struc = new TStruct("actualizarConectados_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (Conectados != null && __isset.conectados)
                    {
                        field.Name = "conectados";
                        field.Type = TType.List;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        {
                            oprot.WriteListBegin(new TList(TType.String, Conectados.Count));
                            foreach (string _iter3 in Conectados)
                            {
                                oprot.WriteString(_iter3);
                            }
                            oprot.WriteListEnd();
                        }
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
                StringBuilder __sb = new StringBuilder("actualizarConectados_args(");
                bool __first = true;
                if (Conectados != null && __isset.conectados)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("Conectados: ");
                    __sb.Append(Conectados);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class recibirDireccionMaestro_args : TBase
        {
            private string _direccionIPMaestro;

            public string DireccionIPMaestro
            {
                get
                {
                    return _direccionIPMaestro;
                }
                set
                {
                    __isset.direccionIPMaestro = true;
                    this._direccionIPMaestro = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool direccionIPMaestro;
            }

            public recibirDireccionMaestro_args()
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
                                if (field.Type == TType.String)
                                {
                                    DireccionIPMaestro = iprot.ReadString();
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
                    TStruct struc = new TStruct("recibirDireccionMaestro_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (DireccionIPMaestro != null && __isset.direccionIPMaestro)
                    {
                        field.Name = "direccionIPMaestro";
                        field.Type = TType.String;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteString(DireccionIPMaestro);
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
                StringBuilder __sb = new StringBuilder("recibirDireccionMaestro_args(");
                bool __first = true;
                if (DireccionIPMaestro != null && __isset.direccionIPMaestro)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("DireccionIPMaestro: ");
                    __sb.Append(DireccionIPMaestro);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class enExpulsion_args : TBase
        {

            public enExpulsion_args()
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
                    TStruct struc = new TStruct("enExpulsion_args");
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
                StringBuilder __sb = new StringBuilder("enExpulsion_args(");
                __sb.Append(")");
                return __sb.ToString();
            }

        }
    }
}
