// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
HttpClient client = new HttpClient();

async Task Main()
{
    // Call asynchronous network methods in a try/catch block to handle exceptions.
    try
    {
        using HttpResponseMessage response = await client.GetAsync("http://192.168.15.102:8080/video?1280x720.mjpg");
        
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);

        Console.WriteLine(responseBody);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
    }
}

Main().Wait();