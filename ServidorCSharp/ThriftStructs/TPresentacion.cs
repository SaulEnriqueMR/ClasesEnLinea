using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;

namespace ThriftStructs
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TPresentacion : TBase
    {
        private List<string> _diapositiva;
        private int _idSalon;

        public List<string> Diapositiva
        {
            get
            {
                return _diapositiva;
            }
            set
            {
                __isset.diapositiva = true;
                this._diapositiva = value;
            }
        }

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
            public bool diapositiva;
            public bool idSalon;
        }

        public TPresentacion()
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
                                    Diapositiva = new List<string>();
                                    TList _list0 = iprot.ReadListBegin();
                                    for (int _i1 = 0; _i1 < _list0.Count; ++_i1)
                                    {
                                        string _elem2;
                                        _elem2 = iprot.ReadString();
                                        Diapositiva.Add(_elem2);
                                    }
                                    iprot.ReadListEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 2:
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
                TStruct struc = new TStruct("TPresentacion");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (Diapositiva != null && __isset.diapositiva)
                {
                    field.Name = "diapositiva";
                    field.Type = TType.List;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    {
                        oprot.WriteListBegin(new TList(TType.String, Diapositiva.Count));
                        foreach (string _iter3 in Diapositiva)
                        {
                            oprot.WriteString(_iter3);
                        }
                        oprot.WriteListEnd();
                    }
                    oprot.WriteFieldEnd();
                }
                if (__isset.idSalon)
                {
                    field.Name = "idSalon";
                    field.Type = TType.I32;
                    field.ID = 2;
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
            StringBuilder __sb = new StringBuilder("TPresentacion(");
            bool __first = true;
            if (Diapositiva != null && __isset.diapositiva)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Diapositiva: ");
                __sb.Append(Diapositiva);
            }
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