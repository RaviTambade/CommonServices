using ServicesLib;
using RepoLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAccountRepo, AccountRepo>();
builder.Services.AddTransient<IBankingService, BankingService>();
builder.Services.AddTransient<IOperationRepo, OperationRepo>();
builder.Services.AddTransient<IOperationsService, OperationsService>();
builder.Services.AddTransient<ILoanRepo, LoanRepo>();
builder.Services.AddTransient<ILoanService,LoanService>();
builder.Services.AddTransient<ILoanApplicationsRepo, LoanApplicationsRepo>();
builder.Services.AddTransient<ILoanApplicationsService,LoanApplicationsService>();
builder.Services.AddTransient<ILoanTypeRepo,LoanTypeRepo>();
builder.Services.AddTransient<ILoanTypeService,LoanTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:5002");
