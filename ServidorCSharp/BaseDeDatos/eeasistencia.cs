//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseDeDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class eeasistencia
    {
        public int idEEAsistencia { get; set; }
        public int idEEImpartida { get; set; }
        public int idCuenta { get; set; }
    
        public virtual cuenta cuenta { get; set; }
        public virtual eeimpartida eeimpartida { get; set; }
    }
}
