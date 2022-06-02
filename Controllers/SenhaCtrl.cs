using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repository;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class SenhaCtrl 
    {
        public static IEnumerable<Senha> VisualizarSenha()
        {
            return Models.Senha.GetSenhas();  
        }

        public static Senha DeleteSenha(int Id)
        {
            Senha senhas = Models.Senha.GetSenha(Id);
            Senha.RemoverSenha(senhas);
            return senhas;
        }

        public static Senha InsertSenha(string Nome,
                                        int CategoriaId,
                                        string Url,
                                        string Usuario, 
                                        string SenhaEncrypt, 
                                        string Procedimento)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }
            return new Senha(Nome, CategoriaId, Url, Usuario,  SenhaEncrypt,  Procedimento);
        }

        public static void UpdateSenha(int Id,
                                       string Nome,
                                       int CategoriaId,
                                       string Url,
                                       string Usuario, 
                                       string SenhaEncrypt, 
                                       string Procedimento)
        {
            Senha senha = Models.Senha.GetSenha(Id);
            if (!String.IsNullOrEmpty(Nome))
            {
                senha.Nome = Nome;
            }
            if (CategoriaId != 0)
            {
                senha.CategoriaId = CategoriaId;
            }
            if (!String.IsNullOrEmpty(Url))
            {
                senha.Url = Url;
            }
             if (!String.IsNullOrEmpty(Usuario))
            {
                senha.Usuario = Usuario;
            }
            if (!String.IsNullOrEmpty(SenhaEncrypt))
            {
                senha.SenhaEncrypt = SenhaEncrypt;
            }
            if (!String.IsNullOrEmpty(Procedimento))
            {
                senha.Procedimento = Procedimento;
            }
            Senha.AlterarSenha(Id, Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }
    }
}

