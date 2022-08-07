using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoDesarrolloSoftware.Exceptions;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public class Proveedor_MarcaDAO : IProveedor_MarcaDAO
    {
        public readonly DSDBContext _context;

        public Proveedor_MarcaDAO(DSDBContext context)
        {
            _context = context;
        }

        public Task Add(Proveedor_MarcaDTO proveedor_marcaDTO)
        {
            Proveedor_Marca proveedor_marca = new Proveedor_Marca();
            proveedor_marca.IDMarca = proveedor_marcaDTO.IDMarca;
            proveedor_marca.Id_proveedor = proveedor_marcaDTO.Id_proveedor;
            _context.ProvMarcas.Add(proveedor_marca);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
        
        public Task Delete(int Id_Marca, int Id_Proveedor)
        {
            var ItemToRemove = _context.ProvMarcas.Find(Id_Marca, Id_Proveedor);
            _context.ProvMarcas.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public List<Proveedor_MarcaDTO> GetMarcaProveedor(int Id_Proveedor)
        {
            try
            {
                var data = _context.ProvMarcas
                    .Where(a => a.Id_proveedor == Id_Proveedor)
                    .Select(a => new Proveedor_MarcaDTO
                    {
                        Id_proveedor = a.Id_proveedor,
                        IDMarca = a.IDMarca,

                    });
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista" + Id_Proveedor, ex.Message, ex);
            }


        }

        
    }
}
