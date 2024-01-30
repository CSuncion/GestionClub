using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubClienteRepository
    {
        List<GestionClubClienteDto> ListarClientes();
        GestionClubClienteDto ListarClientePorId(GestionClubClienteDto pObj);
        GestionClubClienteDto ListarClientePorCodigoPorEmpresa(GestionClubClienteDto pObj);
        void AgregarCliente(GestionClubClienteDto pObj);
        void ModificarCliente(GestionClubClienteDto pObj);
        void EliminarCliente(GestionClubClienteDto pObj);
        List<GestionClubClienteDto> ListarClientesActivos();
    }
}