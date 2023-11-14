using MVVM_API_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MVVM_API_SampleProject.Services;

public class PostService
{
    private  HttpClient client;
    private  JsonSerializerOptions _serializerOptions;
    private const string baseUrl = "https://jsonplaceholder.typicode.com";

    public PostService()
    {
        client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ObservableCollection<Post>> GetPostsAsync()
    {
        var url = $"{baseUrl}/posts";
        try
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ObservableCollection<Post>>(content, _serializerOptions);
            }
            return null;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return null;
        }
    }
}
