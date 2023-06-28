using GenarteHtmls.Entities;
using System.Text.Json;

namespace GenarteHtmls.Services
{
    public class JsonServices
    {

        public static Jsons ConvertJsonToFileEntity(string json)
        {
            try
            {
                var fileEntity = JsonSerializer.Deserialize<Jsons>(json);

                if (fileEntity == null)
                {
                    throw new Exception($"ERROR IN DESERIALIZE THIS JSON \n {json}");
                }

                return fileEntity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                throw;
            }

        }
    }
}
