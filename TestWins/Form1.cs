using System.Drawing.Text;
using TestWins.Controller;

namespace TestWins;

public partial class Form1 : Form
{
    //business
    private readonly StudentController controller = new StudentController();
    public Form1()
    {
        InitializeComponent();
        loadData();
    }

    private void loadData()
    {
        dataGridView1.DataSource = controller.getAll();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var student = new TestWins.Model.Student
        {
            studentId = txtStudentId.Text,
            Name = txtName.Text,
            age = int.Parse(txtAge.Text),
            course = txtCourse.Text
        };
        controller.createStudent(student);
        loadData();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        var student = new TestWins.Model.Student
        {
            studentId = txtStudentId.Text,
            Name = txtName.Text,
            age = int.Parse(txtAge.Text),
            course = txtCourse.Text
        };
        controller.update(student);
        loadData();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        controller.delete(txtStudentId.Text);
        loadData();
    }

    private void dataGridView1_CellClick(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow != null)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txtStudentId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtAge.Text = row.Cells[2].Value.ToString();
            txtCourse.Text = row.Cells[3].Value.ToString();
        }
    }
}