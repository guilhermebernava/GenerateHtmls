
namespace GenarteHtmls.Services
{
    public class FileServices
    {
        public static async Task SaveFile(HttpContent content,string codBrand, string typeChecklist, string path)
        {
            try
            {
                using (var fileStream = new FileStream(path + typeChecklist + "_" + codBrand + ".html", FileMode.Create))
                {
                    await content.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        

    }
}
