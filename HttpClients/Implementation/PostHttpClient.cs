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

    public async Task CreateAsync(PostBasicDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/posts", dto);
        string check = await responseMessage.Content.ReadAsStringAsync();
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(check);
        }

    }

    public async Task<ICollection<PostReturnDto>> GetAsync(int? postId, string? owner, string? title, DateTime? created)
    {
        string query = ConstructQuery.ConstructQueryMethod(postId, owner, title, created);

        
        HttpResponseMessage response = await client.GetAsync("/posts"+query);
        
        string check = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(check);
        }
        ICollection<PostReturnDto> posts = JsonSerializer.Deserialize<ICollection<PostReturnDto>>(check, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<PostReturnDto> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        PostReturnDto post = JsonSerializer.Deserialize<PostReturnDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}