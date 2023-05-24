﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230524071303_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Blog.Models.BlogPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BlogPage");
                });

            modelBuilder.Entity("Blog.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Blog.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Blog.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Blog.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Blog.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BlogPageCategory", b =>
                {
                    b.Property<int>("BlogPagesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BlogPagesId", "CategoriesCategoryId");

                    b.HasIndex("CategoriesCategoryId");

                    b.ToTable("BlogPageCategory");
                });

            modelBuilder.Entity("BlogPageComment", b =>
                {
                    b.Property<int>("BlogPagesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentsCommentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BlogPagesId", "CommentsCommentId");

                    b.HasIndex("CommentsCommentId");

                    b.ToTable("BlogPageComment");
                });

            modelBuilder.Entity("BlogPagePost", b =>
                {
                    b.Property<int>("BlogPagesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostsPostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BlogPagesId", "PostsPostId");

                    b.HasIndex("PostsPostId");

                    b.ToTable("BlogPagePost");
                });

            modelBuilder.Entity("BlogPageTag", b =>
                {
                    b.Property<int>("BlogPagesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BlogPagesId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("BlogPageTag");
                });

            modelBuilder.Entity("BlogPageUser", b =>
                {
                    b.Property<int>("BlogPagesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BlogPagesId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("BlogPageUser");
                });

            modelBuilder.Entity("BlogPageCategory", b =>
                {
                    b.HasOne("Blog.Models.BlogPage", null)
                        .WithMany()
                        .HasForeignKey("BlogPagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogPageComment", b =>
                {
                    b.HasOne("Blog.Models.BlogPage", null)
                        .WithMany()
                        .HasForeignKey("BlogPagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogPagePost", b =>
                {
                    b.HasOne("Blog.Models.BlogPage", null)
                        .WithMany()
                        .HasForeignKey("BlogPagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogPageTag", b =>
                {
                    b.HasOne("Blog.Models.BlogPage", null)
                        .WithMany()
                        .HasForeignKey("BlogPagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogPageUser", b =>
                {
                    b.HasOne("Blog.Models.BlogPage", null)
                        .WithMany()
                        .HasForeignKey("BlogPagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
