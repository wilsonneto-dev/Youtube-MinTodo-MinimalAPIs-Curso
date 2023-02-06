using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// app.MapGet("/test/simple", (int id) => 
//     id > 10 ? 
//         Results.Ok(new Resp() { Message = "Ok", IsSuccess = true })
//         : Results.NotFound()
// )
//     .Produces<ProblemDetails>(StatusCodes.Status200OK)
//     .Produces(StatusCodes.Status404NotFound)
//     .WithOpenApi(operation => new(operation){
//         Summary = "Just a test Summary",
//         Description = "Just a test description"
//     });

app.MapGet("/api/msgs/{id:int}", (int id) => 
    TypedResults.Ok(new Msg(){ Id = id, Message = "Test" }))
    .WithName("GetMsgDetail");

app.MapPost("/api/msgs", (Msg msg) => 
    TypedResults.CreatedAtRoute(msg, "GetMsgDetail", new { Id = msg.Id }))
    .WithName("CreateMessage");

app.MapGet("/test", (LinkGenerator linkGen) => new {
    CreateMsgRoute = linkGen.GetPathByName("CreateMessage"),
    GetMsgDetail = linkGen.GetPathByName("GetMsgDetail", new{ Id = 10 })
});

app.Run();

class Msg {
    public int Id { get; set; }
    public required string Message { get; set; }
}
