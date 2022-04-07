using System.Collections.Generic;
using System.Linq;
using Repository;
//using System.Windows.Forms;

namespace Models
{
    public class Usuario
    {
        public static Usuario UsuarioAuth;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario() { }

        public Usuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;

            Context db = new Context();
            db.Usuarios.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Email: {this.Email}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Usuario.ReferenceEquals(this, obj))
            {
                return false;
            }
            Usuario it = (Usuario) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = GetUsuario(Id);
            usuario.Nome = Nome;
            usuario.Email = Email;
            usuario.Senha = Senha;

            Context db = new Context();
            db.Usuarios.Update(usuario);
            db.SaveChanges();
        }


        public static IEnumerable<Usuario> GetUsuarios()
        {
            Context db = new Context();
            return (from Usuario in db.Usuarios select Usuario);
        }

        public static Usuario GetUsuario(int Id)
        {
            Context db = new Context();
            IEnumerable<Usuario> usuarios = from Usuario in db.Usuarios
                            where Usuario.Id == Id
                            select Usuario;

            return usuarios.First();
        }

        public static void RemoverUsuario(Usuario usuario)
        {
            Context db = new Context();
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }

        public static void Auth(string Email, string Senha)
        {
            Usuario usuario = GetUsuarios()
                .Where(it => it.Email == Email 
                    && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)
                )
                .First();
            
            UsuarioAuth = usuario;
        }
    }
}