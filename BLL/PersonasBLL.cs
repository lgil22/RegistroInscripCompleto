using System;
using System.Collections.Generic;
using System.Text;
using RegistroP.DAL;
using RegistroP.Entidades;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroP.DAL.Scripts;

namespace RegistroP.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Personas.Add(personas) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        //Este es el metodo para modificar en la base de datos
        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                //buscar las entidades que no estan para removerlas
               /* var Anterior = db.Personas.Find(personas.PersonaId);
                foreach (var item in Anterior.Telefono)
                {
                    if (!personas.Telefono.ToList().Exists(d => d.Id == item.Id))
                        db.Entry(item).State = EntityState.Deleted;
                }*/

                db.Entry(personas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        //Este es el metodo para eliminar en la base de datos
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Personas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
                //System.Data.Entity// No va
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        //Este es el metodo para buscar en la base de datos
        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas personas = new Personas();
            try
            {
                personas = db.Personas.Find(id);
                // El Count() lo que hace es engañar al lazyloading y obligarlo a cargar los detalles 
                //  estudiante.Telefono.Count();

                //persona = db.Personas
                //     .Include(x => x.Telefonos.Select(c => c.PersonaId))
                //             .Where(p => p.PersonaId == id)
                //             .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return personas;
        }

        //Este es el metodo para listar o consultar lo que tenemos en la base de datos
        public static List<Personas> GetList(Expression<Func<Personas, bool>> personas)
        {
            List<Personas> Lista = new List<Personas>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Personas.Where(personas).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}

