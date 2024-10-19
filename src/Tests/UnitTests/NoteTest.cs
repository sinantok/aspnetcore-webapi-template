using System.Net;
using System.Net.Http.Json;
using Models.DbEntities;
using Models.ResponseModels;
using Newtonsoft.Json;
using UnitTests.core;
using UnitTests.core.Enums;

namespace UnitTests;

public class NoteTest
{
    private readonly HttpClient _httpClient;

    public NoteTest()
    {
        var api = new ApiFactory(TypeControllerTesting.Note);
        _httpClient = api.GetClientWithAuthenticated();
    }

    [Fact]
    public async void Should_return_200_ok_when_fetch_all_notes()
    {
        var response = await _httpClient.GetAsync("allnotes");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void Should_return_zero_notes_when_fetch_all_notes()
    {
        var response = await _httpClient.GetAsync("allnotes");
        var content = await response.Content.ReadAsStringAsync();
        var notes = JsonConvert.DeserializeObject<BaseResponse<IReadOnlyList<Note>>>(content);

        Assert.Empty(notes.Data);
    }

    [Fact]
    public async void Should_return_ok_when_add_new_note()
    {
        var response = await _httpClient.PostAsJsonAsync("addnote", new Note
        {
            Title = "Test Note",
            Description = "Test Note Content",
            Category = "Test Category"
        });

        var content = await response.Content.ReadAsStringAsync();
        
        Assert.Contains("Note added successfully", content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}