using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NOTES.Data.Domain;
using NOTES.Repositories.Abstract;
using NOTES.Repositories.Implementation;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<DatabaseContext>(options => options
    .UseNpgsql(builder.Configuration
        .GetConnectionString("conn")));

builder.Services.AddTransient<INotesCRUDService, NotesCRUDService>();
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<IDateService, DateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
