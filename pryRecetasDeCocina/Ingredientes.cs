using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecetasDeCocina
{
    public class Ingredientes
    {
        public List<Dictionary<string, object>> ingredientes { get; set; }

        public Ingredientes()
        {
            ingredientes = new List<Dictionary<string, object>>();
        }

        public void AgregarIngredientes(string ingrediente, int cantidad)
        {
            Dictionary<string, object> auxIng = new Dictionary<string, object>();
            //auxIng.Add("ingrediente", ingrediente);
            //auxIng.Add("cantidad", cantidad);
            auxIng["ingrediente"] = ingrediente;
            auxIng["cantidad"] = cantidad;
            ingredientes.Add(auxIng);
        }
    }
}
