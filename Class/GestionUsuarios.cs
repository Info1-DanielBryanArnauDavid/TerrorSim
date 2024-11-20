using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Class
{
    public class GestionUsuarios
    {
        private SqliteConnection cnx;
        public void Iniciar()
        {
            string dataSource = "Data Source=practica.db";
            cnx = new SqliteConnection(dataSource);
            cnx.Open();
        }

        public void Cerrar()
        {
            cnx.Close();
        }
        public int CrearBaseDeUsuarios()
        {
            string sql = "CREATE TABLE IF NOT EXISTS Usuarios ( Usuario varchar, Contraseña varchar)";
            SqliteCommand command = new SqliteCommand(sql, cnx);
            try
            {
                command.ExecuteNonQuery();
                return 1;
            }

            catch (Exception)
            {
                return 0;
            }



        }


        public int ComprovarSiElUsuarioExiste(string Usuario, string Contraseña)
        {
            CrearBaseDeUsuarios();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Usuarios WHERE Usuario = '"+Usuario+"'";
            SqliteCommand command = new SqliteCommand(sql, cnx);
            var reader = command.ExecuteReader();
            dt.Load(reader);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            
            return 0;
        }
        public void AñadirUsuario( string Usuario, string Contraseña)
        {
            string sql = "INSERT INTO Usuarios VALUES ('"+Usuario+"', '"+Contraseña+"')";
            SqliteCommand command = new SqliteCommand(sql, cnx);
            command.ExecuteNonQuery();


        }

        public int ComprovarSiElUsuarioiContraseñaExiste(string Usuario, string Contraseña)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Usuarios WHERE Usuario = '" + Usuario + "' AND Contraseña = '"+Contraseña+"'";
            SqliteCommand command = new SqliteCommand(sql, cnx);
            var reader = command.ExecuteReader();
            dt.Load(reader);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }

            return 0;
        }

        public void EliminarTabla()
        {
            string sql = "DROP TABLE Usuarios";
            SqliteCommand command = new SqliteCommand(sql, cnx);
            command.ExecuteNonQuery();
        }

    }
}
