using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecetasDeCocina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvRecetas.Columns.Add("col0", "Ingredientes");
            dgvRecetas.Columns.Add("col1", "Cantidad");
        }

        Recetas nuevaReceta = new Recetas();
        Ingredientes IngredientesReceta = new Ingredientes();
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {           
            string nombre = txtNombre.Text;           
            if (nombre != "" && IngredientesReceta.ingredientes.Count > 0)
            {                                
                List<Dictionary<string, object>> aux = new List<Dictionary<string, object>>();
                for (int i = 0; i <= IngredientesReceta.ingredientes.Count - 1; i++)
                {
                    aux.Add(IngredientesReceta.ingredientes[i]);
                }

                nuevaReceta.GuardarReceta(nombre, aux);

                cmbRecetas.Items.Add(nombre);
                txtNombre.Text = "";
                MessageBox.Show($"La receta {nombre} se ha creado con exito", "Atencion");
                IngredientesReceta.ingredientes.Clear();
            } else
            {
                MessageBox.Show("Debe nombrar la receta o agregar ingredientes", "Error");
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string ing = txtIngred.Text;
            int cant = Convert.ToInt16(numCant.Value);
            if (ing != "" && cant > 0)
            {
                IngredientesReceta.AgregarIngredientes(ing, cant);
                txtIngred.Text = "";
                numCant.Value = 0;
                MessageBox.Show("Se ha agregado el ingrediente", "Atencion");
            } else
            {
                MessageBox.Show("Debe agregar ingrediente y cantidad", "Error");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvRecetas.Rows.Clear();
            int ind = cmbRecetas.SelectedIndex;
            lblReceta.Text = "Receta: " + nuevaReceta.ListaRecetas[ind]["nombre"].ToString();
            nuevaReceta.MostrarIngredientesGrilla(dgvRecetas, ind);
            /*dgvRecetas.Rows.Clear();
            int ind = cmbRecetas.SelectedIndex;
            lblReceta.Text = "Receta: " + nuevaReceta.ListaRecetas[ind]["nombre"].ToString();
            if (ind >= 0 && ind < nuevaReceta.ListaRecetas.Count)
            {
                List<Dictionary<string, object>> ingSeleccionados = new List<Dictionary<string, object>>();
                ingSeleccionados = (List<Dictionary<string, object>>)nuevaReceta.ListaRecetas[ind]["ingred"];
                ingSeleccionados.ForEach(elemento =>
                {
                    dgvRecetas.Rows.Add(elemento["ingrediente"], elemento["cantidad"]);
                });
            }
            else
            {
                MessageBox.Show("Seleccione una receta válida", "Error");
            }*/
        }
    }
}
