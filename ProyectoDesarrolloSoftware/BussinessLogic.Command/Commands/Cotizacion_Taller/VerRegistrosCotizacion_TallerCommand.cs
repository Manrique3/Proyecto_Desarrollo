using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Cotizacion_Taller
{
    public class VerRegistrosCotizacion_TallerCommand : Command<Cotizacion_TallerDTO>
    {
        private readonly int _C_Taller;
        private Cotizacion_TallerDTO _result;

        public VerRegistrosCotizacion_TallerCommand(int C_taller)
        {
            _C_Taller = C_taller;
        }
        public override void Execute()
        {
            Cotizacion_TallerDAO C_tallerDAO = Cotizacion_TallerFactory.CreateCotizacion_TallerDB();

            _result = C_tallerDAO.GetCotizacionTaller(_C_Taller);
        }

        public override Cotizacion_TallerDTO GetResult()
        {
           return _result;
        }
    }
}
