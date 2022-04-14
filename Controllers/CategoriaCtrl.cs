using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repository;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class CategoriaCtrl 
    {
        public static Categoria InsertCategoria(
            string Nome,
            string Descricao
            
        )
        {
            if (String.IsNullOrEmpty(Nome)) {
                throw new Exception("Nome é obrigatório");
            }

            return new Categoria(Nome, Descricao);
        }

        public static List<Categoria> VisualizarCategoria()
        {
            return Models.Categoria.GetCategorias();  
        }
    }
}