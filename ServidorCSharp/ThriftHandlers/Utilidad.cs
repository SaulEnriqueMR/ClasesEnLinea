using BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftHandlers
{
    public class Utilidad
    {
        
        /// <summary>
        /// Método que verifica si una cuenta ya existe.
        /// </summary>
        /// <remarks>Verifica que no haya un usuario con el mismo nombre o usuario</remarks>
        /// <param name="cuentaAVerificar">Cuenta que se va a verificar su existencia</param>
        /// <returns>Retorna si la cuenta existe o no</returns>
        public static bool ExisteCuenta(cuenta cuentaAVerificar)
        {
            bool existe = true;

            using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
            {
            //Bloque que verifica que no haya dos cuenta con el mismo nombre
            var usuariosCoincidentes = (from c in entidades.cuenta
                                        where c.nombre.Equals(cuentaAVerificar.nombre)
                                        select c).Count();

            if (usuariosCoincidentes == 0)
            {
                existe = false;
            }

            //Bloque que verifica que no haya dos cuenta con el mismo usuario
            usuariosCoincidentes = (from c in entidades.cuenta
                                            where c.usuario.Equals(cuentaAVerificar.usuario)
                                            select c).Count();

            if (usuariosCoincidentes == 0)
            {
                existe = false;
            }
        }


            return existe;
        }

        /// <summary>
        /// Método que verifica si una ee ya existe.
        /// </summary>
        /// <param name="eeAVerificar">EE que se va a verificar su existencia</param>
        /// <returns>Retorna si la ee existe o no</returns>
        public static bool ExisteEE(experienciaeducativa eeAVerificar)
        {
            bool existe = true;
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    var eeCoincidentes = (from ee in entidades.experienciaeducativa
                                          where ee.nombre.Equals(eeAVerificar.nombre)
                                          select ee).Count();
                    if (eeCoincidentes == 0)
                    {
                        existe = false;
                    }

                }
            
            return existe;
        }

        /// <summary>
        /// Cifra una constraseña ingresada por el usuario.
        /// </summary>
        /// <param name="contrasena">Contraseña que se va a codificar</param>
        /// <returns>Regresa la contraseña ingresada pero códificada</returns>
        public static string CifrarContrasena(string contrasena)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(contrasena), 0, Encoding.UTF8.GetByteCount(contrasena));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        /// <summary>
        /// Verifica que un estudiante no esté registrado doble en una misma EEImpartida.
        /// </summary>
        /// <param name="eeaAVerificar">EEA que se va a verificar.</param>
        /// <returns>Retorna si esta EEA existe o no.</returns>
        public static bool ExisteEEA(eeasistencia eeaAVerificar)
        {
            bool existe = true;

            using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
            {
                var eeaCoincidentes = (from eea in entidades.eeasistencia
                                            where eea.idEEImpartida.Equals(eeaAVerificar.idEEImpartida) && eea.idCuenta.Equals(eeaAVerificar.idCuenta)
                                            select eea).Count();

                if (eeaCoincidentes == 0)
                {
                    existe = false;
                }
            }

            return existe;
        }

        /// <summary>
        /// Verifica que un maestro no de una misma experiencia educativa al mismo tiempo.
        /// </summary>
        /// <param name="eeiAVerificar">EEI que se va a verificar.</param>
        /// <returns>Retorna si existe o no esa EEI.</returns>
        public static bool ExisteEEI(eeimpartida eeiAVerificar)
        {
            bool existe = true;

            using(ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
            {
                var eeiCoincidentes = (from eei in entidades.eeimpartida
                                       where eei.idCuenta.Equals(eeiAVerificar.idCuenta) && eei.idEE.Equals(eeiAVerificar.idEE)
                                       select eei).Count();
                if(eeiCoincidentes == 0)
                {
                    existe = false;
                }
            }

            return existe;
        }

        /// <summary>
        /// Método que nos dice si una cuenta es maestro de una experiencia educativa
        /// </summary>
        /// <param name="idCuenta">Cuenta que se va a verificar</param>
        /// <param name="idEEImpartida">Experiencia Educativa Impartida que se va a verificar que exista</param>
        /// <returns></returns>
        public static bool EsMaestro(int idCuenta, int idEEImpartida)
        {
            bool esMaestro = true;
            using(ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
            {
                var experienciaImpartida = (from eei in entidades.eeimpartida
                                            where eei.idCuenta.Equals(idCuenta) && eei.idEEImpartida.Equals(idEEImpartida)
                                            select eei).Count();
                if(experienciaImpartida == 0)
                {
                    esMaestro = false;
                }
            }
            return esMaestro;
        }
    }
}
