using System.Net.Http.Json;
using Domain.DTOs;
using HttpClients.ClientInterface;

namespace HttpClients.Implementation;

public class PostHttpClient:IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/posts", dto);
        string check = await responseMessage.Content.ReadAsStringAsync();
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(check);
        }

    }
}