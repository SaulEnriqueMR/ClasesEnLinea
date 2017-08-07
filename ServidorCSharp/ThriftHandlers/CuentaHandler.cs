using BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftServices;
using ThriftStructs;

namespace ThriftHandlers
{
    public class CuentaHandler : CuentaService.Iface
    {

        /// <summary>
        /// Método que recibe credenciales de inicio de sesión de una cuenta y si esta existe permite el acceso
        /// </summary>
        /// <remarks>Hace uso del método "CifrarContraseña" de la clase de Utilidad</remarks>
        /// <param name="usuario">Usuario ingresado por el usuario</param>
        /// <param name="contrasena">Contraseña ingresada por el usuario</param>
        /// <returns></returns>
        public TCuenta iniciarSesion(string usuario, string contrasena)
        {
            var tCuentaResultado = new TCuenta();
            //contrasena = Utilidad.CifrarContrasena(contrasena);

            try
            {
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    var cuentasEncontradas = (from c in entidades.cuenta
                                            where c.usuario.Equals(usuario) && c.contrasena.Equals(contrasena)
                                            select c).Count();
                    if(cuentasEncontradas > 0)
                    {
                        var cuentaEncontrada = (from c in entidades.cuenta
                                                where c.usuario.Equals(usuario) && c.contrasena.Equals(contrasena)
                                                select c).First();
                        tCuentaResultado.IdCuenta = cuentaEncontrada.idCuenta;
                        tCuentaResultado.Nombre = cuentaEncontrada.nombre;
                        tCuentaResultado.Usuario = cuentaEncontrada.usuario;
                        tCuentaResultado.Contrasena = cuentaEncontrada.contrasena;
                        return tCuentaResultado;
                    }
                    else
                    {
                        tCuentaResultado.IdCuenta = 0;
                        tCuentaResultado.Nombre = "Vacio";
                        tCuentaResultado.Usuario = "Vacio";
                        tCuentaResultado.Contrasena = Utilidad.CifrarContrasena("vacio");
                    }
                    
                }    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                tCuentaResultado.IdCuenta = 0;
                tCuentaResultado.Nombre = "Error";
                tCuentaResultado.Usuario = "Error";
                tCuentaResultado.Contrasena = Utilidad.CifrarContrasena("error");
            }
            return tCuentaResultado;
        }

        /// <summary>
        /// Método que modifica una cuenta
        /// </summary>
        /// <remarks>Hace uso del método "CifrarContrasena" de la clase Utilidad</remarks>
        /// <param name="cuentaModificada">Cuenta que se va a modificar, excepto su id</param>
        /// <returns>Mensaje que informa de la modificacion de la cuenta</returns>
        public string modificarCuenta(TCuenta cuentaModificada)
        {
            string resultadoModificacion;
            //cuentaModificada.Contrasena = Utilidad.CifrarContrasena(cuentaModificada.Contrasena);

            try
            {
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    var cuentaParaModificar = (from c in entidades.cuenta
                                               where c.idCuenta == cuentaModificada.IdCuenta
                                               select c).First();

                    cuentaParaModificar.nombre = cuentaModificada.Nombre;
                    cuentaParaModificar.usuario = cuentaModificada.Usuario;
                    cuentaParaModificar.contrasena = cuentaModificada.Contrasena;

                    entidades.SaveChanges();

                    resultadoModificacion = "CuentaModificada";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                resultadoModificacion = "ErrorModificacion";
            }

            return resultadoModificacion;
        }

        /// <summary>
        /// Método que sirve para registrar una nueva cuenta en el sistema
        /// </summary>
        /// <remarks>
        /// Hace uso del método "CifrarContrasena" de la calse de Utilidad
        /// Hace uso del método "ExisteCuenta" de la clase de Utilidad
        /// </remarks>
        /// <param name="nuevaCuenta"></param>
        /// <returns></returns>
        public string registrarCuenta(TCuenta nuevaCuenta)
        {
            string resultadoRegistro;
            //var contrasenaCifrada = Utilidad.CifrarContrasena(nuevaCuenta.Contrasena);

            cuenta cuentaParaRegistrar = new cuenta
            {
                nombre = nuevaCuenta.Nombre,
                usuario = nuevaCuenta.Usuario,
                contrasena = nuevaCuenta.Contrasena,
            };

            if (!Utilidad.ExisteCuenta(cuentaParaRegistrar))
            {
                try
                {
                    using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                    {
                        entidades.cuenta.Add(cuentaParaRegistrar);
                        entidades.SaveChanges();
                        resultadoRegistro = "CuentaRegistrada";

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    resultadoRegistro = "ErrorRegistro";
                }
            }
            else
            {
                resultadoRegistro = "CuentaRepetida";
            }

            return resultadoRegistro;
        }
    }
}
