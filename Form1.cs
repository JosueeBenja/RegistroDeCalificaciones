namespace RegistroDeCalificaciones
{
    public partial class Form1 : Form
    {
        private List<Calificacion> calificaciones = new List<Calificacion>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AgregarCalificacion_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = (Estudiante)comboEstudiantes.SelectedItem;
            Curso curso = (Curso)comboCursos.SelectedItem;

            if (estudiante != null && curso != null)
            {
                if (double.TryParse(txtCalificacion.Text, out double calificacion))
                {
                    Calificacion nuevaCalificacion = new Calificacion(estudiante, curso, calificacion);
                    calificaciones.Add(nuevaCalificacion);

                    txtCalificacion.Clear();
                    comboEstudiantes.SelectedIndex = -1;
                    comboCursos.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("La calificación debe ser un número válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un estudiante y un curso.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Inicio = new Form1();
            Inicio.Show();
        }

        private void GenerarReporte_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = (Estudiante)comboEstudiantes.SelectedItem;
            Curso curso = (Curso)comboCursos.SelectedItem;

            if (estudiante != null && curso != null)
            {
                List<Calificacion> calificacionesEstudianteCurso = calificaciones.FindAll(c => c.Estudiante == estudiante && c.Curso == curso);

                if (calificacionesEstudianteCurso.Count > 0)
                {
                    double promedio = 0;

                    foreach (Calificacion calificacion in calificacionesEstudianteCurso)
                    {
                        promedio += calificacion.Valor;
                    }

                    promedio /= calificacionesEstudianteCurso.Count;

                    listBoxCalificaciones.Items.Clear();
                    listBoxCalificaciones.Items.Add($"Estudiante: {estudiante.Nombre}");
                    listBoxCalificaciones.Items.Add($"Curso: {curso.Nombre}");
                    listBoxCalificaciones.Items.Add($"Promedio: {promedio}");
                }
                else
                {
                    MessageBox.Show("No se encontraron calificaciones para este estudiante y curso.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un estudiante y un curso.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}