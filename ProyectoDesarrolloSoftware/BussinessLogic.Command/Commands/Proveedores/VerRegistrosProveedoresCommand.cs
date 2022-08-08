using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Proveedores
{
    public class VerRegistrosProveedoresCommand : Command<ProveedorDTO>
    {
        private readonly int _proveedor;
        private ProveedorDTO _result;

        public VerRegistrosProveedoresCommand(int proveedor)
        {
            _proveedor = proveedor;
        }

        public override void Execute()
        {
            ProveedoresDAO proveedorDAO = ProveedorFactory.CreateProveedorDB();

            _result = proveedorDAO.GetProveedor(_proveedor);
        }

        public override ProveedorDTO GetResult()
        {
            return _result;
        }
    }
}
