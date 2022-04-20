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

        public static IEnumerable<Tag> VisualizarTag()
        {
            return Models.Tag.GetTags();  
        }
    }
}