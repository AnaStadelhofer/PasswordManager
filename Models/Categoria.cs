using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Categoria() { }

        public Categoria(
            string Nome,
            string Descricao
        )
        {
            this.Nome = Nome;
            this.Descricao = Descricao;

            Context db = new Context();
            db.Categorias.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Descricao: {this.Descricao}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Categoria.ReferenceEquals(this, obj))
            {
                return false;
            }
            Categoria it = (Categoria) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = GetCategoria(Id);
            categoria.Nome = Nome;
            categoria.Descricao = Descricao;

            Context db = new Context();
            db.Categorias.Update(categoria);
            db.SaveChanges();
        }


        public static IEnumerable<Categoria> GetCategorias()
        {
            Context db = new Context();
            return (from Categoria in db.Categorias select Categoria);
        }

        public static Categoria GetCategoria(int Id)
        {
            Context db = new Context();
            IEnumerable<Categoria> categorias = from Categoria in db.Categorias
                            where Categoria.Id == Id
                            select Categoria;

            return categorias.First();
        }

        public static void RemoverCategoria(Categoria categoria)
        {
            Context db = new Context();
            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }
    }
}