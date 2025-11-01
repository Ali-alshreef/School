using SchoolCore.Models;
using SchoolData.DataDB;

namespace WinFormsAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SchoolDB db = new SchoolDB();

            City city = new City();
            city.Name = "Zliten From Winforms";
            city.Name2 = "Zliten";
            db.Cities.Add(city);
            db.SaveChanges();

        }
    }
}
