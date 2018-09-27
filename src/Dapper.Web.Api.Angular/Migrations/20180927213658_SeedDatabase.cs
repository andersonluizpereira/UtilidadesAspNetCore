using Microsoft.EntityFrameworkCore.Migrations;

namespace Dapper.Web.Api.Angular.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Marcas
            migrationBuilder.Sql("INSERT INTO Marcas (Nome) VALUES ('Ford')");
            migrationBuilder.Sql("INSERT INTO Marcas (Nome) VALUES ('GM')");
            migrationBuilder.Sql("INSERT INTO Marcas (Nome) VALUES ('Honda')");
            //Modelos
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Fiesta', (SELECT Id FROM Marcas Where Nome= 'Ford'))");
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Ka', (SELECT Id FROM Marcas Where Nome= 'Ford'))");
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Eco Esport', (SELECT Id FROM Marcas Where Nome= 'Ford'))");
            //Modelos
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Prisma', (SELECT Id FROM Marcas Where Nome= 'GM'))");
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Onix', (SELECT Id FROM Marcas Where Nome= 'GM'))");
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Cruze', (SELECT Id FROM Marcas Where Nome= 'GM'))");
            //modelos
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Civic', (SELECT Id FROM Marcas Where Nome= 'Honda'))");
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('Fit', (SELECT Id FROM Marcas Where Nome= 'Honda'))");
            migrationBuilder.Sql("INSERT INTO Modelos (Nome, MarcaId) VALUES ('HRV Suv', (SELECT Id FROM Marcas Where Nome= 'Honda'))");
            //acessórios
            migrationBuilder.Sql("INSERT INTO Acessorios (Nome) VALUES ('Ar Condicionado')");
            migrationBuilder.Sql("INSERT INTO Acessorios (Nome) VALUES ('Bancos de Couro')");
            migrationBuilder.Sql("INSERT INTO Acessorios (Nome) VALUES ('Câmera de Ré')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Marcas WHERE Nome IN ('Ford','GM','Honda')");
            migrationBuilder.Sql("DELETE FROM Acessorios WHERE Nome IN ('Ar Condicionado', 'Bancos de Couro', 'Câmera de Ré')");
        }
    }
}
