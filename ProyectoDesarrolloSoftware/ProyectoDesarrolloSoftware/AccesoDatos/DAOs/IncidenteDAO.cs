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
    public class IncidenteDAO : IIncidenteDAO
    {
        public readonly DSDBContext _context;

        public IncidenteDAO(DSDBContext context)
        {
            _context = context;
        }


        public Task AddVehiculoTercaro(VehiculoDTO vehiculoDTO)
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

        public Task Add(IncidenteDTO incidenteDTO)
        {
            Incidente incidente = new Incidente();
            incidente.Id_Incidente = incidenteDTO.Id_Incidente;
            incidente.estadoEv = incidenteDTO.estadoEv;
            incidente.fk_vehiculo_tercero = incidenteDTO.fk_vehiculo_tercero;
            incidente.fk_Poliza = incidenteDTO.fk_Poliza;

            _context.Incidentes.Add(incidente);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(IncidenteDTO incidenteDTO, int Id_Incidente)
        {
            var itemToUpdate = _context.Incidentes.Find(Id_Incidente);
            itemToUpdate.estadoEv = incidenteDTO.estadoEv;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Delete(int Id_Incidente)
        {
            var ItemToRemove = _context.Incidentes.Find(Id_Incidente);
            _context.Incidentes.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public IncidenteDTO GetIncidente(int Id_Incidente)
        {
            var query = _context.Incidentes
                .Where(a => a.Id_Incidente == Id_Incidente)
                .Select(a => new IncidenteDTO
                {
                    Id_Incidente = a.Id_Incidente,
                    estadoEv = a.estadoEv,
                    fk_vehiculo_tercero = a.fk_vehiculo_tercero,
                    fk_Poliza = a.fk_Poliza

                });
            return query.First();
        }
    }
}

