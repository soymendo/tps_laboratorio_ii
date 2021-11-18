using Entidades.Clases_especializadas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_generales
{
   public static class Extensora
    {
        private static SqlConnection sqlConnection;

        public static List<PlacaVideo> LeerDB(this PlacaDao p)
        {
            string connection = "Server=.;DataBase=PlacaVideo;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connection);

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
                    Marca.EMarca marca = (Marca.EMarca)Enum.Parse(typeof(Marca.EMarca), sqlDataReader["Marca"].ToString());

                    PlacaVideo.ETipoMemoria tipoMemoria = (PlacaVideo.ETipoMemoria)Enum.Parse(typeof(PlacaVideo.ETipoMemoria), sqlDataReader["TipoDeMemoria"].ToString());

                    int CapacidadDeRam = Convert.ToInt32(sqlDataReader["CapacidadDeRam"]);
                    int FrecuenciaDeMemoria = Convert.ToInt32(sqlDataReader["FrecuenciaDeMemoria"]);
                    int Consumo = Convert.ToInt32(sqlDataReader["Consumo"]);
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
                throw new BaseDeDatosException("Ocurrió un error al tratar de leer la lista de celulares de la Base de Datos.", ex);
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
