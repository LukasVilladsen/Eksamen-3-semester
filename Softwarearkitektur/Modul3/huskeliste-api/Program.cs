
// Opretter en webapplikation
var builder = WebApplication.CreateBuilder(args);
var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

// Oprettelse af et dictionary til at gemme TodoTasks med et unikt id
var tasks = new Dictionary<int, TodoTask>();

// Definering af forskellige endpoints

// GET endpoint for roden af API'en
app.MapGet("/", () => "Todo Task API");

// GET endpoint for at hente alle TodoTasks
app.MapGet("/api/tasks", () => tasks.Values);

// GET endpoint for at hente en specifik TodoTask baseret på id
app.MapGet("/api/tasks/{id:int}", (int id) =>
{
    if (tasks.TryGetValue(id, out var task))
    {
        // Hvis opgaven findes, returner opgaven, ellers returner NotFound
        return task != null ? Results.Ok(task) : Results.NotFound();
    }

    // Returner NotFound, hvis opgaven ikke findes
    return Results.NotFound();
});

// POST endpoint for at tilføje en ny TodoTask
app.MapPost("/api/tasks", (TodoTask task) =>
{
    // Brug antallet af eksisterende opgaver som id
    int id = tasks.Count + 1;

    // Tilføj den nye opgave til dictionary
    tasks.Add(id, task);

    // Returner Created sammen med URL'en til den nye opgave og opgaven selv
    return Results.Created($"/api/tasks/{id}", task);
});

// PUT endpoint for at opdatere en eksisterende TodoTask
app.MapPut("/api/tasks/{id:int}", (int id, TodoTask updatedTask) =>
{
    if (tasks.ContainsKey(id))
    {
        // Opdater den eksisterende opgave med den opdaterede opgave
        tasks[id] = updatedTask;

        // Returner NoContent for at indikere en succesfuld opdatering
        return Results.NoContent();
    }

    // Returner NotFound, hvis opgaven ikke findes
    return Results.NotFound("Task not found");
});

// DELETE endpoint for at slette en eksisterende TodoTask baseret på id
app.MapDelete("/api/tasks/{id:int}", (int id) =>
{
    if (tasks.ContainsKey(id))
    {
        // Fjern opgaven fra dictionary
        tasks.Remove(id);

        // Returner NoContent for at indikere en succesfuld sletning
        return Results.NoContent();
    }

    // Returner NotFound, hvis opgaven ikke findes
    return Results.NotFound("Task not found");
});

// Start applikationen
app.Run();

// En record-type, der repræsenterer en TodoTask med en tekst og en boolean, der indikerer, om opgaven er færdig
record TodoTask(string Text, bool Done);

