using AddressBook.Models.AddressBook;
using System.Text.Json;

namespace AddressBook.Utils
{
    public static class JsonFileWriter
    {
        public static void Write<T>(T generic, string filePath)
        {
            string parsedJson = JsonSerializer.Serialize<T>(generic);
            File.WriteAllText(filePath, parsedJson);
        }
    }
}
