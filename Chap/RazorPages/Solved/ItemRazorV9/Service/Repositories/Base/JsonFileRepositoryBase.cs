using ItemRazorV1.Service.Repositories.Interfaces;
using System.Text.Json;

namespace ItemRazorV1.Service.Repositories.Base
{
    public class JsonFileRepositoryBase<T> : IJsonFileRepository<T> where T : class
    {
        public string JsonFileRelative { get; set; }
        public string DataRoot { get; set; } = "Data";
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileRepositoryBase(IWebHostEnvironment webHostEnvironment, string jsonFileRelative)
        {
            WebHostEnvironment = webHostEnvironment;
            JsonFileRelative = jsonFileRelative;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, DataRoot, JsonFileRelative); }
        }

        public void SaveToJsonFile(IEnumerable<T> list)
        {
            using FileStream jsonFileWriter = File.Create(JsonFileName);
            Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
            {
                SkipValidation = false,
                Indented = true
            });
            JsonSerializer.Serialize(jsonWriter, list.ToArray());
        }

        public IEnumerable<T> GetFromJsonFile()
        {
            using StreamReader jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd()) ?? new T[0];
        }
    }
}
