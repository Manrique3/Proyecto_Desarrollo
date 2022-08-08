using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Proveedor_Marca
{
    public class VerRegistroProveedorMarcaCommand : Command<Proveedor_MarcaDTO>
    {
        private readonly int _ProveedorMarca;
        private Proveedor_MarcaDTO _result;

        public VerRegistroProveedorMarcaCommand(int ProveedorMarca)
        {
            _ProveedorMarca = ProveedorMarca;
        }

        public override void Execute()
        {
            Proveedor_MarcaDAO P_MarcaDAO = Proveedor_MarcaFactory.CreateProveedor_MarcaDB();

            //_result = P_MarcaDAO.GetMarcaProveedor(_ProveedorMarca);
        }

        public override Proveedor_MarcaDTO GetResult()
        {
            return _result;
        }
    }
}
