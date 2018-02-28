using Fidelitas.DO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidelitas.DAL
{
    public class Mantenimiento:IMantenimiento
    {
        private static Mantenimiento instancia;

        public static Mantenimiento Instancia
        {
            get
            {
                if (instancia == null)
                {
                    return new Mantenimiento();
                }
                return instancia;

            }
            set
            {
                if (instancia == null)
                {
                    instancia = value;
                }
            }
        }

        public void Insertar(DO.Persona persona)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            DbConnection conn = null;

            DbCommand comm = null;



            try
            {

                conn = factory.CreateConnection();

                conn.ConnectionString = Settings.Default.connection;

                comm = factory.CreateCommand();



                DbParameter param1 = factory.CreateParameter();

                DbParameter param2 = factory.CreateParameter();

                DbParameter param3 = factory.CreateParameter();

                DbParameter param4 = factory.CreateParameter();

                DbParameter param5 = factory.CreateParameter();

               // DbParameter param6 = factory.CreateParameter();



                //Carga de Parametros

                /*param1.ParameterName = "@iCedula";

                param1.DbType = System.Data.DbType.Int32;

                param1.Value = persona.ICedula;*/



                param1.ParameterName = "@vNombre";

                param1.DbType = System.Data.DbType.String;

                param1.Value = persona.VNombre;



                param2.ParameterName = "@bMuerto";

                param2.DbType = System.Data.DbType.Boolean;

                param2.Value = persona.BMuerto;



                param3.ParameterName = "@dtNacimiento";

                param3.DbType = System.Data.DbType.Date;

                param3.Value = persona.DTNacimiento;



                param4.ParameterName = "@iEdad";

                param4.DbType = System.Data.DbType.Int32;

                param4.Value = persona.IEdad;



                param5.ParameterName = "@vEmail";

                param5.DbType = System.Data.DbType.String;

                param5.Value = persona.VEmail;



                //Abrir Coneccion 

                comm.Connection = conn;

                conn.Open();



                //Ejecutar Store Procedure

                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.CommandText = "sp_insertar_identity";

                comm.Parameters.Add(param1);

                comm.Parameters.Add(param2);

                comm.Parameters.Add(param3);

                comm.Parameters.Add(param4);

                comm.Parameters.Add(param5);

                //comm.Parameters.Add(param6);

                comm.ExecuteNonQuery();

            }

            catch (Exception ee)
            {

                throw;

            }

            finally
            {

                comm.Dispose();

                conn.Dispose();

            }
        }

        public List<DO.Persona> Mostrar()
        {
            //Inicializamos
            List<Persona> lista = new List<Persona>();

            //Conex
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();
                //Abrir connection 
                comm.Connection = conn;
                conn.Open();

                //Ejecuta SP
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Mostrar";

                using(IDataReader dataReader = comm.ExecuteReader()){
                    Persona persona;
                    while(dataReader.Read()){
                        persona = new Persona();
                        
                        persona.ICedula = Convert.ToInt32(dataReader["iCedula"].ToString());
                        persona.VNombre =dataReader["vNombre"].ToString();
                        persona.BMuerto = Convert.ToBoolean(dataReader["bMuerto"].ToString());
                        persona.DTNacimiento = Convert.ToDateTime(dataReader["dtNacimiento"]);
                        persona.IEdad = Convert.ToInt32(dataReader["iEdad"].ToString());
                        persona.VEmail = dataReader["vEmail"].ToString();                        

                        lista.Add(persona);
                    }                        
                }
                return lista;
            }
            catch(Exception ee) {
                throw;
            }           
        }

        public void Actualizar(DO.Persona persona)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                DbParameter param1 = factory.CreateParameter();
                DbParameter param2 = factory.CreateParameter();
                DbParameter param3 = factory.CreateParameter();
                DbParameter param4 = factory.CreateParameter();
                DbParameter param5 = factory.CreateParameter();
                DbParameter param6 = factory.CreateParameter();

                //Carga de Parametros
                param1.ParameterName = "@iCedula";
                param1.DbType = System.Data.DbType.Int32;
                param1.Value = persona.ICedula;

                param2.ParameterName = "@vNombre";
                param2.DbType = System.Data.DbType.String;
                param2.Value = persona.VNombre;

                param3.ParameterName = "@bMuerto";
                param3.DbType = System.Data.DbType.Boolean;
                param3.Value = persona.BMuerto;

                param4.ParameterName = "@dtNacimiento";
                param4.DbType = System.Data.DbType.Date;
                param4.Value = persona.DTNacimiento;

                param5.ParameterName = "@iEdad";
                param5.DbType = System.Data.DbType.Int32;
                param5.Value = persona.IEdad;

                param6.ParameterName = "@vEmail";
                param6.DbType = System.Data.DbType.String;
                param6.Value = persona.VEmail;

                //Abrir Coneccion 
                comm.Connection = conn;
                conn.Open();

                //Ejecutar Store Procedure
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Actualizar";
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.Parameters.Add(param4);
                comm.Parameters.Add(param5);
                comm.Parameters.Add(param6);
                comm.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                conn.Dispose();
            }
        }

        public void Borrar(DO.Persona persona)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            DbConnection conn = null;

            DbCommand comm = null;



            try
            {

                conn = factory.CreateConnection();

                conn.ConnectionString = Settings.Default.connection;

                comm = factory.CreateCommand();



                DbParameter param1 = factory.CreateParameter();

                



                //Carga de Parametros

                param1.ParameterName = "@iCedula";

                param1.DbType = System.Data.DbType.Int32;

                param1.Value = persona.ICedula;


                //Abrir Coneccion 

                comm.Connection = conn;

                conn.Open();



                //Ejecutar Store Procedure

                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.CommandText = "sp_Eliminar";

                comm.Parameters.Add(param1);

                comm.ExecuteNonQuery();

            }

            catch (Exception ee)
            {

                throw;

            }

            finally
            {

                comm.Dispose();

                conn.Dispose();

            }
        }
    }
}
