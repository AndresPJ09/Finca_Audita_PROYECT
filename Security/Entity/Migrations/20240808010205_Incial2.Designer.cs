﻿// <auto-generated />
using System;
using Entity.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity.Migrations
{
    [DbContext(typeof(ApplicationDbContexts))]
    [Migration("20240808010205_Incial2")]
    partial class Incial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Model.Security.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Departamento_id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Departamento_id");

                    b.ToTable("ciudad");
                });

            modelBuilder.Entity("Entity.Model.Security.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pais_id")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Pais_id");

                    b.ToTable("departamento");
                });

            modelBuilder.Entity("Entity.Model.Security.Modulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("modulo");
                });

            modelBuilder.Entity("Entity.Model.Security.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("pais");
                });

            modelBuilder.Entity("Entity.Model.Security.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("correo_electronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha_de_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primer_nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segundo_nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_de_documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("persona");
                });

            modelBuilder.Entity("Entity.Model.Security.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("rol");
                });

            modelBuilder.Entity("Entity.Model.Security.RolVista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rol_id")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Vista_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Rol_id");

                    b.HasIndex("Vista_id");

                    b.ToTable("rol_vista");
                });

            modelBuilder.Entity("Entity.Model.Security.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Persona_id")
                        .HasColumnType("int");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Persona_id");

                    b.HasIndex("RolId");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Entity.Model.Security.UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rol_id")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Rol_id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("usuario_rol");
                });

            modelBuilder.Entity("Entity.Model.Security.Vista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Modulo_id")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Modulo_id");

                    b.ToTable("vistas");
                });

            modelBuilder.Entity("Entity.Model.Security.Ciudad", b =>
                {
                    b.HasOne("Entity.Model.Security.Departamento", "departamento")
                        .WithMany("ciudad")
                        .HasForeignKey("Departamento_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("departamento");
                });

            modelBuilder.Entity("Entity.Model.Security.Departamento", b =>
                {
                    b.HasOne("Entity.Model.Security.Pais", "pais")
                        .WithMany("departamento")
                        .HasForeignKey("Pais_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pais");
                });

            modelBuilder.Entity("Entity.Model.Security.RolVista", b =>
                {
                    b.HasOne("Entity.Model.Security.Rol", "Rol")
                        .WithMany("RolVistas")
                        .HasForeignKey("Rol_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.Vista", "Vista")
                        .WithMany("RolVistas")
                        .HasForeignKey("Vista_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Vista");
                });

            modelBuilder.Entity("Entity.Model.Security.Usuario", b =>
                {
                    b.HasOne("Entity.Model.Security.Persona", "persona")
                        .WithMany("Usuario")
                        .HasForeignKey("Persona_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.Rol", null)
                        .WithMany("usuario")
                        .HasForeignKey("RolId");

                    b.Navigation("persona");
                });

            modelBuilder.Entity("Entity.Model.Security.UsuarioRol", b =>
                {
                    b.HasOne("Entity.Model.Security.Rol", "Rol")
                        .WithMany("UsuarioRoles")
                        .HasForeignKey("Rol_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.Usuario", "usuario")
                        .WithMany("UsuarioRoles")
                        .HasForeignKey("Usuario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Entity.Model.Security.Vista", b =>
                {
                    b.HasOne("Entity.Model.Security.Modulo", "Modulo")
                        .WithMany("vistas")
                        .HasForeignKey("Modulo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("Entity.Model.Security.Departamento", b =>
                {
                    b.Navigation("ciudad");
                });

            modelBuilder.Entity("Entity.Model.Security.Modulo", b =>
                {
                    b.Navigation("vistas");
                });

            modelBuilder.Entity("Entity.Model.Security.Pais", b =>
                {
                    b.Navigation("departamento");
                });

            modelBuilder.Entity("Entity.Model.Security.Persona", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entity.Model.Security.Rol", b =>
                {
                    b.Navigation("RolVistas");

                    b.Navigation("UsuarioRoles");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Entity.Model.Security.Usuario", b =>
                {
                    b.Navigation("UsuarioRoles");
                });

            modelBuilder.Entity("Entity.Model.Security.Vista", b =>
                {
                    b.Navigation("RolVistas");
                });
#pragma warning restore 612, 618
        }
    }
}
