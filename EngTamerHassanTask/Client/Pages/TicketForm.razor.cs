namespace EngTamerHassanTask.Client;

public partial class TicketForm
{
    [Parameter] public bool ShowForm { get; set; }
    [Parameter] public Ticket Source { get; set; }
    [Parameter] public bool ShowSaveButton { get; set; }
    [Parameter] public EventCallback CloseForm { get; set; }
    [Parameter] public EventCallback GetTicketsCount { get; set; }
    [Parameter] public SystemFeatureType FormSystemFeatureType { get; set; }

    readonly List<string> cities = new() { "", "Cairo", "Tanta", "Alex", "Luxor", "Matroh", "Red Sea", "Helwan" };
    readonly List<string> governorates = new() { "", "El Gharbia", "El Sharkia", "Alex", "Giza", "Asuit", "Luxor" };
    readonly List<string> districts = new() { "", "First district", "Second district", "Third district", "Forth district" };

    async Task HandleValidSubmit()
    {
        if (FormSystemFeatureType.Equals(SystemFeatureType.Add))
            await _httpClient.PostAsJsonAsync("api/Tickets", Source);
        if (FormSystemFeatureType.Equals(SystemFeatureType.Edit))
            await _httpClient.PutAsJsonAsync("api/Tickets", Source);

        await GetTicketsCount.InvokeAsync();

        await CloseForm.InvokeAsync();
    }

    public async Task Delete(Ticket ticket)
    {
        await _httpClient.DeleteAsync($"api/Tickets/{ticket.Id}");

        await GetTicketsCount.InvokeAsync();

        await CloseForm.InvokeAsync();
    }

    async Task Cancel() => await CloseForm.InvokeAsync();
}