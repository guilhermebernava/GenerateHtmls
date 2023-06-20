using GenarteHtmls.Services;

Console.WriteLine("Insira o caminho do JSON: ");
var path = Console.ReadLine();

if (path == null)
{
    throw new Exception("o caminho do JSON esta nulo");
}

Console.WriteLine("Insira o caminho onde ira salvar os ARQUIVOS/HTMLs: ");
var savePath = Console.ReadLine();

if (savePath == null)
{
    throw new Exception("o caminho do JSON esta nulo");
}


string json = File.ReadAllText(path);
var jsons = JsonServices.ConvertJsonToFileEntity(json);

if (jsons == null)
{
    throw new Exception("Invalid json");
}

foreach(var item in jsons.responses)
{
    var body = await DownloadServices.GetHtml(item.codBrand.ToString(), item.typeChecklist.ToString());

    if (body == null)
    {
        throw new Exception("Conteudo da API esta vazio");
    }

    await FileServices.SaveFile(body, item.codBrand.ToString(), item.typeChecklist.ToString(), savePath);
    Console.WriteLine("Salvo com sucesso!");
    Console.WriteLine();
}

Console.WriteLine($"Todos os arquivos foram salvos na pasta \n {savePath}");
  

