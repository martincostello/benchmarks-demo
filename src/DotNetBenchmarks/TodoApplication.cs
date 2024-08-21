// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBenchmarks;

internal static partial class TodoApplication
{
    public static WebApplicationBuilder AddTodoApi(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions((options) =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        return builder;
    }

    public static WebApplication UseTodoApi(this WebApplication app)
    {
        Todo[] samples =
        [
            new(1, "Walk the dog"),
            new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.UtcNow)),
            new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1))),
            new(4, "Clean the bathroom"),
            new(5, "Clean the car", DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2))),
        ];

        var group = app.MapGroup("/todos");

        group.MapGet("/", () => samples);
        group.MapGet("/{id}", (int id) =>
            samples.FirstOrDefault(a => a.Id == id) is { } todo
                ? Results.Ok(todo)
                : Results.NotFound());

        return app;
    }

    public sealed record Todo(int Id, string Title, DateOnly? DueBy = null, bool IsComplete = false);

    [JsonSerializable(typeof(Todo[]))]
    internal sealed partial class AppJsonSerializerContext : JsonSerializerContext;
}
