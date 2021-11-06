using Entidades.Clases_generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public abstract class Hardware
    {
        private string nombre;
        private Marca marca;
        private List<NuevosDatos> nuevosDatos;

        /// <summary>
        /// Devuelve/Escribe el nombre 
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Devuelve/Escribe la marca
        /// </summary>
        public Marca Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

      

        /// <summary>
        /// Devuelve/Escribe nuevos datos
        /// </summary>
        public List<NuevosDatos>NuevosDatos
        {
            get { return this.nuevosDatos; }
            set { this.nuevosDatos = value; }
        }

        /// <summary>
        /// Contructor sin parametros
        /// </summary>
        public Hardware()
        {
            this.nuevosDatos = new List<NuevosDatos>();
        }

        /// <summary>
        /// Contructor que recibe nombre,marca 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="marca"></param>
        /// <param name="memoria"></param>
        public Hardware(string nombre, Marca marca)
        : this()
        {
            this.nombre = nombre;
            this.marca = marca;
           
        }


        /// <summary>
        /// Contructor que recibe nombre,marca 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="marca"></param>
        /// <param name="memoria"></param>
        public Hardware( Marca marca, string nombre)
        : this()
        {
            this.nombre = nombre;
            this.marca = marca;

        }



        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="marca"></param>
        /// <param name="memoria"></param>
        public Hardware(string nombre, Marca.EMarca marca)
        : this(nombre, new Marca(marca))
        {

        }



        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="marca"></param>
        /// <param name="memoria"></param>
        public Hardware(Marca.EMarca marca,string nombre )
        : this(new Marca(marca), nombre)
        {

        }





        /// <summary>
        /// Sobrecarga para mostrar la info del hardware
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine(this.marca.ToString());
          

            return sb.ToString();
        }


        /// <summary>
        /// Info se podra sobreescribir en las clases heredadas
        /// </summary>
        /// <returns></returns>
        public virtual string Informar()
        {
            return ("");
        }

        /// <summary>
        /// Verifica si un hardware es igual a otro en relacion a su nombre,marca 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator ==(Hardware h1, Hardware h2)
        {
            return (h1.nombre == h2.nombre && h1.marca == h2.marca );
        }


        public static bool operator !=(Hardware h1, Hardware h2)
        {
            return !(h1 == h2);
        }

        /// <summary>
        /// Busca si los nuevos datos a ingresar ya estan.
        /// </summary>
        /// <param name="nue"></param>
        /// <param name="h"></param>
        /// <returns></returns>

        public static bool EncontrarNuevosDatos(NuevosDatos nue, Hardware h)
        {
            bool retorno = false;
            foreach (NuevosDatos item in h.NuevosDatos)
            {
                if(item==nue)
                {
                    retorno = true;
                }
            }
            return retorno;
        }



        /// <summary>
        /// determina si dos hardware son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Hardware && (Hardware)obj == this);
        }


    }
}
