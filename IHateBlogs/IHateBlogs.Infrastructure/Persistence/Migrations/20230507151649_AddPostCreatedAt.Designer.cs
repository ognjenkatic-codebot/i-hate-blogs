﻿// <auto-generated />
using System;
using IHateBlogs.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IHateBlogs.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20230507151649_AddPostCreatedAt")]
    partial class AddPostCreatedAt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IHateBlogs.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uuid")
                        .HasColumnName("requester_id");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.HasKey("Id")
                        .HasName("pk_posts");

                    b.HasIndex("RequesterId")
                        .HasDatabaseName("ix_posts_requester_id");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("IHateBlogs.Domain.Entities.Requester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("IpHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ip_hash");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_requesters");

                    b.ToTable("requesters", (string)null);
                });

            modelBuilder.Entity("IHateBlogs.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_tags");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<Guid>("PostsId")
                        .HasColumnType("uuid")
                        .HasColumnName("posts_id");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid")
                        .HasColumnName("tags_id");

                    b.HasKey("PostsId", "TagsId")
                        .HasName("pk_post_tag");

                    b.HasIndex("TagsId")
                        .HasDatabaseName("ix_post_tag_tags_id");

                    b.ToTable("post_tag", (string)null);
                });

            modelBuilder.Entity("IHateBlogs.Domain.Entities.Post", b =>
                {
                    b.HasOne("IHateBlogs.Domain.Entities.Requester", "Requester")
                        .WithMany("Posts")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_posts_requesters_requester_id");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("IHateBlogs.Domain.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_post_tag_posts_posts_id");

                    b.HasOne("IHateBlogs.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_post_tag_tags_tags_id");
                });

            modelBuilder.Entity("IHateBlogs.Domain.Entities.Requester", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
