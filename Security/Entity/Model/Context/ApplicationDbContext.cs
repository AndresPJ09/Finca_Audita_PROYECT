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

            //Security

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
           .HasForeignKey(rv => rv.Rol_id);


            modelBuilder.Entity<RolVista>()
           .HasOne(rv => rv.Vista)
           .WithMany(v => v.RolVistas)
           .HasForeignKey(rv => rv.Vista_id);

            modelBuilder.Entity<UsuarioRol>()
           .HasOne(ur => ur.usuario)
           .WithMany(u => u.UsuarioRoles)
           .HasForeignKey(ur => ur.Usuario_Id);

            modelBuilder.Entity<UsuarioRol>()
           .HasOne(ur => ur.Rol)
           .WithMany(r => r.UsuarioRoles)
           .HasForeignKey(ur => ur.Rol_id);


            //Paramaters

            modelBuilder.Entity<Persona>()
            .HasOne(c => c.ciudad)
            .WithMany(p => p.persona)
            .HasForeignKey(c => c.Ciudad_id);

            // .OnDelete(DeleteBehavior.NoAction)
            //.OnUpdate(DeleteBehavior.NoAction)


            modelBuilder.Entity<Pais>()
           .HasMany(p => p.departamento)
           .WithOne(d => d.pais)
           .HasForeignKey(d => d.Pais_id);

            modelBuilder.Entity<Departamento>()
           .HasMany(d => d.ciudad)
           .WithOne(c => c.departamento)
           .HasForeignKey(c => c.Departamento_id);


            //Operational

            modelBuilder.Entity<FarmCrops>()
           .HasOne(c => c.crops)
           .WithMany(p => p.farmCrops)
           .HasForeignKey(c => c.Crop_id);

            modelBuilder.Entity<FarmCrops>()
           .HasOne(c => c.farms)
           .WithMany(p => p.farmCrops)
           .HasForeignKey(c => c.Farm_id);

            modelBuilder.Entity<Farms>()
           .HasOne(c => c.ciudad)
           .WithMany(p => p.farms)
           .HasForeignKey(c => c.Ciudad_id);

            modelBuilder.Entity<Farms>()
           .HasOne(u => u.usuario)
           .WithMany(f => f.farms)
           .HasForeignKey(u => u.Usuario_id);

            modelBuilder.Entity<Fertilization>()
           .HasOne(u => u.reviewTechnicalss)
           .WithMany(f => f.fertilization)
           .HasForeignKey(u => u.reviewTechnicals_id);

            modelBuilder.Entity<FertilizationSupplies>()
           .HasOne(u => u.supplies)
           .WithMany(f => f.fertilizationSupplies)
           .HasForeignKey(u => u.supplies_id);


            modelBuilder.Entity<FertilizationSupplies>()
           .HasOne(u => u.fertilization)
           .WithMany(f => f.fertilizationSupplies)
           .HasForeignKey(u => u.fertilization_id);


            modelBuilder.Entity<Fumigations>()
           .HasOne(u => u.reviewTechnicals)
           .WithMany(f => f.fumigations)
           .HasForeignKey(u => u.reviewTechnicals_id);

            modelBuilder.Entity<FumigationSupplies>()
           .HasOne(u => u.supplies)
           .WithMany(f => f.fumigationSupplies)
           .HasForeignKey(u => u.supplies_id);


            modelBuilder.Entity<FumigationSupplies>()
           .HasOne(u => u.fumigations)
           .WithMany(f => f.fumigationSupplies)
           .HasForeignKey(u => u.fumigation_id);
  

            modelBuilder.Entity<Qualifications>()
           .HasOne(u => u.assessment_criterian)
           .WithMany(f => f.Qualifications)
           .HasForeignKey(u => u.Assessment_criterian_id);


            modelBuilder.Entity<Qualifications>()
           .HasOne(u => u.checklist)
           .WithMany(f => f.qualifications)
           .HasForeignKey(u => u.Checklist_id);


            modelBuilder.Entity<ReviewEvidences>()
           .HasOne(u => u.Evidences)
           .WithMany(f => f.ReviewEvidences)
           .HasForeignKey(u => u.Evidence_id);


            modelBuilder.Entity<ReviewEvidences>()
           .HasOne(u => u.reviewTechnicals)
           .WithMany(f => f.reviewEvidences)
          .HasForeignKey(u => u.ReviewTechnicals_id);

            modelBuilder.Entity<ReviewTechnicals>()
           .HasOne(u => u.farms)
           .WithMany(f => f.reviewTechnicals)
           .HasForeignKey(u => u.farm_id);


            modelBuilder.Entity<ReviewTechnicals>()
           .HasOne(u => u.checkListsd)
           .WithMany(f => f.reviewTechnicals)
           .HasForeignKey(u => u.checkLists_id);

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