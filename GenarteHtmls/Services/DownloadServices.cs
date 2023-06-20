namespace GenarteHtmls.Services
{
    public class DownloadServices
    {
        private static readonly string URL = "https://apitratorweb.hugtak.com/checklist/checklist_modules_html.php?";
        public static async Task<HttpContent> GetHtml(string codBrand, string type_checklist)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(URL +"code=" +codBrand + "&" +"code2=" +type_checklist );
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Error in consuming API");
                    }
                    return  response.Content;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
