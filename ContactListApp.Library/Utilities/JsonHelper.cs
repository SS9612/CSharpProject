using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ContactListApp.Library.Utilities
{
    public static class JsonHelper
    {

        public static void SaveToJsonFile<T>(string filePath, List<T> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid sparande till JSON: {ex.Message}");
            }
        }

        public static List<T> LoadFromJsonFile<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid inläsning från JSON: {ex.Message}");
            }

            return new List<T>();
        }
    }
}
