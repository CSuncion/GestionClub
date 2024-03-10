using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubUtil.Util
{
    public class FacturacionElectronicaNubeFact
    {
        /// #########################################################
        /// #### PASO 1: CONSEGUIR LA RUTA Y TOKEN ####
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// # CUENTA DEMO PARA HACER PRUEBAS
        /// # Puedes usar la siguiente cuenta para hacer pruebas:
        /// #  - LINK: https://demo.nubefact.com/login
        /// #  - USUARIO: demo@nubefact.com
        /// #  - PASSWORD: demo@nubefact.com
        /// # Una vez que ingreses a esta cuenta ve a la opción API (Integración) para ver la RUTA y el TOKEN los cuales son:
        /// #  - RUTA: https://demo.nubefact.com/api/v1/03989d1a-6c8c-4b71-b1cd-7d37001deaa0
        /// #  - TOKEN: d0a80b88cde446d092025465bdb4673e103a0d881ca6479ebbab10664dbc5677
        /// # También puedes crear una cuenta propia para hacer pruebas más precisas.
        /// #
        /// # CREAR UNA CUENTA PROPIA
        /// #  - Regístrate gratis en www.nubefact.com/register
        /// #  - Ir la opción API (Integración).
        /// # IMPORTANTE: Para que la opción API (Integración) de tu cuenta propia esté activada necesitas escribirnos a soporte@nubefact.com o llámanos al teléfono: 01 468 3535 (opción 2) o celular (WhatsApp) 955 598762.
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /// # RUTA para enviar documentos
        public const string ruta = "https://api.nubefact.com/api/v1/38db2205-fe89-43c5-8d57-1c94e7d3f09b";

        /// # TOKEN para enviar documentos
        public const string token = "4a8f0825cf5d4bdab86863f20bb89ec4d3b61e92a23541ee97c9ad6bd4cfc51b";

        /// #########################################################
        /// #### PASO 2: GENERAR EL ARCHIVO PARA ENVIAR A NUBEFACT ####
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// # - MANUAL para archivo JSON en el link: https://goo.gl/WHMmSb
        /// # - MANUAL para archivo TXT en el link: https://goo.gl/Lz7hAq
        /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public static string Main(string serNro,
            List<GestionClubParametroDto> objParametro)
        {
            StreamReader sr = new StreamReader(objParametro.FirstOrDefault().RutaImagenQR + serNro + ".txt"); ///AQUI VA TU ARCHIVO TXT
            string txt_sin_codificar = sr.ReadToEnd();
            byte[] txt_bytes = Encoding.Default.GetBytes(txt_sin_codificar);
            string txt_en_utf_8 = Encoding.UTF8.GetString(txt_bytes);
            sr.Close();

            /// #########################################################
            /// #### PASO 3: ENVIAR EL ARCHIVO A NUBEFACT ####
            /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
            /// # SI ESTÁS TRABAJANDO CON ARCHIVO JSON
            /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
            /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
            /// # Content-Type = application/json
            /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
            /// # SI ESTÁS TRABAJANDO CON ARCHIVO TXT
            /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
            /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
            /// # Content-Type = text/plain
            /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
            /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

            string json_de_respuesta = SendJson(ruta, txt_en_utf_8, token);

            ///#########################################################
            ///#### PASO 4: LEER RESPUESTA DE NUBEFACT ####
            ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ///# Recibirás una respuesta de NUBEFACT inmediatamente lo cual se debe leer, verificando que no haya errores.
            ///# Debes guardar en la base de datos la respuesta que te devolveremos.
            ///# Escríbenos a soporte@nubefact.com o llámanos al teléfono: 01 468 3535 (opción 2) o celular (WhatsApp) 955 598762
            ///# Puedes imprimir el PDF que nosotros generamos como también generar tu propia representación impresa previa coordinación con nosotros.
            ///# La impresión del documento seguirá haciéndose desde tu sistema. Enviaremos el documento por email a tu cliente si así lo indicas en el archivo JSON o TXT.
            ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //LEEMOS LA RESPUESTA DE NUBEFACT
            return json_de_respuesta;
        }


        static string SendJson(string ruta, string json, string token)
        {
            try
            {
                using (var client = new WebClient())
                {
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "text/plain";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;
                    /// OBTENEMOS LA RESPUESTA
                    string respuesta = client.UploadString(ruta, "POST", json);
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }

    }
}
