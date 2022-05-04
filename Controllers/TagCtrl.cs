using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repository;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class TagCtrl 
    {

        public static Tag InsertTag(string Descricao)
        {

            if (String.IsNullOrEmpty(Descricao)) 
            {
                throw new Exception("Descrição é obrigatório");
            }

            return new Tag(Descricao);
        }
        public static IEnumerable<Tag> VisualizarTag()
        {
            return Models.Tag.GetTags();  
        }

        public static Tag DeleteTags(int Id)
        {
            Tag tag = Models.Tag.GetTag(Id);
            Tag.RemoverTag(tag);
            return tag;
        }
    }
}