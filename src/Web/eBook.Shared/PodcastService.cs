using System.Net.Http.Json;

namespace eBook.Shared;

public class PodcastService
{
    private readonly HttpClient _httpClient;

    public PodcastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Category[]?> GetCategories() =>
        _httpClient.GetFromJsonAsync<Category[]>("api/category");

    public Task<Show[]?> GetShows(int limit, string? term = null) =>
        _httpClient.GetFromJsonAsync<Show[]>($"api/show?limit={limit}&term={term}");

    public Task<Show[]?> GetShows(int limit, string? term = null, Guid? categoryId = null) =>
        _httpClient.GetFromJsonAsync<Show[]>($"api/show?limit={limit}&term={term}&categoryId={categoryId}");

    public Task<Show?> GetShow(Guid id) =>
        _httpClient.GetFromJsonAsync<Show>($"api/show/{id}");
}
