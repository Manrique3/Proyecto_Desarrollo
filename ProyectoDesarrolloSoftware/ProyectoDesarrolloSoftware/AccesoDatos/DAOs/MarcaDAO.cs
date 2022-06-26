﻿    
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations
{
    public class MarcaDAO : IMarcaDAO
    {
        private DSDBContext _context;
        public MarcaDAO(DSDBContext context)
        {
            _context = context;

        }
      
        public Task AddMarca(MarcaDTO marca)
        {
            try
            {

                Marca _marca = new Marca();
                _marca.IDMarca = marca.IDMarca;
                _marca.Name = marca.Nombre;
                _context.Marcas.Add(_marca);
                _context.SaveChanges();
                return Task.CompletedTask;/*

                Pieza pieza = new Pieza();
                pieza.Id_Pieza = piezaDTO.Id_Pieza;
                pieza.Nombre = piezaDTO.Nombre;
                _context.Piezas.Add(pieza);
                _context.SaveChanges();
                return Task.CompletedTask;*/
            }
            catch (Exception e)
            { 
                throw new Exception("Ocurrio un error en la base de datos" + e);
            }
        }

        public Task DeleteMarca(int Id_marca)
        {
            var data = _context.Marcas.Find(Id_marca); // Se Debe eliminar por ID, no por objeto.
            _context.Marcas.Remove(data);
            _context.SaveChanges();
            return Task.CompletedTask;

      
        }

        public Task EditMarca(MarcaDTO marca, int id_marca)
        {
            var data = _context.Marcas.Find(id_marca);
            data.Name = marca.Nombre;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public MarcaDTO GetMarca(int Id)
        {
            try
            {
                var data = _context.Marcas
                .Where(b => b.IDMarca ==Id)
               .Select(b => new MarcaDTO
               {
                   IDMarca = b.IDMarca,
                   Nombre = b.Name,

               });                
                return data.First();
            }
            catch (Exception e) { //System.InvalidCastException
                throw new Exception("Ocurrio un error en la base de datos" + e);
            }
                
        }

        public List<MarcaDTO> GetMarcas()
        {
            
            var data = _context.Marcas
                .Select(b => new MarcaDTO
                {
                    IDMarca = b.IDMarca,
                    Nombre = b.Name,

                }).ToList();

            return data;
         
        }
    }
}
