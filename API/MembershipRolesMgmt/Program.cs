using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Repositories;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services;
using Transflower.MembershipRolesMgmt.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IAddressService,AddressService>();
builder.Services.AddScoped<ICredentialService,CredentialService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IAddressRepository,AddressRepository>();
builder.Services.AddScoped<ICredentialRepository,CredentialRepository>();
builder.Services.AddOptions<AppSettings>().BindConfiguration("JWT").ValidateDataAnnotations().ValidateOnStart();
// builder.Services.AddScoped<IRoleService,RoleService>();
// builder.Services.AddScoped<IRoleRepository,RoleRepository>();
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

app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
