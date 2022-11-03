using ItemRazorV1.Models;
using System.Text.Json;

namespace ItemRazorV1.Service
{
    public class JsonFileCustomerService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileCustomerService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Customers.json"); }
        }

        public void SaveJsonCustomers(List<Customer> customers)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Customer[]>(jsonWriter, customers.ToArray());
            }
        }

        public IEnumerable<Customer> GetJsonCustomers()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Customer[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
