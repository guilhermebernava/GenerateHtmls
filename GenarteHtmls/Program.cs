using GenarteHtmls.Services;

var runProgram = true;
try
{
    while (runProgram)
    {
        Console.WriteLine("Insira o caminho do JSON: ");
        var path = Console.ReadLine();

        if (path == null)
        {
            Console.WriteLine("o caminho do JSON esta nulo");
            continue;
        }

        Console.WriteLine("Insira o caminho onde ira salvar os ARQUIVOS/HTMLs: ");
        var savePath = Console.ReadLine();

        if (savePath == null)
        {
            Console.WriteLine("o caminho do JSON esta nulo");
            continue;
        }


        string json = File.ReadAllText(path);
        var jsons = JsonServices.ConvertJsonToFileEntity(json);




        if (jsons == null)
        {
            throw new Exception("Invalid json");
        }

        foreach (var item in jsons.responses)
        {
            var body = await DownloadServices.GetHtml(item.codBrand.ToString(), item.typeChecklist.ToString());

            if (body == null)
            {
                Console.WriteLine("Conteudo da API esta vazio");
                continue;
            }

            await FileServices.SaveFile(body, item.codBrand.ToString(), item.typeChecklist.ToString(), savePath);
            Console.WriteLine("Salvo com sucesso!");
            Console.WriteLine();
        }

        Console.WriteLine($"Todos os arquivos foram salvos na pasta \n {savePath}");
        Console.ReadKey();
        runProgram = false;
    }
}catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
    throw;
}



