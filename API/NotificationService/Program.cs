using Transflower.NotifiactionService.Helpers;
using Transflower.NotifiactionService.Services;
using Transflower.NotifiactionService.Services.Interfaces;
using Twilio.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<EmailConfiguration>(
    builder.Configuration.GetSection("EmailConfiguration")
);
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.Configure<TwilioConfiguration>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddHttpClient<ITwilioRestClient, TwilioClient>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
