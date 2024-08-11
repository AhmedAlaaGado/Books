using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO Authors (Name)
VALUES 
('J.K. Rowling'),
('George R.R. Martin'),
('Jane Austen');

INSERT INTO Publishers (Name)
VALUES 
('Bloomsbury Publishing'),
('Bantam Books'),
('Penguin Books');

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
