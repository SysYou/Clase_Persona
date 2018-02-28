using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fidelitas.BS
{
    public class Mantenimiento : IMantenimiento
    {
        private static Mantenimiento instancia;

        public static Mantenimiento Instancia
        {
            get {
                if (instancia == null) { 
                    return new Mantenimiento();
                }    
                return instancia; 
            
            }
            set {
                if (instancia == null)
                {
                    instancia = value;     
                }                    
            }
        }

        public void Insertar(DO.Persona persona)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.Mantenimiento.Instancia.Insertar(persona);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public List<DO.Persona> Mostrar()
        {
            List<DO.Persona> lista = new List<DO.Persona>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = DAL.Mantenimiento.Instancia.Mostrar();
                    scope.Complete();
                }
                return lista;
            }
            catch (Exception ee)
            {
                
                throw;
            }
        }

        public void Actualizar(DO.Persona persona)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.Mantenimiento.Instancia.Actualizar(persona);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void Borrar(DO.Persona persona)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.Mantenimiento.Instancia.Borrar(persona);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
