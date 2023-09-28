using Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class TareaBLL
    {
        //Se crea el elemento que va a permitir manejar la base de datos
        BDatosPruebaEntities Bd = new BDatosPruebaEntities();

        //El primer método es get ya que este va a permitir realizar verificaciones en el método add
        public Tarea GetTarea(string titulo)
        {
            Tarea tareaBuscada = Bd.Tarea.Where(t => t.Titulo == titulo).FirstOrDefault();
            return tareaBuscada;
        }

        //Método agregar una tarea
        public void AddTarea(string titulo, string cuerpo, DateTime fechaAct, DateTime fechaVenc, char estado, int idCategoria)
        {
            //Verificar que no exista la tarea
            if (GetTarea(titulo) == null)
            {
                Tarea nuevaTarea = new Tarea();
                nuevaTarea.Titulo = titulo;
                nuevaTarea.Cuerpo = cuerpo;
                nuevaTarea.FechaCreacion = fechaAct;
                nuevaTarea.FechaVencimiento = fechaVenc;
                nuevaTarea.Estado = estado.ToString();
                nuevaTarea.IdCategoria = idCategoria;
                Bd.Tarea.Add(nuevaTarea);
                Bd.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Ya existe una tarea con el mismo título");
            }
        }

        //Metodo cargar todas las tareas
        public List<Tarea> GetAllTareas()
        {

            List<Tarea> tareas = new List<Tarea>();

            tareas = Bd.Tarea.ToList();

            return tareas;
        }


        //Método para editar Tareas
        public void EditTarea(Tarea tareaEditar)
        {
            // Buscar la tarea que se va a editar por su ID
            Tarea tareaExistente = Bd.Tarea.FirstOrDefault(t => t.Id == tareaEditar.Id);

            if (tareaExistente != null)
            {
                // Actualizar los datos de la tarea existente con los nuevos datos
                tareaExistente.Titulo = tareaEditar.Titulo;
                tareaExistente.Cuerpo = tareaEditar.Cuerpo;
                tareaExistente.FechaCreacion = tareaEditar.FechaCreacion;
                tareaExistente.FechaVencimiento = tareaEditar.FechaVencimiento;
                tareaExistente.Estado = tareaEditar.Estado;

                // Guardar los cambios en la base de datos
                Bd.SaveChanges();
            }
        }

        //Método para eliminar tareas

        public void DeleteTarea(string nombre)
        {
            Tarea tareaEliminar = GetTarea(nombre);

            if (tareaEliminar != null)
            {
                Bd.Tarea.Remove(tareaEliminar);
                Bd.SaveChanges();
            }

        }

    }
}
