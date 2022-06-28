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
    public class PolizaDAO : IPolizaDAO
    {
        public readonly DSDBContext _context;

        public PolizaDAO(DSDBContext context)
        {
            _context = context;
        }

        public PolizaDTO GetPoliza(int Id_Poliza)
        {
            var query = _context.Polizas
                .Where(p => p.Id_Poliza == Id_Poliza)
                .Select(p => new PolizaDTO
                {
                    Id_Poliza = p.Id_Poliza,
                    Tipo = p.Tipo,
                    fk_vehiculo = p.fk_vehiculo,
                    fk_asegurado = p.fk_asegurado,
                });
            return query.First();
        }

        public Task AddVehiculo(VehiculoDTO vehiculoDTO)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Placa = vehiculoDTO.Placa;
            vehiculo.Modelo = vehiculoDTO.Modelo;
            vehiculo.Año = vehiculoDTO.Año;
            vehiculo.color = vehiculoDTO.Color;
            vehiculo.puestos = vehiculoDTO.Puestos;
            vehiculo.SerialMotor = vehiculoDTO.SerialMotor;
            vehiculo.fk_marca = vehiculoDTO.fk_marca;
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddPoliza(PolizaDTO polizaDTO)
        {
            Poliza poliza = new Poliza();
            poliza.Id_Poliza = polizaDTO.Id_Poliza;
            poliza.Tipo = polizaDTO.Tipo;
            poliza.fk_vehiculo = polizaDTO.fk_vehiculo;
            poliza.fk_asegurado = polizaDTO.fk_asegurado;
            _context.Polizas.Add(poliza);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task updateTipo(PolizaDTO polizaDTO, int Id_Poliza)
        {
            var itemToUpdate = _context.Polizas.Find(Id_Poliza);
            itemToUpdate.Tipo = polizaDTO.Tipo;
            _context.SaveChanges();

            return Task.CompletedTask;
        }
        public Task Delete(int Id_Poliza)
        {
            var ItemToRemove = _context.Polizas.Find(Id_Poliza);
            _context.Polizas.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
