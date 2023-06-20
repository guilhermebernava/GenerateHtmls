
namespace GenarteHtmls.Services
{
    public class FileServices
    {
        public static async Task SaveFile(HttpContent content,string codBrand, string typeChecklist, string path)
        {
            try
            {
                var filePath = path + typeChecklist + "_" + codBrand + ".html";
                using (StreamWriter writer = File.CreateText(filePath))
                {
                     await FormatFileEntity(writer, content,filePath);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                throw;
            }
            
        }

        private static async Task  FormatFileEntity(StreamWriter writer, HttpContent content,string filePath)
        {
            
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html lang=\"en\">");
            writer.WriteLine("  <head>");
            writer.WriteLine("      <meta charset=\"UTF-8\">");
            writer.WriteLine("      <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            writer.WriteLine("      <title>Checklist</title>");
            writer.WriteLine("      <link\r\n            href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css\"\r\n            rel=\"stylesheet\"\r\n            integrity=\"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\"\r\n            crossorigin=\"anonymous\"\r\n        >");
            writer.WriteLine("   </head>");
            writer.WriteLine("     <body>");
            var body = await content.ReadAsStringAsync();
            writer.WriteLine(body);
            writer.WriteLine("     </body>");
            writer.WriteLine("      <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4\" crossorigin=\"anonymous\"></script>"); 
            writer.WriteLine("</html>");

        }
    }
}
