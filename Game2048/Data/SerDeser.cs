using System.IO;
using System.Windows;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace Game2048.Data
{
    class SerDeser
    {
        public static void WriteToJsonFile<T>(string filePath, ObservableCollection<T> players)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(players, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static ObservableCollection<T> ReadListFromJsonFile<T>(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (File.Exists(filePath))
            {
                return JsonDeserialize<T>(filePath, options);
            }
            else
            {
                File.Create(filePath).Close();
                return new ObservableCollection<T> { };
            }
        }

        private static ObservableCollection<T> JsonDeserialize<T>(string filePath, JsonSerializerOptions options)
        {
            string jsonString = File.ReadAllText(filePath);
            try
            {
                return JsonSerializer.Deserialize<ObservableCollection<T>>(jsonString, options);
            }
            catch (JsonException)
            {
                if (jsonString != "")
                {
                    ShowReadErorMessage();
                    File.WriteAllText(filePath, "");
                }
                return new ObservableCollection<T> { };
            }
        }

        private static void ShowReadErorMessage()
        {
            MessageBox.Show("Error reading statistics from file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}