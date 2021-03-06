using Microsoft.Extensions.Options;
using ProductPackaging.Models;
using ProductPackaging.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.Configure<MProductPackagingDbSetting>(
    builder.Configuration.GetSection(nameof(MProductPackagingDbSetting))
);

builder.Services.AddSingleton<IProductPackagingDbSetting>(sp =>
    sp.GetRequiredService<IOptions<MProductPackagingDbSetting>>().Value
);

builder.Services.AddSingleton<ProductPackagingService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();