
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
            writer.WriteLine("      <script src=\"answer.js\"></script>");
            writer.WriteLine("      <script src=\"https://code.jquery.com/jquery-3.6.1.min.js\" integrity=\"sha256-o88AwQnZB+VDvE9tvIXrMQaPlFFSUTR+nldQm1LuPXQ=\" crossorigin=\"anonymous\"></script>");
            writer.WriteLine("      <link\r\n            href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css\"\r\n            rel=\"stylesheet\"\r\n            integrity=\"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\"\r\n            crossorigin=\"anonymous\"\r\n        >");
            writer.WriteLine("   </head>");
            writer.WriteLine("     <body>");
            writer.WriteLine("     <div id=\"result-header\">\r\n            <br>\r\n            <div align=\"center\">\r\n              <h3 class=\"fw-bold text-success\">Dados do Checklist</h3>\r\n            </div>\r\n        </div>\r\n     <form id=\"result\"  class=\"border border-success border-2 p-4 m-4\">\r\n\r\n    <div align=\"center\">\r\n      <div class=\"mb-3\">\r\n        <h4><span id=\"lbBrand_Type\"></span></h4>\r\n      </div>\r\n      <div class=\"mb-3\">\r\n          <span id=\"lbNickname\"></span>\r\n          <span id=\"lbBrand\"></span>\r\n          <span id=\"lbBrandModel\"></span>\r\n          <span id=\"lbBrandVersion\"></span>\r\n      </div>\r\n      <div class=\"mb-3\">\r\n          <div class=\"btn btn-warning text-white fw-bold\">\r\n            <h2>Nota do Seu Equipamento</h2>\r\n            <span id=\"equipament_score_checklist\"></span>\r\n          </div>\r\n      </div>\r\n      <div class=\"mb-12\">\r\n         <button style=\"width: 90%\" class=\"btn border border-success\" onclick=\"return VoltarPasso2();\">Editar Dados</button>\r\n      <div class=\"mb-12\"> \r\n         <button style=\"width: 90%\" class=\"btn border border-success\"onclick=\"return save_checklist();\" >Salvar</button>\r\n      </div>\r\n    </div>\r\n    </div>\r\n  </form>");
            var body = await content.ReadAsStringAsync();
            writer.WriteLine(body);
            writer.WriteLine("     </body>");
            writer.WriteLine("      <script>change_result_visibility(false)</script>");
            writer.WriteLine("      <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4\" crossorigin=\"anonymous\"></script>"); 
            writer.WriteLine("</html>");

        }
    }
}
