﻿namespace GenarteHtmls.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Response
    {
        public int codBrand { get; set; }
        public char typeChecklist { get; set; }
    }

    public class Jsons
    {
        public List<Response> responses { get; set; }
    }

}
