// See https://aka.ms/new-console-template for more information
using Dummy_NewtonJson;
using Newtonsoft.Json;

/*
 SEQUENCING:
1. Load json into variables i.e., Dictionary<string,string>
2. Carregas variaveis default da base de dados, caso nao tiver salva as do oldDefaultVariables
3. Atualizar os dados da DB com a variavel newDefaultVariables, só se atualizam as variaves em comum o que for novo se descarta.
 */
Dictionary<string, string> oldDefaultVariables;
Dictionary<string, string> newDefaultVariables;

using (StreamReader file = File.OpenText(Path.Combine("dummyJson.json")))
{
    oldDefaultVariables = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
}

using (StreamReader file = File.OpenText(Path.Combine("newDummyJson.json")))
{
    newDefaultVariables = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd());
}

Lite.Set(oldDefaultVariables);
Lite.Set(newDefaultVariables);

Console.WriteLine("Hello, World!");
Console.ReadKey();
