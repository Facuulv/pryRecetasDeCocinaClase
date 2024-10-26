using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecetasDeCocina
{
    public class Recetas
    {

        public List<Dictionary<string, object>> ListaRecetas;
        public Dictionary<string, object> Ingredientes { get; set; }

        public Recetas()
        {
            ListaRecetas = new List<Dictionary<string, object>>();
        }
                
        public void GuardarReceta(string nombre, List<Dictionary<string, object>> ingred)
        {
            Dictionary<string, object> nuevaRec = new Dictionary<string, object>();
            nuevaRec["nombre"] = nombre;
            nuevaRec["ingred"] = ingred;
            ListaRecetas.Add(nuevaRec);
        }

        public void MostrarIngredientesGrilla(DataGridView dgv, int indice)
        {
            dgv.Rows.Clear();
            if (indice >= 0 && indice < ListaRecetas.Count)
            {
                //Dictionary<string, object> recetaSeleccionada = ListaRecetas[indice];
                List<Dictionary<string, object>> ingSeleccionados = new List<Dictionary<string, object>>();
                ingSeleccionados = (List<Dictionary<string, object>>)ListaRecetas[indice]["ingred"];
                ingSeleccionados.ForEach(elemento =>
                {
                    dgv.Rows.Add(elemento["ingrediente"], elemento["cantidad"]);
                });
            } else
            {
                MessageBox.Show("Seleccione una receta válida", "Error");
            }
        }
    }    
}
