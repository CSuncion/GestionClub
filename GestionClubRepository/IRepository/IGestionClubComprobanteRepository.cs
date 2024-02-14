using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubComprobanteRepository
    {
        int AgregarComprobante(GestionClubComprobanteDto pObj);
        void AgregarDetalleComprobante(GestionClubDetalleComprobanteDto pObj);
        void ModificarComprobante(GestionClubComprobanteDto pObj);
        void ModificarDetalleComprobante(GestionClubDetalleComprobanteDto pObj);
        void EliminarComprobante(GestionClubComprobanteDto pObj);
        void EliminarDetalleComprobante(GestionClubDetalleComprobanteDto pObj);
        List<GestionClubComprobanteDto> ListarComprobantes(GestionClubComprobanteDto objEn);
        GestionClubComprobanteDto ListarComprobantesPorId(GestionClubComprobanteDto objEn);
        List<GestionClubDetalleComprobanteDto> ListarDetallesComprobantesPorComprobante(GestionClubDetalleComprobanteDto objEn);
        List<GestionClubComprobanteDto> ListarComprobantesNotaDeCredito(GestionClubComprobanteDto objEn);
        GestionClubComprobanteDto ListaComprobantePorNroComprobante(GestionClubComprobanteDto objEn);
    }
}