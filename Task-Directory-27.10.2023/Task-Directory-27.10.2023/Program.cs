using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Task_Directory_27._10._2023.Models;

namespace Task_Directory_27._10._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\II novbe\Desktop\Task\Task-Directory-27.10.2023\Task-Directory-27.10.2023\";

            Directory.CreateDirectory(path+@"\Models");
            Directory.CreateDirectory(path+@"\Data");

            if (!File.Exists(path + @"\Data\jsonDAta.json"))
            {
                File.Create(path + @"\Data\jsonDAta.json");
            }
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            List<CustomObject> customObjects = JsonConvert.DeserializeObject<List<CustomObject>>(result);
        }
    }
}