using Microsoft.Extensions.FileProviders;
using RazorPagesCase.Models;
using RazorPagesCase.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
RegisterServices(builder.Services);

var app = builder.Build();

ConfigureApp(app);

void ConfigureApp(WebApplication app)
{
    var ctx=app.Services.CreateScope().ServiceProvider.GetService<AppDbContext>();
    ctx.Database.EnsureCreated();

// Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        //app.UseSwagger();
        //app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    app.MapControllers();

    app.UseCors(builder => builder.AllowAnyOrigin());
}

void RegisterServices(IServiceCollection services)
{
    // Add services to the container.
    services.AddDbContext<AppDbContext>();

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Cases API",
            Description = "SR administration",
            Version = "v1"
        });
    });
}

/*app.MapGet("/v1/SRs", (AppDbContext context) =>
{
    var SRs = context.SRs;

    if (!SRs.Any())
        return Results.NotFound();

    var SRsDto = SRs.Select(b => new SRDto(b.number, b.Issue, b.IsFQRdone, b.POD, b.IsSMEReviewed, b.Age)).ToList();

    return Results.Ok(SRsDto);

}).Produces<SRDto>();

app.MapPost("/v1/SRs", (SRDto createSR, AppDbContext context) =>
{
    try
    {
        var post = new SR()
        {
            Id = createSR.Id(),
            number = createSR.number(),
            Issue = createSR.Issue,
            IsFQRdone = createSR.IsFQRdone,
            POD = createSR.POD,
            IsSMEReviewed = createSR.IsSMEReviewed,
            Age = createSR.Age
        };

        context.Add(post);
        context.SaveChanges();

        return Results.Created($"v1/SRs/{createSR.number}", createSR);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
}).Produces<SRDto>();

app.MapPut("/v1/SRs", (Guid number, SR updatesr, AppDbContext context) =>
{
    try
    {
        var sr = context.SRs.Find(number);

        if (sr is null)
            return Results.NotFound();

        context.Entry(sr).CurrentValues.SetValues(updatesr);
        context.SaveChanges();

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error ocurred while puting to Case: {ex.Message}");
    }
});

app.MapDelete("/v1/SRs", (int number, AppDbContext context) =>
{
    try
    {
        var post = context.SRs.Where(p => p.number == number).FirstOrDefault();

        if (post is null)
            return Results.BadRequest($"Case not found to Id = {number}");

        context.Remove(post);
        context.SaveChanges();

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
});*/
app.Run();
