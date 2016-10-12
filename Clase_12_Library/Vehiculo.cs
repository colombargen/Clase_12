using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }
        protected EMarca _marca;
        protected string _patente;
        protected ConsoleColor _color;

        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadRuedas { get;}

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (!object.ReferenceEquals(v1,null) && !object.ReferenceEquals(v2,null))
            {
                if (v1._patente == v2._patente)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        public Vehiculo(EMarca marca, string patente, ConsoleColor color)
        {
            _marca = marca;
            _patente = patente;
            _color = color;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
