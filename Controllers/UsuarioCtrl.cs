using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repository;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class UsuarioCtrl 
    {
        public static Usuario InsertUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome)) 
            {
                throw new Exception("Nome é obrigatório");
            }

            if (String.IsNullOrEmpty(Email)) 
            {
                throw new Exception("Email é obrigatório");
            }
            
            if (String.IsNullOrEmpty(Senha) || Senha.Length <= 8)
            {
                throw new Exception("Senha está inválida");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return new Usuario(Nome, Email, Senha);
        }

        

        public static IEnumerable<Usuario> VisualizarUsuario()
        {
            return Models.Usuario.GetUsuarios();  
        }
        
        public static void UpdateUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }

            if (!String.IsNullOrEmpty(Email))
            {
                usuario.Email = Email;
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                
                if (String.IsNullOrEmpty(Senha) || Senha.Length <= 8)
                {
                    throw new Exception("Senha está inválida");
                }
                else
                {
                    Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                    usuario.Senha = Senha;
                }
            }
            else
            {
                throw new Exception("Senha está inválida");
            }
            Usuario.AlterarUsuario(Id, Nome, Email, Senha);
        }

         public static Usuario DeleteUsuarios(int Id)
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }
    }
}