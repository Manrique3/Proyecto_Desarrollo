using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Cotizacion
{
    public class VerRegistrosCotizacionCommand : Command<CotizacionDTO>
    {
        private readonly int _cotizacion;
        private CotizacionDTO _result;

        public VerRegistrosCotizacionCommand(int cotizacion)
        {
            _cotizacion = cotizacion;
        }

        public override void Execute()
        {
            CotizacionDAO cotizacionDAO = CotizacionFactorycs.CreateCotizacionDB();

            _result = cotizacionDAO.GetCotizacion(_cotizacion);
        }

        public override CotizacionDTO GetResult()
        {
            return _result;
        }
    }
}
