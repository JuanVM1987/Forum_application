using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
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

    public async Task<ICollection<Post>> GetAsync(int? postId, string? userName, string? title, DateTime? created)
    {
        
        HttpResponseMessage response = await client.GetAsync("/posts");
        string check = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(check);
        }
        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(check, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}