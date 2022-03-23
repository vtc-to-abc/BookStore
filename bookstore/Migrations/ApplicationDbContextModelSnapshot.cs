﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookstore.Data;

#nullable disable

namespace bookstore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bookstore.Models.Author", b =>
                {
                    b.Property<int>("author_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("author_id"), 1L, 1);

                    b.Property<string>("pseudonym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("author_id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("bookstore.Models.AuthorBook", b =>
                {
                    b.Property<int>("author_id")
                        .HasColumnType("int");

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.HasKey("author_id", "book_id");

                    b.HasIndex("book_id");

                    b.ToTable("author_book");
                });

            modelBuilder.Entity("bookstore.Models.Book", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("book_id"), 1L, 1);

                    b.Property<string>("book_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("current_rent")
                        .HasColumnType("int");

                    b.Property<int>("stored_copies")
                        .HasColumnType("int");

                    b.HasKey("book_id");

                    b.ToTable("book");
                });

            modelBuilder.Entity("bookstore.Models.BookCategory", b =>
                {
                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.HasKey("category_id", "book_id");

                    b.HasIndex("book_id");

                    b.ToTable("category_book");
                });

            modelBuilder.Entity("bookstore.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"), 1L, 1);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("bookstore.Models.Renter", b =>
                {
                    b.Property<int>("renter_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("renter_id"), 1L, 1);

                    b.Property<string>("renter_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("renter_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("renter_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("renter_id");

                    b.ToTable("renter");
                });

            modelBuilder.Entity("bookstore.Models.RentOrder", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"), 1L, 1);

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("rent_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("rent_status")
                        .HasColumnType("int");

                    b.Property<int>("renter_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("return_date")
                        .HasColumnType("datetime2");

                    b.HasKey("order_id");

                    b.HasIndex("book_id");

                    b.HasIndex("renter_id");

                    b.ToTable("rentorder");
                });

            modelBuilder.Entity("bookstore.Models.AuthorBook", b =>
                {
                    b.HasOne("bookstore.Models.Author", "author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bookstore.Models.Book", "book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("book");
                });

            modelBuilder.Entity("bookstore.Models.BookCategory", b =>
                {
                    b.HasOne("bookstore.Models.Book", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bookstore.Models.Category", "Category")
                        .WithMany("CategoryBooks")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("bookstore.Models.RentOrder", b =>
                {
                    b.HasOne("bookstore.Models.Book", "book")
                        .WithMany("BookOrders")
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bookstore.Models.Renter", "renter")
                        .WithMany("RenterOrders")
                        .HasForeignKey("renter_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("renter");
                });

            modelBuilder.Entity("bookstore.Models.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("bookstore.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookCategories");

                    b.Navigation("BookOrders");
                });

            modelBuilder.Entity("bookstore.Models.Category", b =>
                {
                    b.Navigation("CategoryBooks");
                });

            modelBuilder.Entity("bookstore.Models.Renter", b =>
                {
                    b.Navigation("RenterOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
