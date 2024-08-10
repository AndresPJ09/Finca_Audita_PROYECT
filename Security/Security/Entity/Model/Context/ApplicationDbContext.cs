using Dapper;
using Entity.Model.Operational;
using Entity.Model.parameters;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Contexts
{
    public class ApplicationDbContexts : DbContext
    {
        protected readonly IConfiguration _configuration;
        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>()
            .HasOne(u => u.persona)
            .WithMany(p => p.Usuario)
            .HasForeignKey(u => u.Persona_id);

            modelBuilder.Entity<Vista>()
           .HasOne(u => u.Modulo)
           .WithMany(v => v.vistas)
           .HasForeignKey(u => u.Modulo_id);

            modelBuilder.Entity<RolVista>()
           .HasOne(rv => rv.Rol)
           .WithMany(r => r.RolVistas)
           .HasForeignKey(rv => rv.Rol_id)
           .OnDelete(DeleteBehavior.Restrict);

    
            modelBuilder.Entity<RolVista>()
           .HasOne(rv => rv.Vista)
           .WithMany(v => v.RolVistas)
           .HasForeignKey(rv => rv.Vista_id)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioRol>()
           .HasOne(ur => ur.usuario)
           .WithMany(u => u.UsuarioRoles)
           .HasForeignKey(ur => ur.Usuario_Id)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioRol>()
           .HasOne(ur => ur.Rol)
           .WithMany(r => r.UsuarioRoles)
           .HasForeignKey(ur => ur.Rol_id)
           .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Pais>()
         .HasMany(p => p.departamento)
         .WithOne(d => d.pais)
         .HasForeignKey(d => d.Pais_id)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Departamento>()
                .HasMany(d => d.ciudad)
                .WithOne(c => c.departamento)
                .HasForeignKey(c => c.Departamento_id)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //DataInicial.Data(modelBuilder);

            //ajuste des tipo de dato datetime
        }
        ///<summary>
        ///es una opcion en Entity Framework core que controla si se deben registar o no datos sensibles (como valores de parametros de consola)
        ///durante la ejecucion de consultas y operaciones en la base de dato.
        ///</summary>
        ///<param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            //otras configuraciones
            //Defino que todos los decimales usados tengan la precicion (18, 2)
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }
        //operatinal
        public DbSet<AssessmentCriteria> assessment_criteria => Set<AssessmentCriteria>();
        public DbSet<CheckLists> checkLists => Set<CheckLists>();
        public DbSet<Crops> crops => Set<Crops>();
        public DbSet<Evidences> evidences => Set<Evidences>();
        public DbSet<FarmCrops> farmCrops => Set<FarmCrops>();
        public DbSet<Farms> farms => Set<Farms>();
        public DbSet<Fertilization> fertilizations => Set<Fertilization>();
        public DbSet<Fumigations> Fumigations => Set<Fumigations>();
        public DbSet<FumigationSupplies> fumigationSupplies => Set<FumigationSupplies>();
        public DbSet<Qualifications> qualifications => Set<Qualifications>();
        public DbSet<ReviewEvidences> reviewEvidences => Set<ReviewEvidences>();
        public DbSet<ReviewTechnicals> reviewTechnicals => Set<ReviewTechnicals>();
        public DbSet<Supplies> Supplies => Set<Supplies>();

        //parameter
        public DbSet<Pais> pais => Set<Pais>();
        public DbSet<Departamento> departamento => Set<Departamento>();
        public DbSet<Ciudad> ciudad => Set<Ciudad>();

        //security
        public DbSet<Rol> rol => Set<Rol>();
        public DbSet<Persona> persona => Set<Persona>();
        public DbSet<Vista> vistas => Set<Vista>();
        public DbSet<UsuarioRol> usuario_rol => Set<UsuarioRol>();
        public DbSet<Modulo> modulo => Set<Modulo>();

        public DbSet<Usuario> usuario => Set<Usuario>();
        public DbSet<RolVista> rol_vista => Set<RolVista>();

  
    }
    public readonly struct DapperEFCoreCommand : IDisposable
    {
        public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
        {
            var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
            var commandType = type ?? CommandType.Text;
            var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

            Definition = new CommandDefinition(
                text,
                parameters,
                transaction,
                commandTimeout,
                commandType,
                cancellationToken: ct
                );
        }
        public CommandDefinition Definition { get; }

        public void Dispose()
        {
        }
    }
}