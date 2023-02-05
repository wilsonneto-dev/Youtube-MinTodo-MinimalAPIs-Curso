var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GreetingService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/test", ([AsParameters] PaginationDto dto) => dto);

app.Run();

class GreetingService {
    public string Greet(string name) => $"Hello, {name}!";
}

record PaginationDto(int CurrentPage, int PerPage);

record Todo(int Id, string Title)
{
    // public static bool TryParse(string todoEncoded, out Todo? todo) 
    // {
    //     try{
    //         var parts = todoEncoded.Split(",");
    //         todo = new Todo(int.Parse(parts[0]), parts[1]);
    //         return true;
    //     } catch(Exception _)
    //     {
    //         todo = null;
    //         return false;
    //     }
    // }

    // public static async ValueTask<Todo?> BindAsync(
    //     HttpContext context,
    //     ParameterInfo parameterInfo
    // ){
    //     try{
    //         var content = await new StreamReader(context.Request.Body).ReadToEndAsync();
    //         var parts = content.Split(",");
    //         return new Todo(int.Parse(parts[0]), parts[1]);
    //     } catch(Exception _)
    //     {
    //         return null;
    //     }
    // }
}
