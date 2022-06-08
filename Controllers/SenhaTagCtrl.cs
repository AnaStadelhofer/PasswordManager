using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repository;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class SenhaTagCtrl 
    {
        public static SenhaTag InsertSenhaTag(
            int SenhaId,
            int TagId
            
        )
        {
            if (TagId != null) {
                throw new Exception("É obrigatorio informar uma Tag");
            }
            return new SenhaTag(SenhaId, TagId);
        }       
    }
}