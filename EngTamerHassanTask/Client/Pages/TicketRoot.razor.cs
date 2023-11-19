namespace EngTamerHassanTask.Client;

public partial class TicketRoot
{
    List<Ticket> tickets = new();
    HubConnection? hubConnection;
    [Inject] public NavigationManager NavigationManager { get; set; }

    Ticket source = new();

    bool isLoading = true;
    bool showForm = false;
    bool showSaveButton = true;

    int page = 1;
    int size = 5;
    int count = 0;

    decimal pageCount = 0;

    SystemFeatureType systemFeatureType = SystemFeatureType.Add;

    protected override async Task OnInitializedAsync()
    {
        CalculatePageCount();

        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/TicketHub"))
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", async (user, message) =>
        {
            await GetTickets(page, size);

            await InvokeAsync(StateHasChanged);
        });
        await hubConnection.StartAsync();

        await base.OnInitializedAsync();
    }

    private void CalculatePageCount() => pageCount = Math.Ceiling((decimal)count / size);

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await GetTicketsCount();

            await GetTickets(page, size);
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task GetTicketsCount() => count = await _httpClient.GetFromJsonAsync<int>($"api/Tickets/GetTicketsCount");

    private async Task GetTickets(int page, int size)
    {
        isLoading = true;
        this.page = page;
        this.size = size;
        tickets = await _httpClient.GetFromJsonAsync<List<Ticket>>($"api/Tickets/{page}/{size}") ?? new();

        CalculatePageCount();
        isLoading = false;

        await InvokeAsync(StateHasChanged);
    }
    async Task ShowForm(SystemFeatureType systemFeatureType, Ticket ticket)
    {
        source = ticket;
        showForm = true;
        showSaveButton = true;
        this.systemFeatureType = systemFeatureType;

        await InvokeAsync(StateHasChanged);
    }

    async Task Handle(Ticket ticket)
    {
        ticket.IsHandled = true;
        await _httpClient.PutAsJsonAsync("api/Tickets", ticket);

        if (hubConnection is not null)
            await hubConnection.SendAsync("SendMessage", "refresh", "refresh");
    }
 
    async Task CloseForm()
    {
        page = 1;
        size = 5;
        source = new();
        showForm = false;

        if (hubConnection is not null)
            await hubConnection.SendAsync("SendMessage", "refresh", "refresh");

        await InvokeAsync(StateHasChanged);
    }

    static Func<Ticket, string> _cellStyleFunc = ticket => $"background-color:{(ticket.IsHandled ? "#55f21c" : "#f21c20")}";
}