using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMVC.Models
{
    public class IngredientsClass
    {
        public string IName;

        public IngredientsClass()
        {
            IngredientsIndices = new HashSet<IIClass>();
        }

        public int Iid { get; set; }
      //  public int IName { get; set; }


        public virtual ICollection<IIClass> IngredientsIndices { get; set; }
    }
}
