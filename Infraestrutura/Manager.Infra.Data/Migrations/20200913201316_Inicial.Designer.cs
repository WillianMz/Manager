﻿// <auto-generated />
using System;
using Manager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Manager.Infra.Data.Migrations
{
    [DbContext(typeof(ManagerContext))]
    [Migration("20200913201316_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Manager.Domain.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("teste")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("teste")
                        .IsUnique();

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDaNota")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(400) CHARACTER SET utf8mb4")
                        .HasMaxLength(400);

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Prioridade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Prioridades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Baixo"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Normal"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Alto"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Urgente"
                        });
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Release", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Aberto"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "EmAndamento"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Concluido"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Cancelado"
                        });
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Arquivo")
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<int?>("PrioridadeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseId")
                        .HasColumnType("int");

                    b.Property<string>("Solucao")
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Tempo")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PrioridadeId");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("ReleaseId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Gerente"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "MembroEquipe"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Cliente"
                        });
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<int?>("TipoUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.UsuarioProjeto", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("UsuarioProjetos");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Documento", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Projeto", "Projeto")
                        .WithMany("Documentos")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Nota", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Ticket", "Ticket")
                        .WithMany("Notas")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Notas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Release", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Projeto", "Projeto")
                        .WithMany("Releases")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Ticket", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Categoria", "Categoria")
                        .WithMany("Tickets")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Prioridade", "Prioridade")
                        .WithMany()
                        .HasForeignKey("PrioridadeId");

                    b.HasOne("Manager.Domain.Entidades.Projeto", "Projeto")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Release", "Release")
                        .WithMany("Tickets")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("Manager.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Tickets")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.UsuarioProjeto", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("UsuarioProjetos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
