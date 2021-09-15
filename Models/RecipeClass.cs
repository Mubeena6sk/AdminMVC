using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMVC.Models
{
    public class RecipeClass
    {

            public RecipeClass()
            {
                IngredientsIndices = new HashSet<IIClass>();
            }

            public int Rid { get; set; }
            public string Rname { get; set; }
            public string Instructions { get; set; }

            public virtual ICollection<IIClass> IngredientsIndices { get; set; }
        }
    }

