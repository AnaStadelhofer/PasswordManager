using System.Collections.Generic;
using System.Linq;
using Repository;
using Microsoft.EntityFrameworkCore;
//using System.Windows.Forms;

namespace Models
{
    public class Senha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Url { get; set; }
        public string Usuario { get; set; }
        public string SenhaEncrypt { get; set; }
        public string Procedimento { get; set; }


        public Senha() { }

        public Senha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            this.Nome = Nome;
            this.CategoriaId = CategoriaId;
            this.Url = Url;
            this.Usuario = Usuario;
            this.SenhaEncrypt = SenhaEncrypt;
            this.Procedimento = Procedimento;

            Context db = new Context();
            db.Senhas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Categoria: {this.Categoria.Nome}"
                + $"\n Url: {this.Url}"
                + $"\n Usuario: {this.Usuario}"
                + $"\n Procedimento: {this.Procedimento}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Senha.ReferenceEquals(this, obj))
            {
                return false;
            }
            Senha it = (Senha) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static void AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = GetSenha(Id);
            senha.Nome = Nome;
            senha.CategoriaId = CategoriaId;
            senha.Url = Url;
            senha.Usuario = Usuario;
            senha.SenhaEncrypt = SenhaEncrypt;
            senha.Procedimento = Procedimento;

            Context db = new Context();
            db.Senhas.Update(senha);
            db.SaveChanges();
        }


        public static IEnumerable<Senha> GetSenhas()
        {
            Context db = new Context();
            return db.Senhas.Include("Categoria");
        }

        public static Senha GetSenha(int Id)
        {
            Context db = new Context();
            IEnumerable<Senha> senhas = from Senha in db.Senhas
                            where Senha.Id == Id
                            select Senha;

            return senhas.First();
        }

        public static void RemoverSenha(Senha senha)
        {
            foreach (SenhaTag item in SenhaTag.GetBySenhaId(senha.Id))
            {
                SenhaTag.RemoverSenhaTag(item);
            }
            Context db = new Context();
            db.Senhas.Remove(senha);
            db.SaveChanges();
        }
    }
}