using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySp1FerMoya
{
    public partial class frmAutocor : Form
    {
        // definimos en nombre del archivo en una constante
        private const string PATH_ARCHIVO = "Repuestos.txt";

        public frmAutocor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializar();
        }
        private void Inicializar()
        {
            txtCodigo.Text = ""; // limpiar los textBox
            txtNombre.Text = "";
            txtPrecio.Text = "";
            // cargar el comboBox
            cmdMarca.Items.Clear();
            cmdMarca.Items.Add("Marca A");
            cmdMarca.Items.Add("Marca B");
            cmdMarca.Items.Add("Marca C");
            cmdMarca.SelectedIndex = 0;
            // marcar la opción de origen Nacional
            optNacional.Checked = true;
        }

        //esto es para que me enliste los datos que voy a grabar en la clase repuestos 
        List<ClassRepuestos> Datos = new List<ClassRepuestos>();
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ClassRepuestos objRepuesto = new ClassRepuestos();

            objRepuesto.nombre = txtNombre.Text;
            objRepuesto.codigo = int.Parse(txtcodigo.Text);
            objRepuesto.precio = int.Parse(txtprecio.Text);
            objRepuesto.marca = cmdMarca.Text;

            if (optImportado.Checked == true)
            {
                objRepuesto.origen = false;

            }
            if (optNacional.Checked)
            {
                objRepuesto.origen = true;
            }

            MessageBox.Show("Grabacion exitosa");

            //aca agrego los Datos que seria lo que voy a enlistar
            Datos.Add(objRepuesto);

            private ClassRepuestos CrearRepuesto()

            {
                // se crea un nuevo objeto de tipo Repuesto
                ClassRepuestos nuevoRep = new ClassRepuestos();
                // se asignan los valores a todas sus propiedades
                nuevoRep.codigo = txtCodigo.Text;
                nuevoRep.nombre = txtNombre.Text;
                nuevoRep.marca = cmdMarca.SelectedItem.ToString();
                nuevoRep.precio = decimal.Parse(txtPrecio.Text);
                if (optNacional.Checked)
                {
                    nuevoRep.origen = "Nacional";
                }
                else
                {
                    nuevoRep.origen = "Importado";
                }
                return nuevoRep; // devuelve el objeto creado con sus valores
            }

            private bool ValidarDatos()

            {
                // devuelve falso si no se cumplen todas las condiciones
                bool resultado = false;
                if (txtCodigo.Text != "") // controla el valor del código
                {
                    if (txtNombre.Text != "") // controla el nombre
                    {
                        if (txtPrecio.Text != "") // controla el precio
                        {
                            ClassArchivo Repuestos = new ClassArchivo();
                            Repuestos.NombreArchivo = PATH_ARCHIVO;
                            // controla que no se repita el código del repuesto
                            if (Repuestos.BuscarCodigoRepuesto(txtCodigo.Text) == false)

                            {
                                resultado = true; // devuelve verdadero sólo si todas
                                                  // las condiciones se cumplieron

                            }

                        }
                    }
                }
                return resultado;
            }

            private void btnCancelar_Click(object sender, EventArgs e)
            {
                Inicializar();
            }

            private void btnConsultar_Click(object sender, EventArgs e)


            foreach (ClassRepuestos datitos in Datos)
            {
                //aca va donde mostrarlo. En ltsDatitos y MARCO QUE DATOS QUIERO MOSTRAR    
                lstDatitos.Items.Add(datitos.nombre + " " + datitos.codigo + " " + datitos.precio + " " + datitos.marca + " " + datitos.origen);
            }

            private void btnSalir_Click(object sender, EventArgs e)
            {
                Close();
            }

            // este evento nos garantiza que txtPrecio contendrá siempre
            // un valor numérico de tipo decimal o estará vacío
            private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)

            {
                // aceptar solo expresiones numéricas con decimales
                if (!Char.IsNumber(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != (int)Keys.Back)
                {
                    e.Handled = true;
                }
                if (e.KeyChar == ',' && txtPrecio.Text.Contains(","))
                {
                    e.Handled = true;
                }

            }

        }
    }
}
