﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectService.Infrastructure.Persistence;

#nullable disable

namespace ProjectService.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectServiceDbContext))]
    [Migration("20230806131103_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectService.Domain.Entity.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("componentid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("projectid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("createdby");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("modifiedby");

                    b.HasKey("Id", "ProjectId");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("idx_components_projectid");

                    b.ToTable("components", (string)null);
                });

            modelBuilder.Entity("ProjectService.Domain.Entity.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("projectid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("createdby");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("modifiedby");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ownerid");

                    b.Property<int>("ProjectStatus")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("projectstatus");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("workflowid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectStatus")
                        .HasDatabaseName("idx_projects_projectstatus");

                    b.HasIndex("WorkflowId")
                        .HasDatabaseName("idx_projects_workflowid");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("ProjectService.Domain.Entity.ProjectUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("projectid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("createdby");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("modifiedby");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("userrole");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("idx_projectusers_projectid");

                    b.HasIndex("UserId")
                        .HasDatabaseName("idx_projectusers_userid");

                    b.ToTable("projectusers", (string)null);
                });

            modelBuilder.Entity("ProjectService.Domain.Entity.Component", b =>
                {
                    b.HasOne("ProjectService.Domain.Entity.Project", "Project")
                        .WithMany("Components")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ProjectService.Domain.Entity.Details", "Details", b1 =>
                        {
                            b1.Property<Guid>("ComponentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ComponentProjectId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("componentDescription");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("componentName");

                            b1.HasKey("ComponentId", "ComponentProjectId");

                            b1.ToTable("components");

                            b1.WithOwner()
                                .HasForeignKey("ComponentId", "ComponentProjectId");
                        });

                    b.Navigation("Details")
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectService.Domain.Entity.Project", b =>
                {
                    b.OwnsOne("ProjectService.Domain.Entity.Details", "Details", b1 =>
                        {
                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("projectDescription");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("projectName");

                            b1.HasKey("ProjectId");

                            b1.ToTable("projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("Details")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectService.Domain.Entity.ProjectUser", b =>
                {
                    b.HasOne("ProjectService.Domain.Entity.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectService.Domain.Entity.Project", b =>
                {
                    b.Navigation("Components");
                });
#pragma warning restore 612, 618
        }
    }
}
