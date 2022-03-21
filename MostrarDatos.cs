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
    public partial class MostrarDatos : Form
    {
        List<Estudiar> estudiars = new List<Estudiar>();
        List<Estudiantee> estudiantees = new List<Estudiantee>();
        public MostrarDatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatosEstudiantes();
            cargarDatosDeGrados();
            grid();
            grid();
            
        }
        private void cargarDatosEstudiantes()
        {
            FileStream stream = new FileStream("Estudiantes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Estudiantee estudiantee = new Estudiantee();
                estudiantee.nombre = reader.ReadLine();
                estudiantee.carnet = reader.ReadLine(); 
                estudiantees.Add(estudiantee);
            }
        }

        private void grid()
        {
            dataGridView1.DataSource = estudiantees;
            dataGridView1.Refresh();
            dataGridView2.DataSource = estudiars;
            dataGridView2.Refresh();
        }
        private void cargarDatosDeGrados()
        {
            FileStream stream = new FileStream("Grado.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Estudiar estudiar = new Estudiar();
                estudiar.carnet = reader.ReadLine();
                estudiar.gradoinicial = reader.ReadLine();
                estudiar.gradofinal = reader.ReadLine();
                estudiar.fechadeinscripcion = reader.ReadLine();
                estudiars.Add(estudiar);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
