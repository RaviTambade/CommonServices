using Microsoft.EntityFrameworkCore;
using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Repositories.Connected;

//using Transflower.MembershipRolesMgmt.Repositories.Disconnected;
using Transflower.MembershipRolesMgmt.Repositories;
using Transflower.MembershipRolesMgmt.Repositories.Contexts;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

// Add servic'es to the container.
builder.Services.AddDbContext<RoleContext>(
    options =>
        options
            .UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 28))
            )
            .LogTo(Console.WriteLine, LogLevel.Information)
);
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IAddressService,AddressService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IAddressRepository,AddressRepository>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions<JwtSettings>().BindConfiguration("JWT").ValidateDataAnnotations().ValidateOnStart();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseStaticFiles();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.Run();
