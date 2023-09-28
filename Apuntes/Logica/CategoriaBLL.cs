using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class CategoriaBLL
    {
        BDatosPruebaEntities Bd = new BDatosPruebaEntities();

        public void AddCategoria(string nombre)
        {
            //Verificaciones
            if (GetCategoria(nombre) == null)
            {
                Categoria nuevaCategoria = new Categoria();
                nuevaCategoria.Nombre = nombre;

                Bd.Categoria.Add(nuevaCategoria);
                Bd.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Ya existe la categoría");
            }

        }

        public Categoria GetCategoria(string nombre)
        {
            Categoria categoriaBuscada = Bd.Categoria.Where(c => c.Nombre == nombre).FirstOrDefault();
            return categoriaBuscada;
        }

        public List<Categoria> GetAllCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            categorias = Bd.Categoria.ToList();

            return categorias;
        }

        public void DeleteCategoria(string nombre)
        {
            Categoria categoriaEliminar = GetCategoria(nombre);

            if (categoriaEliminar != null)
            {
                Bd.Categoria.Remove(categoriaEliminar);
                Bd.SaveChanges();
            }
        }
    }
}
