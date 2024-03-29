﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAPI.DataBase;

namespace MyAPI.Migrations
{
    [DbContext(typeof(MimicContext))]
    [Migration("20200327031203_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("MyAPI.Models.Palavra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("Atualizado");

                    b.Property<DateTime>("Criado");

                    b.Property<string>("Nome");

                    b.Property<int>("Pontuacao");

                    b.HasKey("Id");

                    b.ToTable("Palavras");
                });
#pragma warning restore 612, 618
        }
    }
}
