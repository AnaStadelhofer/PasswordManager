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

        public static void UpdateTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = Models.Tag.GetTag(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                tag.Descricao = Descricao;
            }

            Tag.AlterarTag(Id, Descricao);
        }
        
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