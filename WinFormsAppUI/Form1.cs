using SchoolCore.Models;
using SchoolData.DataDB;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

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
            db.Cities.Add(city);
            db.SaveChanges();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7088/api/City/GetCities").Result;
            if (response.IsSuccessStatusCode)
            {
                var cities = response.Content.ReadFromJsonAsync<List<MyCity>>().Result;
                dataGridView1.DataSource = cities;
            }
            else
            {
                MessageBox.Show("Œÿ« ›Ì «·»Ì«‰«  „‰ «·ˆAPI");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // 1. ≈‰‘«¡ ﬂ«∆‰ «·„œÌ‰… „‰ ≈œŒ«· «·„” Œœ„
            City newCity = new City
            {
                Name =textBox1.Text,
            };

            // 2.  ÕÊÌ· «·ﬂ«∆‰ ≈·Ï JSON
            string json = JsonSerializer.Serialize(newCity);

            // 3. ≈⁄œ«œ «·„Õ ÊÏ ·≈—”«·Â
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // 4. ≈—”«· «·ÿ·»
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 5. ≈—”«· ÿ·» POST
                    var response = await client.PostAsync(
                        "https://localhost:7088/api/City/Create",content);

                    // 6. «· Õﬁﬁ „‰ «·‰ ÌÃ…
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(" „ ≈÷«›… «·„œÌ‰… »‰Ã«Õ!");

                        // 7. ﬁ—«¡… «·„œÌ‰… «·„÷«›…
                        var result = await response.Content.ReadFromJsonAsync<City>();
                        MessageBox.Show(" „ «·«÷«›… »‰Ã«Õ " + result.Name);
                    }
                    else
                    {
                        // 8. ﬁ—«¡… —”«·… «·Œÿ√
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Œÿ√: {error}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ÕœÀ Œÿ√: {ex.Message}");
                }
            }
        }
    }

    public class MyCity
    {
        [JsonPropertyName("id")]
        public int CityId { get; set; }

        [JsonPropertyName("name")]
        public string CityName { get; set; }
    }
}
