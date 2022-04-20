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
    }
}