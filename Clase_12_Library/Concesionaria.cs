using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clase_12_Library
{
    public class Concesionaria
    {
        List<Vehiculo> _vehiculos;
        int _espacioDisponible;
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }

        #region "Constructores"
        private Concesionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        public Concesionaria(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Concesionaria.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concesionaria">Concecionaria a exponer</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Concesionaria concesionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concesionaria._vehiculos.Count, concesionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concesionaria._vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil:
                        if(v is Automovil)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if(v is Moto)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Camion:
                        if(v is Camion)
                            sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible
        /// </summary>
        /// <param name="concesionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concesionaria operator +(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if (concesionaria._vehiculos.Count >= concesionaria._espacioDisponible)
                return concesionaria;
            foreach (Vehiculo v in concesionaria._vehiculos)
            {
                if (v == vehiculo)
                    return concesionaria;
            }

            concesionaria._vehiculos.Add(vehiculo);
            return concesionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria
        /// </summary>
        /// <param name="concesionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concesionaria operator -(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in concesionaria._vehiculos)
            {
                if (v == vehiculo)
                {
                    concesionaria._vehiculos.Remove(v);
                    break;
                }
            }

            return concesionaria;
        }
        #endregion
    }
}
