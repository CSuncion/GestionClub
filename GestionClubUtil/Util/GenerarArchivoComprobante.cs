using Comun;
using GestionClubModel.ModelDto;
using System;
using System.Linq;
using System.IO;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace GestionClubUtil.Util
{
    public class GenerarArchivoComprobante
    {
        public static void Main(GestionClubComprobanteDto objCabecera,
            List<GestionClubDetalleComprobanteDto> objDetalle,
            List<GestionClubParametroDto> objParametro)
        {
            string nombreArchivo = objCabecera.serComprobante + "-" + objCabecera.nroComprobante + ".txt";
            string docPath = objParametro.FirstOrDefault().RutaImagenQR;
            string rutaComprobante = Path.Combine(docPath, nombreArchivo);
            if (File.Exists(rutaComprobante))
            {
                File.Delete(rutaComprobante);
            }
            using (StreamWriter outputFile = new StreamWriter(rutaComprobante, true))
            {
                outputFile.WriteLine("operacion|generar_comprobante|");
                outputFile.WriteLine("tipo_de_comprobante|" + Convert.ToInt32(objCabecera.tipComprobante) + "|");
                outputFile.WriteLine("serie|" +
                    (objCabecera.tipComprobante == "01" ?
                    objCabecera.serComprobante.Replace('0', 'F') :
                    objCabecera.serComprobante.Replace('0', 'B'))
                    + "|");
                outputFile.WriteLine("numero|" + objCabecera.nroComprobante + "|");
                outputFile.WriteLine("sunat_transaction|1|");
                outputFile.WriteLine("cliente_tipo_de_documento|" +
                    (objCabecera.tipCliente != "01" ?
                    "6" :
                    "1")
                    + "|");
                outputFile.WriteLine("cliente_numero_de_documento|" +
                    (objCabecera.tipCliente == "01" ?
                    objCabecera.nroIdentificacionCliente.Substring(0, 8) :
                    objCabecera.nroIdentificacionCliente.Substring(0, 11))
                    + "|");
                outputFile.WriteLine("cliente_denominacion|" + objCabecera.nombreRazSocialCliente + "|");
                outputFile.WriteLine("cliente_direccion|" + "" + "|");
                outputFile.WriteLine("cliente_email|" + "" + "|");
                outputFile.WriteLine("cliente_email1|" + "" + "|");
                outputFile.WriteLine("cliente_email2|" + "" + "|");
                outputFile.WriteLine("fecha_de_emision|" +
                    (Fecha.ObtenerNumeroDia(objCabecera.fecComprobante)
                    + "-" +
                    Fecha.ObtenerNumeroMes(objCabecera.fecComprobante)
                    + "-" +
                    Fecha.ObtenerAño(objCabecera.fecComprobante))
                    + "|");
                outputFile.WriteLine("fecha_de_vencimiento||");
                outputFile.WriteLine("moneda|" + Convert.ToInt32(objCabecera.codMoneda) + "|");
                outputFile.WriteLine("tipo_de_cambio|" + Formato.NumeroDecimal(objCabecera.impCambio, 3) + "|");
                outputFile.WriteLine("porcentaje_de_igv|" + objParametro.FirstOrDefault().PorcentajeIgv + "|");
                outputFile.WriteLine("descuento_global||");
                outputFile.WriteLine("total_descuento||");
                outputFile.WriteLine("total_anticipo||");
                outputFile.WriteLine("total_gravada|" + objCabecera.impBruComprobante + "|");
                outputFile.WriteLine("total_inafecta||");
                outputFile.WriteLine("total_exonerada||");
                outputFile.WriteLine("total_igv|" + objCabecera.impIgvComprobante + "|");
                outputFile.WriteLine("total_gratuita||");
                outputFile.WriteLine("total_otros_cargos||");
                outputFile.WriteLine("total|" + objCabecera.impNetComprobante + "|");
                outputFile.WriteLine("percepcion_tipo||");
                outputFile.WriteLine("percepcion_base_imponible||");
                outputFile.WriteLine("total_percepcion||");
                outputFile.WriteLine("total_incluido_percepcion||");
                outputFile.WriteLine("detraccion|false|");
                outputFile.WriteLine("observaciones||");
                outputFile.WriteLine("documento_que_se_modifica_tipo||");
                outputFile.WriteLine("documento_que_se_modifica_serie||");
                outputFile.WriteLine("documento_que_se_modifica_numero||");
                outputFile.WriteLine("tipo_de_nota_de_credito||");
                outputFile.WriteLine("tipo_de_nota_de_debito||");
                outputFile.WriteLine("enviar_automaticamente_a_la_sunat|true|");
                outputFile.WriteLine("enviar_automaticamente_al_cliente|false|");
                outputFile.WriteLine("codigo_unico||");
                outputFile.WriteLine("condiciones_de_pago||");
                outputFile.WriteLine("medio_de_pago||");
                outputFile.WriteLine("placa_vehiculo||");
                outputFile.WriteLine("orden_compra_servicio||");
                outputFile.WriteLine("tabla_personalizada_codigo||");
                outputFile.WriteLine("formato_de_pdf||");
                foreach (GestionClubDetalleComprobanteDto item in objDetalle)
                {
                    decimal precioReal = (item.preVenta / (1 + (objParametro.FirstOrDefault().PorcentajeIgv / 100)));
                    outputFile.WriteLine("item|NIU|" +
                        (item.codProducto)
                        + "|" +
                        (item.desProducto)
                        + "|" +
                        (item.cantidad)
                        + "|" +
                        (precioReal)
                        + "|" +
                        (item.preVenta)
                        + "||" +
                        (item.cantidad * precioReal)
                        + "|1|" +
                        (precioReal * (objParametro.FirstOrDefault().PorcentajeIgv / 100))
                        + "|" +
                        ((item.cantidad * precioReal) + (precioReal * (objParametro.FirstOrDefault().PorcentajeIgv / 100)))
                        + "|false|||10000000|");
                }
            }
        }
    }
}
