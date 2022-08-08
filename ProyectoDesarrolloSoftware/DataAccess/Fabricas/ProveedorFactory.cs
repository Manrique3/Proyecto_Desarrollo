﻿using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class ProveedorFactory
    {
        public static ProveedoresDAO CreateProviderDB()
        {
            return new ProveedoresDAO();
        }
    }
}