using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Asegurados;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Cotizacion;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Cotizacion_Proveedor;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.MarcasC;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Pedido;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Pieza_Proveedores;

using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Piezas;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Poliza;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Proveedor_Marca;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Proveedores;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Taller_Marca;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Talleres;
using ProyectoDesarrolloSoftware.Entidades;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command
{
    public class CommandFactory
    {
        public static VerRegistrosAseguradoCommand createVerRegistrosAseguradoCommand(string asegurado)
        {
            return new VerRegistrosAseguradoCommand(asegurado);
        }
        public static CrearRegistroAseguradoCommand crearCrearRegistroAseguradoCommand(Asegurado asegurado)
        {
            return new CrearRegistroAseguradoCommand(asegurado);
        }

        public static VerRegistrosPiezasCommand createVerRegistrosPiezasCommand(string Nombre)
        {
            return new VerRegistrosPiezasCommand(Nombre);
        }


        public static VerRegistrosMarcaCommand createVerRegistrosPiezasCommand(int id)
        {
            return new VerRegistrosMarcaCommand(id);
        }


        public static VerRegistrosPieza_ProveedoresCommand createVerRegistrosPieza_ProveedoresCommand(int Id_Proveedor)
        {
            return new VerRegistrosPieza_ProveedoresCommand(Id_Proveedor);
        }
        
        public static VerRegistroTallerCommand createVerRegistroTallerCommand(string taller)
        {
            return new VerRegistroTallerCommand(taller);
        }

        public static VerRegistrosCotizacionCommand createVerRegistrosCotizacionCommand(int id)
        {
            return new VerRegistrosCotizacionCommand(id);

        }
        public static VerRegistrosProveedoresCommand createVerRegistrosProveedoresCommand(int id)
        {
            return new VerRegistrosProveedoresCommand(id);

        }

        public static VerRegitrosPolizaCommand createVerRegistrosPolizaCommand(int id)
        {
            return new VerRegitrosPolizaCommand(id);

        }

        public static VerRegistrosPedidoCommand createVerRegistrosPedidoCommand(int id)
        {
            return new VerRegistrosPedidoCommand(id);

        }

        public static VerRegistroCotizacion_ProveedorCommand createVerRegistrosCotizacion_ProveedorCommand(int id) //Devuelve una lista Cotizacion_Proveedor No funciona bien
        {
            return new VerRegistroCotizacion_ProveedorCommand(id);
        }

        public static VerRegistrosTallerMarcaCommand createVerRegistrosTallerMarcaCommand(int id) //Devuelve una lista TallerMarca No funciona bien
        {
            return new VerRegistrosTallerMarcaCommand(id);
        }

        public static VerRegistroProveedorMarcaCommand createVerRegistrosProveedorMarcaCommand(int id) //Devuelve una lista ProveedorMarcaDTO No funciona bien
        {
            return new VerRegistroProveedorMarcaCommand(id);
        }


    }
}
