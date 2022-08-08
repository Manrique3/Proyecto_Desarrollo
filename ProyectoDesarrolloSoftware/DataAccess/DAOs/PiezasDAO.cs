﻿using ProyectoDesarrolloSoftware.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.Fabricas;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class PiezasDAO : IPiezasDAO
    {
        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);
        /*public readonly DSDBContext _context;

        public PiezasDAO(DSDBContext context)
        {
            _context = context;
        }*/

        public Task Add(PiezaDTO piezaDTO)
        {
            Pieza pieza = new Pieza();
            pieza.Id_Pieza = piezaDTO.Id_Pieza;
            pieza.Nombre = piezaDTO.Nombre;
            _context.Piezas.Add(pieza);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }


        public List<PiezaDTO> GetListaPiezasByName(string Nombre)
        {
            try
            {
                var query = _context.Piezas
                   .Where(b => b.Nombre == Nombre)
                   .Select(b => new PiezaDTO
                   {
                       Id_Pieza = b.Id_Pieza,
                       Nombre = b.Nombre
                   }).ToList();               

                return query;
            }
            catch (Excepciones)
            {
                throw new Exception("La lista no puede ser mostrada");
            }
        }

        public PiezaDTO GetPieza(int Id_Pieza)
        {
            var query = _context.Piezas
                  .Where(b => b.Id_Pieza == Id_Pieza)
                  .Select(b => new PiezaDTO
                  {
                      Id_Pieza = b.Id_Pieza,
                      Nombre = b.Nombre
                  });

            return query.First();
        }

        public Task delete(int Id_Pieza)
        {
            var ItemToRemove = _context.Piezas.Find(Id_Pieza);
            _context.Piezas.Remove(ItemToRemove);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(PiezaDTO piezaDTO, int Id_Pieza)
        {
            var itemToUpdate = _context.Piezas.Find(Id_Pieza);
            itemToUpdate.Nombre = piezaDTO.Nombre;
            _context.DbContext.SaveChanges();
                

            return Task.CompletedTask;
        }

      
    }
}