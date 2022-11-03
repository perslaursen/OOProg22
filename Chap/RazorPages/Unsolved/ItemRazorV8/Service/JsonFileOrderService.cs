using ItemRazorV1.Models;
using System.Text.Json;

namespace ItemRazorV1.Service
{
    public class JsonFileOrderService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileOrderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Orders.json"); }
        }

        public void SaveJsonOrders(List<Order> orders)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize(jsonWriter, orders.ToArray());
            }
        }

        public IEnumerable<Order> GetJsonOrders()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Order[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
