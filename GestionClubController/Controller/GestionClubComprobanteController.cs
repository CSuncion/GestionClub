﻿using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubComprobanteController
    {
        private readonly IGestionClubComprobanteRepository _iCreditComprobanteRepository;

        public GestionClubComprobanteController()
        {
            this._iCreditComprobanteRepository = new GestionClubComprobanteRepository();
        }

        public static void EliminarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.EliminarComprobante(pObj);
        }
        public static void ModificarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.ModificarComprobante(pObj);
        }
        public static int AgregarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.AgregarComprobante(pObj);
        }
        public static void AgregarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.AgregarDetalleComprobante(pObj);
        }
        public static List<GestionClubDetalleComprobanteDto> RefrescarListaComprobanteDeta(List<GestionClubDetalleComprobanteDto> pLis)
        {
            List<GestionClubDetalleComprobanteDto> iLisRes = new List<GestionClubDetalleComprobanteDto>();
            foreach (GestionClubDetalleComprobanteDto xComDet in pLis)
            {
                iLisRes.Add(xComDet);
            }
            return iLisRes;
        }
        public static List<GestionClubComprobanteDto> ListarComprobantes(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantes(objEn);
        }
        public List<GestionClubComprobanteDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubComprobanteDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubComprobanteDto> iLisRes = new List<GestionClubComprobanteDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubComprobanteController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubComprobanteDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubComprobanteDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubComprobanteDto> iLisRes = new List<GestionClubComprobanteDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubComprobanteDto xOperations in pLista)
            {
                string iTexto = GestionClubComprobanteController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(GestionClubComprobanteDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubComprobanteDto._serNroComprobante: return pObj.serNroComprobante;
                case GestionClubComprobanteDto._desTipComprobante: return pObj.desTipComprobante;
                case GestionClubComprobanteDto._fecComprobante: return pObj.fecComprobante.ToString();
                case GestionClubComprobanteDto._desMoneda: return pObj.desMoneda;
                case GestionClubComprobanteDto._nroIdentificacionCliente: return pObj.nroIdentificacionCliente;
                case GestionClubComprobanteDto._nombreRazSocialCliente: return pObj.nombreRazSocialCliente;
                case GestionClubComprobanteDto._desPagoComprobante: return pObj.desPagoComprobante;
                case GestionClubComprobanteDto._impNetComprobante: return pObj.impNetComprobante.ToString();
                case GestionClubComprobanteDto._estadoComprobante: return pObj.estadoComprobante;
                case GestionClubComprobanteDto._idComprobante: return pObj.idComprobante.ToString();
                case GestionClubComprobanteDto._claveObjeto: return pObj.claveObjeto;
            }

            //retorna
            return iValor;
        }
    }
}