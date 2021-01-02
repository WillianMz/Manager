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
    [Migration("20201231003718_RetiradoCampoUnicoTabelaRelease")]
    partial class RetiradoCampoUnicoTabelaRelease
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Manager.Domain.Entidades.Anexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Anexos");
                });

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

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

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

            modelBuilder.Entity("Manager.Domain.Entidades.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.ProjetoUsuario", b =>
                {
                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<bool>("Gerente")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ProjetoId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ProjetoUsuarios");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Release", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeLiberacao")
                        .HasColumnType("datetime(6)");

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

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Versao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("CriadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataCancelamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<string>("MotivoCancelamento")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("PrioridadeAtual")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Solucao")
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<int>("StatusAtual")
                        .HasColumnType("int");

                    b.Property<int>("Tempo")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<int?>("UsuarioCancelamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioFechamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CriadorId");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("UsuarioCancelamentoId");

                    b.HasIndex("UsuarioFechamentoId");

                    b.ToTable("Tickets");
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

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.UsuarioAtivacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoAtivacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("HorasValidade")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioAtivacoes");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.Anexo", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Ticket", "Ticket")
                        .WithMany("Anexos")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manager.Domain.Entidades.ProjetoUsuario", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Projeto", "Projeto")
                        .WithMany("ProjetoUsuarios")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("ProjetoUsuarios")
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

                    b.HasOne("Manager.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Releases")
                        .HasForeignKey("UsuarioId")
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

                    b.HasOne("Manager.Domain.Entidades.Usuario", "Criador")
                        .WithMany("Tickets")
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Projeto", "Projeto")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manager.Domain.Entidades.Usuario", "UsuarioCancelamento")
                        .WithMany("TicketsCancelados")
                        .HasForeignKey("UsuarioCancelamentoId");

                    b.HasOne("Manager.Domain.Entidades.Usuario", "UsuarioFechamento")
                        .WithMany("TicketsFinalizados")
                        .HasForeignKey("UsuarioFechamentoId");
                });

            modelBuilder.Entity("Manager.Domain.Entidades.UsuarioAtivacao", b =>
                {
                    b.HasOne("Manager.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("UsuarioAtivacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
