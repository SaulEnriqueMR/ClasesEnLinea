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
    public class ExperienciaEducativaHandler : ExperienciaEducativaService.Iface
    {
        /// <summary>
        /// Método que obtiene todas las EE registradas.
        /// </summary>
        /// <remarks>Este método será utilizado cuando se quiera registrar una ee para impartir.</remarks>
        /// <returns>Retorna el resultado del registro.</returns>
        public List<TExperienciaEducativa> obtenerEE()
        {
            List<TExperienciaEducativa> tExperienciasEducativas = new List<TExperienciaEducativa>();
            List<experienciaeducativa> experienciasEducativas = new List<experienciaeducativa>();

            try
            {
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    experienciasEducativas = (from ee in entidades.experienciaeducativa select ee).ToList();
                }

                if (experienciasEducativas.Count > 0)
                {
                    foreach (var ee in experienciasEducativas)
                    {
                        var tEE = new TExperienciaEducativa
                        {
                            IdExperienciaEducativa = ee.idExperienciaEducativa,
                            Nombre = ee.nombre
                        };
                        tExperienciasEducativas.Add(tEE);
                    }
                }
                else
                {
                    var tEE = new TExperienciaEducativa
                    {
                        IdExperienciaEducativa = 0,
                        Nombre = "Vacio"
                    };
                    tExperienciasEducativas.Add(tEE);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                TExperienciaEducativa experienciaError = new TExperienciaEducativa
                {
                    IdExperienciaEducativa = 0,
                    Nombre = "Error",
                };
                tExperienciasEducativas.Add(experienciaError);
            }
            return tExperienciasEducativas;
        }

        /// <summary>
        /// Método que obtiene todas las eeasistencia.
        /// </summary>
        /// <remarks>Este método será utilizado cuando se quiera saber a cuales ee está asistiendo.</remarks>
        /// <param name="idCuenta">id de la cuenta que se va a consultar.</param>
        /// <returns>Retorna lista de estructuras TEEAsistenciaView</returns>
        public List<TEEAsistenciaView> obtenerEEAsistencia(int idCuenta)
        {
            List<TEEAsistenciaView> tEEAsistidas = new List<TEEAsistenciaView>();
            List<eeasistenciaview> eeAsistidas = new List<eeasistenciaview>();

            try
            {
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    eeAsistidas = (from eea in entidades.eeasistenciaview
                                      where eea.idCuenta.Equals(idCuenta)
                                      select eea).ToList();
                }

                if (eeAsistidas.Count > 0)
                {
                    foreach (var eea in eeAsistidas)
                    {
                        TEEAsistenciaView teea = new TEEAsistenciaView
                        {
                            IdEEImpartida = eea.idEEImpartida,
                            Ee = eea.ee,
                            Maestro = eea.maestro,
                            IdCuenta = eea.idCuenta
                        };
                        tEEAsistidas.Add(teea);
                    }
                }
                else
                {
                    TEEAsistenciaView tEEAVacia = new TEEAsistenciaView
                    {
                        IdEEImpartida = 0,
                        Ee = "Vacio",
                        Maestro = "Vacio",
                        IdCuenta = 0
                    };
                    tEEAsistidas.Add(tEEAVacia);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                TEEAsistenciaView tEEAError = new TEEAsistenciaView
                {
                    IdCuenta = 0,
                    IdEEImpartida = 0,
                    Ee = "Error",
                    Maestro = "Error"
                };
                tEEAsistidas.Add(tEEAError);
            }

            return tEEAsistidas;
        }

        /// <summary>
        /// Método que obtiene las ee que imparte una persona.
        /// </summary>
        /// <remarks>Este método será utilizado en la ventana principal para saber cuales ee imparte.</remarks>
        /// <param name="idCuenta">id de la cuenta que se va a consultar.</param>
        /// <returns>Retorna lista de estructuras TEEImpartidas.</returns>
        public List<TEEImpartidaView> obtenerEEImpartidas(int idCuenta)
        {
            List<TEEImpartidaView> tEEImpartidas = new List<TEEImpartidaView>();
            List<eeimpartidaview> eeImpartidas = new List<eeimpartidaview>();

            try
            {
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    eeImpartidas = (from eei in entidades.eeimpartidaview
                                    where eei.idCuenta.Equals(idCuenta)
                                    select eei).ToList();
                }

                if (eeImpartidas.Count > 0)
                {
                    foreach (var eei in eeImpartidas)
                    {
                        var tEEI = new TEEImpartidaView
                        {
                            IdEEImpartida = eei.idEEImpartida,
                            Ee = eei.ee,
                            Maestro = eei.maestro,
                            IdCuenta = eei.idCuenta
                        };
                        tEEImpartidas.Add(tEEI);
                    }
                }
                else
                {
                    var tEEIVacia = new TEEImpartidaView
                    {
                        IdEEImpartida = 0,
                        Ee = "Vacio",
                        Maestro = "Vacio",
                        IdCuenta = 0
                    };
                    tEEImpartidas.Add(tEEIVacia);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                var tEEIError = new TEEImpartidaView
                {
                    IdEEImpartida = 0,
                    Ee = "Error",
                    Maestro = "Error",
                    IdCuenta = 0
                };
                tEEImpartidas.Add(tEEIError);
            }

            return tEEImpartidas;
        }

        /// <summary>
        /// Método que obtiene todas las eeimpartidas.
        /// </summary>
        /// <remarks>Este método será utilizado para ver a que eeimpartida se quiere registrar.</remarks>
        /// <returns>Lista de estructuras TIEEImpartidaView.</returns>
        public List<TEEImpartidaView> obtenerTodasEEImpartidas(int idCuenta)
        {
            List<TEEImpartidaView> tEEImpartidas = new List<TEEImpartidaView>();
            List<eeimpartidaview> eeImpartidas = new List<eeimpartidaview>();

            try
            {
                using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                {
                    eeImpartidas = (from eei in entidades.eeimpartidaview
                                    where !eei.idCuenta.Equals(idCuenta)
                                    select eei).ToList();
                }

                if (eeImpartidas.Count() > 0)
                {
                    foreach (var eei in eeImpartidas)
                    {
                        var teei = new TEEImpartidaView
                        {
                            IdEEImpartida = eei.idEEImpartida,
                            Ee = eei.ee,
                            Maestro = eei.maestro,
                            IdCuenta = eei.idCuenta
                        };
                        tEEImpartidas.Add(teei);
                    }
                }
                else
                {
                    var teei = new TEEImpartidaView
                    {
                        IdEEImpartida = 0,
                        Ee = "Vacio",
                        Maestro = "Vacio",
                        IdCuenta = 0
                    };
                    tEEImpartidas.Add(teei);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                var teeiError = new TEEImpartidaView
                {
                    IdEEImpartida = 0,
                    Ee = "Error",
                    Maestro = "Error",
                    IdCuenta = 0
                };
                tEEImpartidas.Add(teeiError);
            }

            return tEEImpartidas;
        }

        /// <summary>
        /// Método que registra una nueva ee.
        /// </summary>
        /// <param name="nuevaEE">Estructura Thrift que será convertida a una entidad para registrar.</param>
        /// <returns>Regresa resultado del registro.</returns>
        public string registrarEE(TExperienciaEducativa nuevaEE)
        {
            string resultadoRegistro;

            experienciaeducativa eeParaRegistrar = new experienciaeducativa
            {
                nombre = nuevaEE.Nombre,
            };

            try
            {
                if (!Utilidad.ExisteEE(eeParaRegistrar))
                {
                    using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                    {
                        entidades.experienciaeducativa.Add(eeParaRegistrar);
                        entidades.SaveChanges();
                    }
                    resultadoRegistro = "EERegistrada";

                }
                else
                {
                    resultadoRegistro = "EEDuplicada";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                resultadoRegistro = "ErrorRegistro";
            }

            return resultadoRegistro;
        }

        /// <summary>
        /// Método que registra una nueva eeasistencia.
        /// </summary>
        /// <remarks>Este método es utilizado cuando se quiera inscribir a una ee.</remarks>
        /// <param name="nuevaEEAsistencia">Estructura Thrift eeasistencia que será convertida en una entidad.</param>
        /// <returns>Retorna el resultado del registro</returns>
        public string registrarEEParaAsistir(TEEAsistencia nuevaEEAsistencia)
        {
            string resultadoRegistro;

            eeasistencia eeaParaRegistrar = new eeasistencia
            {
                idEEImpartida = nuevaEEAsistencia.Ideeimpartida,
                idCuenta = nuevaEEAsistencia.Idcuenta,
            };

            try
            {
                if (!Utilidad.ExisteEEA(eeaParaRegistrar))
                {

                    using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                    {
                        entidades.eeasistencia.Add(eeaParaRegistrar);
                        entidades.SaveChanges();
                    }
                    resultadoRegistro = "EEARegistrada";
                }
                else
                {
                    resultadoRegistro = "EEARepetida";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                resultadoRegistro = "ErrorRegistro";
            }

            return resultadoRegistro;
        }

        /// <summary>
        /// Método que registra una nueva eeimartida.
        /// </summary>
        /// <remarks>Este método es utilizado cuando se quiera impartir una nueva ee.</remarks>
        /// <param name="nuevaEEImpartida">Estructura Thrift </param>
        /// <returns></returns>
        public string registrarEEParaImpartir(TEEImpartida nuevaEEImpartida)
        {
            string resultadoRegistro;

            eeimpartida eeiParaRegistrar = new eeimpartida
            {
                idEE = nuevaEEImpartida.IdEE,
                idCuenta = nuevaEEImpartida.IdCuenta,
            };

            try
            {
                if (!Utilidad.ExisteEEI(eeiParaRegistrar))
                {

                    using (ClasesEnLineaEntities entidades = new ClasesEnLineaEntities())
                    {
                        entidades.eeimpartida.Add(eeiParaRegistrar);
                        entidades.SaveChanges();
                    }
                    resultadoRegistro = "EEIRegistrada";

                }
                else
                {
                    resultadoRegistro = "EEIDuplicada";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                resultadoRegistro = "ErrorRegistro";
            }

            return resultadoRegistro;
        }
    }
}
