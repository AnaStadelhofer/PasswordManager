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

         public static Usuario DeleteUsuarios(int Id)
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }
    }
}