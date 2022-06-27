using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Exceptions;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;


namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public class AseguradoDAO : IAseguradoDAO
    {
        public readonly DSDBContext _context;

        public AseguradoDAO(DSDBContext context)
        {
            _context = context;
        }

        public List<AseguradoDTO> VerRegistrosAsegurado(string asegurado)
        {
            try
            {
                var data = _context.Asegurados
                   .Where(a => a.Nombre == asegurado)
                   .Select(a => new AseguradoDTO
                   {
                       Cedula = a.Cedula,
                       Nombre = a.Nombre,
                       Apellido = a.Apellido
                   });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista de Asegurados" + asegurado, ex.Message, ex);
            }

        }
       
        public Task Add(AseguradoDTO aseguradoDTO)
        {
            Asegurado asegurado = new Asegurado();
            asegurado.Cedula = aseguradoDTO.Cedula;
            asegurado.Nombre = aseguradoDTO.Nombre;
            asegurado.Apellido = aseguradoDTO.Apellido;
            _context.Asegurados.Add(asegurado);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(AseguradoDTO aseguradoDTO, int Cedula)
        {
            var itemToUpdate = _context.Asegurados.Find(Cedula);
            itemToUpdate.Nombre = aseguradoDTO.Nombre;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Delete(int Cedula)
        {
            var ItemToRemove = _context.Asegurados.Find(Cedula);
            _context.Asegurados.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public AseguradoDTO GetAsegurado(int cedula)
        {
            var query = _context.Asegurados
                .Where(a => a.Cedula == cedula)
                .Select(a => new AseguradoDTO
                {
                    Cedula = a.Cedula,
                    Nombre = a.Nombre,
                    Apellido = a.Apellido
                });
            return query.First();
        }
    }
}
