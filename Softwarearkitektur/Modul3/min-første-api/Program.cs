using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> frugter = new List<string>
{
    "æble", "banan", "pære", "ananas"
};

app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!" });
app.MapGet("/api/hello/{name}/{age:int}", (string name, int age) => new { Message = $"Hello {name}! You are {age} years old!" });

app.MapGet("/api/fruit", () => frugter);
app.MapGet("/api/fruit/{index:int}", (int index) => frugter[index]);
app.MapGet("/api/fruit/random", () => new { Fruit = frugter[new Random().Next(frugter.Count)] });

app.MapPost("/api/fruit", (Fruit fruit) =>
{
    if (string.IsNullOrWhiteSpace(fruit.name))
    {
        return Results.BadRequest("Name must not be empty"); // Returner 400 Bad Request med en fejlbesked
    }

    frugter.Add(fruit.name);

    Console.WriteLine($"Tilføjet frugt: {fruit.name}");

    return Results.Ok(frugter); // Returner 200 OK med listen af frugter
});

app.Run();

record Fruit(string name);
