using Bunnisses.Security.Interfaces;
using Bunnisses.Security.Implements;
using Data.Implementations; 
using Data.Interfaces;
using Entity.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using Data.Operational.Interfaces;
using Data.Operational.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContexts>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBDefaultConnection")));


// Registra IPersonaData y su implementación
builder.Services.AddScoped<IPersonaData, PersonaData>();
builder.Services.AddScoped<IPersonasBusiness, PersonasBusiness>();

builder.Services.AddScoped<IRolData, RolData>();
builder.Services.AddScoped<IRolesBusiness, RolBusiness>();

builder.Services.AddScoped< IModuloData, ModuloData>();
builder.Services.AddScoped<IModulosBusiness, ModulosBusiness>();

builder.Services.AddScoped<IUsuarioRolData, UsuarioRolData>();
builder.Services.AddScoped<IUsuariosRolesBusiness, UsuariosRolesBusiness>();

builder.Services.AddScoped<IUsuarioData, UsuarioData>();
builder.Services.AddScoped<IUsuariosBusiness, UsuariosBusiness>();

builder.Services.AddScoped<IVistaData, VistaData>();
builder.Services.AddScoped<IVistasBusiness, VistasBusiness>();

builder.Services.AddScoped<IRolVistaData, RolVistaData>();
builder.Services.AddScoped<IRolesVistasBusiness, RolesVistasBusiness>();

builder.Services.AddScoped<IPaisData, PaisData>();
builder.Services.AddScoped<IPaisBusiness, PaisBusiness>();

builder.Services.AddScoped<IDepartamentoData, DepartamentoData>();
builder.Services.AddScoped<IDepartamentoBusiness, DepartamentoBusiness>();

builder.Services.AddScoped<ICiudadData, CiudadData>();
builder.Services.AddScoped<ICiudadBusiness, CiudadBusiness>();


builder.Services.AddScoped<IAssessmentCriteriaData, AssessmentCriteriaData>();


builder.Services.AddScoped<ICheckListData, CheckListData>();


builder.Services.AddScoped<ICropsData, CropsData>();

builder.Services.AddScoped<IEvidencesData, EvidencesData>();




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
