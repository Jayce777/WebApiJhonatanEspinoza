// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiKnowlegde;

#nullable disable

namespace WebApiKnowlegde.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230124195149_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApiKnowlegde.Entidades.departaments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("enterprisesId")
                        .HasColumnType("integer");

                    b.Property<int>("entrerprisesId")
                        .HasColumnType("integer");

                    b.Property<string>("modified_by")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("entrerprisesId");

                    b.ToTable("departaments");
                });

            modelBuilder.Entity("WebApiKnowlegde.Entidades.employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("modified_by")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("WebApiKnowlegde.Entidades.entrerprises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("modified_by")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("entrerprises");
                });

            modelBuilder.Entity("WebApiKnowlegde.Entidades.departaments", b =>
                {
                    b.HasOne("WebApiKnowlegde.Entidades.entrerprises", "entrerprises")
                        .WithMany()
                        .HasForeignKey("entrerprisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entrerprises");
                });
#pragma warning restore 612, 618
        }
    }
}
