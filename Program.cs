using Microsoft.OpenApi.Models;
using Playlist;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
   });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
   });

string endpoint = "/playlist";

app.MapGet(endpoint, () => PlaylistDB.GetSongs());
app.MapGet(endpoint + "/{id}", (int id) => PlaylistDB.GetSong(id));
app.MapPost(endpoint, (Song song) => PlaylistDB.AddSong(song));
app.MapPut(endpoint + "/{id}", (int id, Song song) => PlaylistDB.UpdateSong(id, song));
app.MapDelete(endpoint + "/{id}", (int id) => PlaylistDB.DeleteSong(id));


app.Run();
