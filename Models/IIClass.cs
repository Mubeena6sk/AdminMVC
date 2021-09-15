using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMVC.Models
{
    public class IIClass
    {
        public int Id { get; set; }
        public int Rid { get; set; }
        public int Iid { get; set; }

        public virtual IngredientsClass IidNavigation { get; set; }
        public virtual RecipeClass RidNavigation { get; set; }
    }
}
