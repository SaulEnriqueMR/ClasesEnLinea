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
  public partial class TExperienciaEducativa : TBase
  {
    private int _idExperienciaEducativa;
    private string _nombre;

    public int IdExperienciaEducativa
    {
      get
      {
        return _idExperienciaEducativa;
      }
      set
      {
        __isset.idExperienciaEducativa = true;
        this._idExperienciaEducativa = value;
      }
    }

    public string Nombre
    {
      get
      {
        return _nombre;
      }
      set
      {
        __isset.nombre = true;
        this._nombre = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool idExperienciaEducativa;
      public bool nombre;
    }

    public TExperienciaEducativa() {
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
                IdExperienciaEducativa = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Nombre = iprot.ReadString();
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
        TStruct struc = new TStruct("TExperienciaEducativa");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.idExperienciaEducativa) {
          field.Name = "idExperienciaEducativa";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(IdExperienciaEducativa);
          oprot.WriteFieldEnd();
        }
        if (Nombre != null && __isset.nombre) {
          field.Name = "nombre";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Nombre);
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
      StringBuilder __sb = new StringBuilder("TExperienciaEducativa(");
      bool __first = true;
      if (__isset.idExperienciaEducativa) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IdExperienciaEducativa: ");
        __sb.Append(IdExperienciaEducativa);
      }
      if (Nombre != null && __isset.nombre) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Nombre: ");
        __sb.Append(Nombre);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
