using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Cotizacion_Proveedor
{
    public class VerRegistroCotizacion_ProveedorCommand : Command<Cotizacion_proveedorDTO>
    {
        private readonly int _C_proveedor;
        private Cotizacion_proveedorDTO _result;

        public VerRegistroCotizacion_ProveedorCommand(int C_proveedor)
        {
            _C_proveedor = C_proveedor;
        }

        public override void Execute()
        {
            Cotizacion_ProveedorDAO c_proveedorDAO = Cotizacion_ProveedorFactory.CreateCotizacion_ProveedorDB();
           // _result = c_proveedorDAO.GetCotizacionesPorProveedor(_C_proveedor);
        }

        public override Cotizacion_proveedorDTO GetResult()
        {
            return _result;
        }

    }
}
