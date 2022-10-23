using System.Text.Json;

/// <summary>
/// This class can write a given list of objects of type T into
/// a JSON text file.
/// </summary>
/// <typeparam name="T">Type of objects to write to file</typeparam>
public class JsonFileWriter<T>
{
    public static void WriteToJson(IEnumerable<T> elements, string jsonFileName, bool throwExceptionOnError = false)
    {
        try
        {
            using FileStream outputStream = File.Create(jsonFileName);
            var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
            {
                SkipValidation = false,
                Indented = true,
            });
            JsonSerializer.Serialize(writer, elements.ToArray());
        }
        catch (Exception ex)
        {
            if (throwExceptionOnError)
                throw new JsonException(ex.Message);
        }
    }

    public static void WriteToJson(Dictionary<int, T> elements, string jsonFileName, bool throwExceptionOnError = false)
    {
        WriteToJson(elements.Values, jsonFileName, throwExceptionOnError);
    }
}
