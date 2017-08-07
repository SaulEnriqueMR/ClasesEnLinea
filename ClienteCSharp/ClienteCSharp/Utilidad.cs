using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCSharp
{
    class Utilidad
    {
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

        public static string ObtenerDireccionIP()
        {
            string direccionIP = "NoEncontrada";
            //Returns objects that describe the network interfaces on the local computer.
            //Example: Wireless Network Connection, Bluetooth Network Connection
            //Local Area Connection etc
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkinf in adapters)
            {
                //fetch network configuration properties
                IPInterfaceProperties properties = networkinf.GetIPProperties();
                foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
                {
                    // Ignore loop-back addresses & IPv6 internet protocol family
                    if (!IPAddress.IsLoopback(uniCast.Address) && uniCast.Address.AddressFamily != AddressFamily.InterNetworkV6)
                    {
                        if (networkinf.Name.Equals("Wi-Fi"))
                        {
                            direccionIP = uniCast.Address.ToString();
                        }
                    }
                }
            }
            return direccionIP;
        }
    }
}
