﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Shared.Response
{
    public class BaseResponse
    {
        public string? MensajeError { get; set; }
        public bool Exito { get; set; }
    }
}
