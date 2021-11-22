using Entidades.Clases_generales;
using Entidades.Exepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;

namespace Entidades.Clases_especializadas
{
    public class PlacaDao
    {
        private SqlConnection sqlConnection;

        public PlacaDao()
        {
            string connection = "Server=.;DataBase=PlacaVideo;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connection);
        }



        /// <summary>
        /// Inserta un objto PlacaVideo en la base de datos
        /// </summary>
        /// <param name="placa"></param>
        public void InsertarPlaca(PlacaVideo placa)
        {

            try
            {
                string command = $"INSERT INTO PlacasVideo(Nombre,Marca,TipoDeMemoria,CapacidadDeRam,FrecuenciaDeMemoria,Consumo,Longitud,InterfazPci,MineriaBitrcoin,MineriaEthereum)" +
                $"VALUES(@Nombre,@Marca,@TipoDeMemoria,@CapacidadDeRam,@FrecuenciaDeMemoria,@Consumo,@Longitud,@InterfazPci,@MineriaBitrcoin,@MineriaEthereum)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("Nombre", placa.Nombre);
                sqlCommand.Parameters.AddWithValue("Marca", placa.Marca.MarcaProducto.ToString());
                sqlCommand.Parameters.AddWithValue("TipoDeMemoria", placa.TipoDeMemoria.ToString());
                sqlCommand.Parameters.AddWithValue("CapacidadDeRam", placa.CapacidadDeRam);
                sqlCommand.Parameters.AddWithValue("FrecuenciaDeMemoria", placa.FrecuenciaDeMemoria);
                sqlCommand.Parameters.AddWithValue("Consumo", placa.Consumo);
                sqlCommand.Parameters.AddWithValue("Longitud", placa.Longitud);
                sqlCommand.Parameters.AddWithValue("InterfazPci", placa.Interfaz);
                sqlCommand.Parameters.AddWithValue("MineriaBitrcoin", placa.MineriaBitcoin);
                sqlCommand.Parameters.AddWithValue("MineriaEthereum", placa.MineriaEthereum);




                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }

            }
        }


        /// <summary>
        /// Borra un objeto PlacaVideo de la base de datos a traves del nombre 
        /// </summary>
        /// <param name="nombre"></param>
        public void Borrar(string nombre)
        {
            try
            {
                string sentencia = "DELETE FROM PlacasVideo where Nombre=@Nombre";
                SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Nombre",nombre);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Lee la lista de PlacaVideo disponible en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<PlacaVideo> Leer()
        {
            try
            {
                string sentencia = "SELECT * FROM PlacasVideo";
                SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<PlacaVideo> productos = new List<PlacaVideo>();
                PlacaVideo placa;

                while (sqlDataReader.Read())
                {
                    string nombre = sqlDataReader["Nombre"].ToString();
                    Marca.EMarca marca = (Marca.EMarca)Enum.Parse(typeof(Marca.EMarca),sqlDataReader["Marca"].ToString());    
                    
                    PlacaVideo.ETipoMemoria tipoMemoria= (PlacaVideo.ETipoMemoria)Enum.Parse(typeof(PlacaVideo.ETipoMemoria),sqlDataReader["TipoDeMemoria"].ToString());

                    int CapacidadDeRam = Convert.ToInt32(sqlDataReader["CapacidadDeRam"]);
                    int FrecuenciaDeMemoria= Convert.ToInt32(sqlDataReader["FrecuenciaDeMemoria"]);
                    int Consumo= Convert.ToInt32(sqlDataReader["Consumo"]);
                    int Longitud = Convert.ToInt32(sqlDataReader["Longitud"]);
                    double Interfaz = Convert.ToDouble(sqlDataReader["InterfazPci"]);
                    double MineriaBitcoin = Convert.ToDouble(sqlDataReader["MineriaBitrcoin"]);
                    double MineriaEthereum = Convert.ToDouble(sqlDataReader["MineriaEthereum"]);

                    placa = new PlacaVideo(nombre, marca);
                    placa.TipoDeMemoria = tipoMemoria;
                    placa.CapacidadDeRam = CapacidadDeRam;
                    placa.FrecuenciaDeMemoria = FrecuenciaDeMemoria;
                    placa.Consumo = Consumo;
                    placa.Longitud = Longitud;
                    placa.Interfaz = Interfaz;
                    placa.MineriaBitcoin = MineriaBitcoin;
                    placa.MineriaEthereum = MineriaEthereum;

                    productos.Add(placa);


                }
                return productos;
            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Ocurrió un error al tratar de leer la lista de Placas de la Base de Datos.", ex);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }





    }
}
