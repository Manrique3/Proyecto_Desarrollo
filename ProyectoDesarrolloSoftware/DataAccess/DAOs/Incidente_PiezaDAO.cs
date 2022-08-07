using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoDesarrolloSoftware.Exceptions;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class Incidente_PiezaDAO : IIncidente_PiezaDAO
    {
        public readonly DSDBContext _context;

        public Incidente_PiezaDAO(DSDBContext context)
        {
            _context = context;
        }

        public Task Add(Incidente_PiezaDTO incidente_piezaDTO)
        {
            Incidente_Pieza incidente_pieza = new Incidente_Pieza();
            incidente_pieza.Id_Pieza = incidente_piezaDTO.Id_Pieza;
            incidente_pieza.Id_Incidente = incidente_piezaDTO.Id_Incidente;
            _context.Incidente_Pieza.Add(incidente_pieza);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(int Id_Pieza, int Id_Incidente)
        {
            var ItemToRemove = _context.Incidente_Pieza.Find(Id_Pieza,Id_Incidente);
            _context.Incidente_Pieza.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public List<Incidente_PiezaDTO> GetIncidente_Pieza(int Id_Incidente)
        {
            try
            {
                var data = _context.Incidente_Pieza
                    .Where(a => a.Id_Incidente == Id_Incidente)
                    .Select(a => new Incidente_PiezaDTO
                    {
                        Id_Incidente = a.Id_Incidente,
                        Id_Pieza = a.Id_Pieza,

                    });
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista de Piezas relacionadas al Incidente" + Id_Incidente, ex.Message, ex);
            }

            
        }

    }
}
