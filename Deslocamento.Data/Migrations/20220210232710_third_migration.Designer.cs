﻿// <auto-generated />
using System;
using DeslocamentoApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeslocamentoApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220210232710_third_migration")]
    partial class third_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(555)
                        .HasColumnType("nvarchar(555)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Placa");

                    b.HasKey("Id");

                    b.ToTable("Carro", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Condutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Condutor", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Deslocamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CondutorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraFinal")
                        .HasColumnType("datetime")
                        .HasColumnName("DataHorarioFim");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("DataHorarioInicio");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Observacao");

                    b.Property<decimal>("QuilometragemFinal")
                        .HasColumnType("decimal")
                        .HasColumnName("QuilometragemFinal");

                    b.Property<decimal>("QuilometragemInicial")
                        .HasColumnType("decimal")
                        .HasColumnName("QuilometragemInicial");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.ToTable("Deslocamento", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Deslocamento", b =>
                {
                    b.HasOne("DeslocamentoApi.Domain.Entities.Carro", "Carro")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Carro_Deslocamento_CarroId");

                    b.HasOne("DeslocamentoApi.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

                    b.HasOne("DeslocamentoApi.Domain.Entities.Condutor", "Condutor")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Condutor_Deslocamento_CondutorId");

                    b.Navigation("Carro");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Carro", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("DeslocamentoApi.Domain.Entities.Condutor", b =>
                {
                    b.Navigation("Deslocamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
