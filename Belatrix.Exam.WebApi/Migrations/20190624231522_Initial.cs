using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.Exam.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    artist_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("artist_id_pkey", x => x.artist_id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    first_name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "varchar", maxLength: 30, nullable: true),
                    reports_to = table.Column<int>(nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false),
                    hire_date = table.Column<DateTime>(nullable: false),
                    address = table.Column<string>(type: "varchar", maxLength: 70, nullable: true),
                    city = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    state = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    country = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    phone = table.Column<string>(type: "varchar", maxLength: 24, nullable: true),
                    fax = table.Column<string>(type: "varchar", maxLength: 24, nullable: true),
                    email = table.Column<string>(type: "varchar", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_id_pkey", x => x.employee_id);
                    table.ForeignKey(
                        name: "employees_leader_fk",
                        column: x => x.reports_to,
                        principalTable: "employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre_id_pkey", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "media_type",
                columns: table => new
                {
                    media_type_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("media_type_id_pkey", x => x.media_type_id);
                });

            migrationBuilder.CreateTable(
                name: "playlist",
                columns: table => new
                {
                    playlist_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_id_pkey", x => x.playlist_id);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    album_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(type: "varchar", maxLength: 160, nullable: false),
                    artist_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("album_id_pkey", x => x.album_id);
                    table.ForeignKey(
                        name: "artist_album_fk",
                        column: x => x.album_id,
                        principalTable: "artist",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    first_name = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    last_name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    company = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    address = table.Column<string>(type: "varchar", maxLength: 70, nullable: true),
                    city = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    state = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    country = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    phone = table.Column<string>(type: "varchar", maxLength: 24, nullable: true),
                    fax = table.Column<string>(type: "varchar", maxLength: 24, nullable: true),
                    email = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    support_rep_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_id_pkey", x => x.customer_id);
                    table.ForeignKey(
                        name: "customers__support_employee__fk",
                        column: x => x.support_rep_id,
                        principalTable: "employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "track",
                columns: table => new
                {
                    track_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    album_id = table.Column<int>(nullable: false),
                    media_type_id = table.Column<int>(nullable: false),
                    genre_id = table.Column<int>(nullable: false),
                    composer = table.Column<string>(type: "varchar", maxLength: 220, nullable: true),
                    milliseconds = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("track_id_pkey", x => x.track_id);
                    table.ForeignKey(
                        name: "album_tracks_fk",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "genre_tracks_fk",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "media_type__tracks__fk",
                        column: x => x.media_type_id,
                        principalTable: "media_type",
                        principalColumn: "media_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    customer_id = table.Column<int>(nullable: false),
                    invoice_date = table.Column<DateTime>(nullable: false),
                    billing_address = table.Column<string>(type: "varchar", maxLength: 70, nullable: true),
                    billing_city = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    billing_state = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    billing_country = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    billing_postal_code = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_id_pkey", x => x.invoice_id);
                    table.ForeignKey(
                        name: "customer_invoices_fk",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "playlist_track",
                columns: table => new
                {
                    playlist_id = table.Column<int>(nullable: false),
                    track_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_id__track_id__pkey", x => new { x.playlist_id, x.track_id });
                    table.ForeignKey(
                        name: "playlist__playlist_tracks__fk",
                        column: x => x.playlist_id,
                        principalTable: "playlist",
                        principalColumn: "playlist_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "playlist_tracks__track__fk",
                        column: x => x.track_id,
                        principalTable: "track",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice_line",
                columns: table => new
                {
                    invoice_line_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    invoice_id = table.Column<int>(nullable: false),
                    track_id = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_line_id_pkey", x => x.invoice_line_id);
                    table.ForeignKey(
                        name: "invoice__invoice_lines__fk",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "invoice_lines__track__fk",
                        column: x => x.track_id,
                        principalTable: "track",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "artist_id_idx",
                table: "album",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "support_rep_id_idx",
                table: "customer",
                column: "support_rep_id");

            migrationBuilder.CreateIndex(
                name: "reports_to_idx",
                table: "employee",
                column: "reports_to");

            migrationBuilder.CreateIndex(
                name: "customer_id_idx",
                table: "invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "invoice_id_idx",
                table: "invoice_line",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "track_id_idx",
                table: "invoice_line",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_playlist_track_track_id",
                table: "playlist_track",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "album_id_idx",
                table: "track",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "genre_id_idx",
                table: "track",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "media_type_id_idx",
                table: "track",
                column: "media_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_line");

            migrationBuilder.DropTable(
                name: "playlist_track");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "playlist");

            migrationBuilder.DropTable(
                name: "track");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "media_type");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "artist");
        }
    }
}
