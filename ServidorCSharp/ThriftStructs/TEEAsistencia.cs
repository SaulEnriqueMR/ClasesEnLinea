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

namespace ThriftStructs
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class TEEAsistencia : TBase
  {
    private int _idEEAsistencia;
    private int _ideeimpartida;
    private int _idcuenta;

    public int IdEEAsistencia
    {
      get
      {
        return _idEEAsistencia;
      }
      set
      {
        __isset.idEEAsistencia = true;
        this._idEEAsistencia = value;
      }
    }

    public int Ideeimpartida
    {
      get
      {
        return _ideeimpartida;
      }
      set
      {
        __isset.ideeimpartida = true;
        this._ideeimpartida = value;
      }
    }

    public int Idcuenta
    {
      get
      {
        return _idcuenta;
      }
      set
      {
        __isset.idcuenta = true;
        this._idcuenta = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool idEEAsistencia;
      public bool ideeimpartida;
      public bool idcuenta;
    }

    public TEEAsistencia() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                IdEEAsistencia = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                Ideeimpartida = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                Idcuenta = iprot.ReadI32();
              } else { 
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

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("TEEAsistencia");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.idEEAsistencia) {
          field.Name = "idEEAsistencia";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(IdEEAsistencia);
          oprot.WriteFieldEnd();
        }
        if (__isset.ideeimpartida) {
          field.Name = "ideeimpartida";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Ideeimpartida);
          oprot.WriteFieldEnd();
        }
        if (__isset.idcuenta) {
          field.Name = "idcuenta";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Idcuenta);
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

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("TEEAsistencia(");
      bool __first = true;
      if (__isset.idEEAsistencia) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IdEEAsistencia: ");
        __sb.Append(IdEEAsistencia);
      }
      if (__isset.ideeimpartida) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Ideeimpartida: ");
        __sb.Append(Ideeimpartida);
      }
      if (__isset.idcuenta) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Idcuenta: ");
        __sb.Append(Idcuenta);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
