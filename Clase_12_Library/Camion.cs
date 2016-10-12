﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clase_12_Library
{
    public class Camion:Vehiculo
    {
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        protected override short CantidadRuedas
        {
            get
            {
                return 8;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : "+CantidadRuedas);
            sb.Append("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
 