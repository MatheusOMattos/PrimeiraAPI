using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrimeiraApi.Services
{
    public class JsonFileService
    {
        private readonly string _filePath;

        public JsonFileService()
        {
            // Define o caminho para o arquivo JSON na pasta Downloads do usuário
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "data.json");
        }

        // Método genérico que lê o arquivo JSON e o converte em um objeto do tipo T
        public async Task<T?> ReadJsonFileAsync<T>()
        {
            if (!File.Exists(_filePath))
            {
                return default;
            }

            using var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
