using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterface;
using HttpClients.Implementation.CreateQuery;

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

    public async Task<ICollection<Post>> GetAsync(int? postId, string? owner, string? title, DateTime? created)
    {
        string query = ConstructQuery.ConstructQueryMethod(postId, owner, title, created);

        
        HttpResponseMessage response = await client.GetAsync("/posts"+query);
        
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

    public async Task<Post> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}