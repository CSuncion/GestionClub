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
        public static void ComprobanteElectronico(GestionClubComprobanteDto objCabecera,
            List<GestionClubDetalleComprobanteDto> objDetalle,
            List<GestionClubParametroDto> objParametro,
            GestionClubClienteDto cliente)
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
                outputFile.WriteLine("sunat_transaction|" + (Numero.ObtenerNumeroDecimal(objCabecera.impDtrComprobante) > 0 ? "30" : "1") + "|");
                outputFile.WriteLine("cliente_tipo_de_documento|" +
                    (objCabecera.tipCliente != "01" ?
                    "6" :
                    "1")
                    + "|");
                outputFile.WriteLine("cliente_numero_de_documento|" +
                    (objCabecera.tipCliente == "01" ?
                    objCabecera.nroIdentificacionCliente.Substring(3, 8) :
                    objCabecera.nroIdentificacionCliente.Substring(0, 11))
                    + "|");
                outputFile.WriteLine("cliente_denominacion|" + objCabecera.nombreRazSocialCliente + "|");

                outputFile.WriteLine("cliente_direccion|" + (cliente.representanteCliente == string.Empty ? string.Empty : cliente.representanteCliente) + "|");
                outputFile.WriteLine("cliente_email|" + (cliente.emailCliente == string.Empty ? string.Empty : cliente.emailCliente) + "|");
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
                outputFile.WriteLine("total_gravada|" + Numero.ObtenerNumeroDecimal(objCabecera.impBruComprobante) + "|");
                outputFile.WriteLine("total_inafecta||");
                outputFile.WriteLine("total_exonerada||");
                outputFile.WriteLine("total_igv|" + Numero.ObtenerNumeroDecimal(objCabecera.impIgvComprobante) + "|");
                outputFile.WriteLine("total_gratuita||");
                outputFile.WriteLine("total_otros_cargos||");
                outputFile.WriteLine("total|" + Numero.ObtenerNumeroDecimal(objCabecera.impNetComprobante) + "|");
                outputFile.WriteLine("percepcion_tipo||");
                outputFile.WriteLine("percepcion_base_imponible||");
                outputFile.WriteLine("total_percepcion||");
                outputFile.WriteLine("total_incluido_percepcion||");
                outputFile.WriteLine("detraccion|" + (objCabecera.impDtrComprobante > 0 ? "true" : "false") + "|");
                outputFile.WriteLine("observaciones||");
                outputFile.WriteLine("documento_que_se_modifica_tipo||");
                outputFile.WriteLine("documento_que_se_modifica_serie||");
                outputFile.WriteLine("documento_que_se_modifica_numero||");
                outputFile.WriteLine("tipo_de_nota_de_credito||");
                outputFile.WriteLine("tipo_de_nota_de_debito||");
                outputFile.WriteLine("enviar_automaticamente_a_la_sunat|true|");
                outputFile.WriteLine("enviar_automaticamente_al_cliente|" + (cliente.emailCliente == string.Empty ? "false" : "true") + "|");
                outputFile.WriteLine("codigo_unico||");
                outputFile.WriteLine("condiciones_de_pago||");
                outputFile.WriteLine("medio_de_pago||");
                outputFile.WriteLine("placa_vehiculo||");
                outputFile.WriteLine("orden_compra_servicio||");
                if (objCabecera.impDtrComprobante > 0)
                {
                    outputFile.WriteLine("detraccion_tipo|17|");
                    outputFile.WriteLine("detraccion_total|" + (Numero.ObtenerNumeroDecimal(objCabecera.impDtrComprobante)) + "|");
                    outputFile.WriteLine("medio_de_pago_detraccion|1|");
                }
                else
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
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(precioReal, 10)))
                        + "|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(precioReal + (precioReal * objParametro.FirstOrDefault().PorcentajeIgv / 100), 10)))
                        + "||" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal((precioReal * item.cantidad), 10)))
                        + "|1|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal((precioReal * item.cantidad) * (objParametro.FirstOrDefault().PorcentajeIgv / 100), 10)))
                        + "|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(((precioReal * item.cantidad) + ((precioReal * item.cantidad) * (objParametro.FirstOrDefault().PorcentajeIgv / 100))), 10)))
                        + "|false|||10000000|");
                }
            }
        }
        public static void NotaCreditoElectronico(GestionClubComprobanteDto objCabecera,
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
                outputFile.WriteLine("operacion|generar_anulacion|");
                outputFile.WriteLine("tipo_de_comprobante|" + (objCabecera.serGuiaComprobante.Substring(0, 1) == "B" ? "2" : "1") + "|");
                outputFile.WriteLine("serie|" +
                    (objCabecera.serGuiaComprobante.Substring(0, 1) == "F" ?
                    objCabecera.serGuiaComprobante.Replace('0', 'F') :
                    objCabecera.serGuiaComprobante.Replace('0', 'B'))
                    + "|");
                outputFile.WriteLine("numero|" + objCabecera.nroGuiaComprobante + "|");
                outputFile.WriteLine("motivo|" + objCabecera.obsComprobante + "|");
                outputFile.WriteLine("codigo_unico||");
            }
        }

        public static void ComprobanteElectronicoAnticipoDetracción(GestionClubComprobanteDto objCabecera,
    List<GestionClubDetalleComprobanteDto> objDetalle,
    List<GestionClubParametroDto> objParametro,
    GestionClubClienteDto cliente)
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
                outputFile.WriteLine("sunat_transaction|" + (objCabecera.flagCancelado ? "30" : "4") + "|");
                outputFile.WriteLine("cliente_tipo_de_documento|" +
                    (objCabecera.tipCliente != "01" ?
                    "6" :
                    "1")
                    + "|");
                outputFile.WriteLine("cliente_numero_de_documento|" +
                    (objCabecera.tipCliente == "01" ?
                    objCabecera.nroIdentificacionCliente.Substring(3, 8) :
                    objCabecera.nroIdentificacionCliente.Substring(0, 11))
                    + "|");
                outputFile.WriteLine("cliente_denominacion|" + objCabecera.nombreRazSocialCliente + "|");

                outputFile.WriteLine("cliente_direccion|" + (cliente.representanteCliente == string.Empty ? string.Empty : cliente.representanteCliente) + "|");
                outputFile.WriteLine("cliente_email|" + (cliente.emailCliente == string.Empty ? string.Empty : cliente.emailCliente) + "|");
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
                outputFile.WriteLine("tipo_de_cambio|" + Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impCambio, 3)) + "|");
                outputFile.WriteLine("porcentaje_de_igv|" + objParametro.FirstOrDefault().PorcentajeIgv + "|");
                outputFile.WriteLine("descuento_global||");
                outputFile.WriteLine("total_descuento||");
                outputFile.WriteLine("total_anticipo||");
                outputFile.WriteLine("total_gravada|" + Numero.ObtenerNumeroDecimal(objCabecera.impBruComprobante) + "|");
                outputFile.WriteLine("total_inafecta||");
                outputFile.WriteLine("total_exonerada||");
                outputFile.WriteLine("total_igv|" + Numero.ObtenerNumeroDecimal(objCabecera.impIgvComprobante) + "|");
                outputFile.WriteLine("total_gratuita||");
                outputFile.WriteLine("total_otros_cargos||");
                outputFile.WriteLine("total|" + Numero.ObtenerNumeroDecimal(objCabecera.impNetComprobante) + "|");
                outputFile.WriteLine("percepcion_tipo||");
                outputFile.WriteLine("percepcion_base_imponible||");
                outputFile.WriteLine("total_percepcion||");
                outputFile.WriteLine("total_incluido_percepcion||");
                outputFile.WriteLine("detraccion|" + (Numero.ObtenerNumeroDecimal(objCabecera.impDtrComprobante) > 0 ? "true" : "false") + "|");
                outputFile.WriteLine("observaciones|" + objCabecera.obsComprobante + "|");
                outputFile.WriteLine("documento_que_se_modifica_tipo||");
                outputFile.WriteLine("documento_que_se_modifica_serie||");
                outputFile.WriteLine("documento_que_se_modifica_numero||");
                outputFile.WriteLine("tipo_de_nota_de_credito||");
                outputFile.WriteLine("tipo_de_nota_de_debito||");
                outputFile.WriteLine("enviar_automaticamente_a_la_sunat|true|");
                outputFile.WriteLine("enviar_automaticamente_al_cliente|" + (cliente.emailCliente == string.Empty ? "false" : "true") + "|");
                outputFile.WriteLine("codigo_unico||");
                outputFile.WriteLine("condiciones_de_pago||");
                outputFile.WriteLine("medio_de_pago||");
                outputFile.WriteLine("placa_vehiculo||");
                outputFile.WriteLine("orden_compra_servicio||");
                if (objCabecera.impDtrComprobante > 0)
                {
                    outputFile.WriteLine("detraccion_tipo|17|");
                    outputFile.WriteLine("detraccion_total|" + (Numero.ObtenerNumeroDecimal(objCabecera.impDtrComprobante)) + "|");
                    outputFile.WriteLine("medio_de_pago_detraccion|1|");
                }

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
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(precioReal, 10)))
                        + "|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(precioReal + (precioReal * objParametro.FirstOrDefault().PorcentajeIgv / 100), 10)))
                        + "||" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal((precioReal * item.cantidad), 10)))
                        + "|1|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal((precioReal * item.cantidad) * (objParametro.FirstOrDefault().PorcentajeIgv / 100), 10)))
                        + "|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(((precioReal * item.cantidad) + ((precioReal * item.cantidad) * (objParametro.FirstOrDefault().PorcentajeIgv / 100))), 10)))
                        + "|false|||10000000|");
                }
            }
        }

        public static void ComprobanteElectronicoRegularizacionAnticipo(GestionClubComprobanteDto objCabecera,
List<GestionClubDetalleComprobanteDto> objDetalle,
List<GestionClubParametroDto> objParametro,
GestionClubClienteDto cliente)
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
                outputFile.WriteLine("sunat_transaction|4|");
                outputFile.WriteLine("cliente_tipo_de_documento|" +
                    (objCabecera.tipCliente != "01" ?
                    "6" :
                    "1")
                    + "|");
                outputFile.WriteLine("cliente_numero_de_documento|" +
                    (objCabecera.tipCliente == "01" ?
                    objCabecera.nroIdentificacionCliente.Substring(3, 8) :
                    objCabecera.nroIdentificacionCliente.Substring(0, 11))
                    + "|");
                outputFile.WriteLine("cliente_denominacion|" + objCabecera.nombreRazSocialCliente + "|");

                outputFile.WriteLine("cliente_direccion|" + (cliente.representanteCliente == string.Empty ? string.Empty : cliente.representanteCliente) + "|");
                outputFile.WriteLine("cliente_email|" + (cliente.emailCliente == string.Empty ? string.Empty : cliente.emailCliente) + "|");
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
                outputFile.WriteLine("tipo_de_cambio|" + Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impCambio, 3)) + "|");
                outputFile.WriteLine("porcentaje_de_igv|" + objParametro.FirstOrDefault().PorcentajeIgv + "|");
                outputFile.WriteLine("descuento_global||");
                outputFile.WriteLine("total_descuento||");
                outputFile.WriteLine("total_anticipo|" + Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impAnticipoComprobante, 2)) + "|");
                outputFile.WriteLine("total_gravada|" + Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impBruComprobante, 2)) + "|");
                outputFile.WriteLine("total_inafecta||");
                outputFile.WriteLine("total_exonerada||");
                outputFile.WriteLine("total_igv|" + Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impIgvComprobante, 2)) + "|");
                outputFile.WriteLine("total_gratuita||");
                outputFile.WriteLine("total_otros_cargos||");
                outputFile.WriteLine("total|" + Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impNetComprobante, 2)) + "|");
                outputFile.WriteLine("percepcion_tipo||");
                outputFile.WriteLine("percepcion_base_imponible||");
                outputFile.WriteLine("total_percepcion||");
                outputFile.WriteLine("total_incluido_percepcion||");
                outputFile.WriteLine("detraccion|" + (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impDtrComprobante, 2)) > 0 ? "true" : "false") + "|");
                outputFile.WriteLine("observaciones|" + objCabecera.obsComprobante + "|");
                outputFile.WriteLine("documento_que_se_modifica_tipo||");
                outputFile.WriteLine("documento_que_se_modifica_serie||");
                outputFile.WriteLine("documento_que_se_modifica_numero||");
                outputFile.WriteLine("tipo_de_nota_de_credito||");
                outputFile.WriteLine("tipo_de_nota_de_debito||");
                outputFile.WriteLine("enviar_automaticamente_a_la_sunat|true|");
                outputFile.WriteLine("enviar_automaticamente_al_cliente|" + (cliente.emailCliente == string.Empty ? "false" : "true") + "|");
                outputFile.WriteLine("codigo_unico||");
                outputFile.WriteLine("condiciones_de_pago||");
                outputFile.WriteLine("medio_de_pago||");
                outputFile.WriteLine("placa_vehiculo||");
                outputFile.WriteLine("orden_compra_servicio||");
                if (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impDtrComprobante, 2)) > 0)
                {
                    outputFile.WriteLine("detraccion_tipo|17|");
                    outputFile.WriteLine("detraccion_total|" + (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(objCabecera.impDtrComprobante, 10))) + "|");
                    outputFile.WriteLine("medio_de_pago_detraccion|1|");
                }

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
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(precioReal, 10)))
                        + "|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(precioReal + (precioReal * objParametro.FirstOrDefault().PorcentajeIgv / 100), 10)))
                        + "||" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal((precioReal * item.cantidad), 10)))
                        + "|1|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal((precioReal * item.cantidad) * (objParametro.FirstOrDefault().PorcentajeIgv / 100), 10)))
                        + "|" +
                        (Numero.ObtenerNumeroDecimal(Formato.NumeroDecimal(((precioReal * item.cantidad) + ((precioReal * item.cantidad) * (objParametro.FirstOrDefault().PorcentajeIgv / 100))), 10)))
                        + "|" +
                        (item.desProducto.ToLower().Contains("adelanto") ? "true" : "false")
                        + "|" +
                        (item.desProducto.ToLower().Contains("adelanto") ? objCabecera.serGuiaComprobante.Replace('0', 'F') : "")
                        + "|" +
                        (item.desProducto.ToLower().Contains("adelanto") ? objCabecera.nroGuiaComprobante : "")
                        + "|" +
                        (item.desProducto.ToLower().Contains("adelanto") ? "20000000" : "10000000")
                        + "|");
                }
            }
        }
    }
}
