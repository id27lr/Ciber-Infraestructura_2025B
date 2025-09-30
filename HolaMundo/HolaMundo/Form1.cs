using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolaMundo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Se obtienen las contraseñas de los campos de texto
            string contrasena = txtContrasena1.Text;
            string contrasena2 = txtContrasena2.Text;

            // (?=.*[A-Z])      -> al menos una mayúscula
            // (?=.*[a-z])      -> al menos una minúscula
            // (?=.*\d)         -> al menos un número
            // (?=.*[!@#$%^&*]) -> al menos un símbolo de la lista 
            // .{4,}            -> mínimo 4 caracteres

            string patron = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*]).{4,}$";

            bool esValido = Regex.IsMatch(contrasena, patron); // Verifica si la contraseña cumple con el patrón de la expresión regular

            // Mensajes de validación
            if (!esValido)
            {
                MessageBox.Show("La contraseña no cumple con los requisitos.");
                return;
            }
            if(!contrasena.Equals(contrasena2))
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            MessageBox.Show("Contraseña válida.");

        }
    }
}
