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
        public frmAutocor()
        {
            InitializeComponent();
        }

        //esto es para que me enliste los datos que voy a grabar en la clase repuestos 
        List<ClassRepuestos> Datos = new List<ClassRepuestos>();
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ClassRepuestos objRepuesto = new ClassRepuestos();

            objRepuesto.nombre = txtNombre.Text;
            objRepuesto.codigo = int.Parse(txtCodigo.Text);
            objRepuesto.precio = int.Parse(txtPrecio.Text);
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

            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            foreach (ClassRepuestos datitos in Datos)
            {
                //aca va donde mostrarlo. En ltsDatitos y MARCO QUE DATOS QUIERO MOSTRAR    
                lstDatitos.Items.Add( datitos.nombre + " " + datitos.codigo +  " " + datitos.precio + " " + datitos.marca + " " + datitos.origen);
            }


        }
    }
}
