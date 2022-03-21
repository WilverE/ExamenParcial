using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenParcial
{
    public partial class Form1 : Form
    {
        List<Estudiar> estudiars = new List<Estudiar>();
        List<Estudiantee> estudiantees = new List<Estudiantee>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0; 
            Estudiantee estudiantee = new Estudiantee();
            Estudiar estudiar = new Estudiar();
            estudiantee.nombre = nombre.Text;
            estudiantee.carnet = carne.Text;
            estudiar.carnet = carne.Text;
            estudiar.gradoinicial = gradoinicial.Text;
            estudiar.gradofinal = gradofinal.Text;
            DateTime hoy = DateTime.Now;
            estudiar.fechadeinscripcion = hoy.ToString();

            int posicion = estudiantees.FindIndex(x => x.nombre == nombre.Text);
            if (posicion == -1)
            {
                estudiantees.Add(estudiantee);
                guardar();
                estudiantee.numerodealumnos++; 
            }
            else
            {
                MessageBox.Show("El Aulumno Ya Fue Inscrito Anteriormente");
            }
            estudiantees.Add(estudiantee);

            int posicions = estudiars.FindIndex(x => x.carnet == carne.Text);
            if (posicion == -1)
            {
                estudiars.Add(estudiar);
                guardargrado();
            }
            else
            {
                MessageBox.Show("Ya Fue Inscrito");
            }
            estudiars.Add(estudiar);

            MostrarDatos frm1 = new MostrarDatos();
            frm1.Show();

            nombre.Text = "";
            carne.Text = "";
            gradofinal.Text = "";
            gradoinicial.Text = "";

        }
        private void guardar()
        {
            FileStream stream = new FileStream("Estudiantes.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var estudiante in estudiantees)
            {
                writer.WriteLine(estudiante.nombre);
                writer.WriteLine(estudiante.carnet);
            }
            writer.Close();
        }
        private void guardargrado()
        {
            FileStream stream = new FileStream("Grado.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var estudiar in estudiars)
            {
                writer.WriteLine(estudiar.carnet);
                writer.WriteLine(estudiar.gradoinicial);
                writer.WriteLine(estudiar.gradofinal);
                writer.WriteLine(estudiar.fechadeinscripcion);
            }
            writer.Close();
        }
    }
}
