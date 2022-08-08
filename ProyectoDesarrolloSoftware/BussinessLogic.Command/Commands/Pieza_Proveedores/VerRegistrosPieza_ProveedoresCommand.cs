using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Pieza_Proveedores
{
    public class VerRegistrosPieza_ProveedoresCommand : Command<Pieza_ProveedorDTO>
    {
       
   
        private readonly int _id_proveedor;
        private Pieza_ProveedorDTO _result;

        public VerRegistrosPieza_ProveedoresCommand(int Id_Proveedor)
        {
            _id_proveedor = Id_Proveedor;
        }

        public override void Execute()
        {
            Pieza_ProveedorDAO pieza_proveedorDAO = Pieza_ProveedorFactory.CreatePieza_ProveedorDB();  

            _result = pieza_proveedorDAO.VerRegistrosPieza_Proveedor(_id_proveedor);
        }

        public override Pieza_ProveedorDTO GetResult()
        {
            return _result;
        }

    }
    }

