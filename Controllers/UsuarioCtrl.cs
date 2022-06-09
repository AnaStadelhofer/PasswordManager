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
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            
            if (String.IsNullOrEmpty(Nome)) 
            {
                throw new Exception("Nome é obrigatório");
            }

            if (String.IsNullOrEmpty(Email)) 
            {
                throw new Exception("Email é obrigatório");
            }

            if(!validateEmailRegex.IsMatch(Email))
            {
                throw new Exception("Email está invalido");
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
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }

            if (validateEmailRegex.IsMatch(Email))
            {
                usuario.Email = Email;
            } 
            else 
            {
                throw new Exception("Email inválido");
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                
                if (String.IsNullOrEmpty(Senha) || Senha.Length < 8)
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