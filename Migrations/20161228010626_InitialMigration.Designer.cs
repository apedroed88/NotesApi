using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AppContext;
using GerenciadorDeTarefas.Config.Models;

namespace GerenciadorDeTarefas.Migrations
{
    [DbContext(typeof(GerenciadorDeTarefasContext))]
    [Migration("20161228010626_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("GerenciadorDeTarefas.Config.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<int>("StatusDaTarefa");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("TarefaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("GerenciadorDeTarefas.Config.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<Guid>("Guid");

                    b.Property<int>("NivelDeAcesso");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GerenciadorDeTarefas.Config.Models.Tarefa", b =>
                {
                    b.HasOne("GerenciadorDeTarefas.Config.Models.Usuario", "Usuario")
                        .WithMany("Tarefas")
                        .HasForeignKey("UsuarioId");
                });
        }
    }
}
