using ItemRazorV1.Models;
using System.Text.Json;

namespace ItemRazorV1.Service
{
    public class JsonFileItemService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileItemService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Items.json"); }
        }

        public void SaveJsonItems(List<Item> items)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Item[]>(jsonWriter, items.ToArray());
            }
        }

        public IEnumerable<Item> GetJsonItems()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Item[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
