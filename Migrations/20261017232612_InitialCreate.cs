using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Taras Shevchenko" },
                    { 2, "Lesya Ukrainka" },
                    { 3, "Ivan Franko" },
                    { 4, "George Orwell" },
                    { 5, "Ernest Hemingway" },
                    { 6, "Fyodor Dostoevsky" },
                    { 7, "Mark Twain" },
                    { 8, "Agatha Christie" },
                    { 9, "Stephen King" },
                    { 10, "J.K. Rowling" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Taras Book 1", 1901 },
                    { 2, 1, "Taras Book 2", 1902 },
                    { 3, 1, "Taras Book 3", 1903 },
                    { 4, 1, "Taras Book 4", 1904 },
                    { 5, 1, "Taras Book 5", 1905 },
                    { 6, 1, "Taras Book 6", 1906 },
                    { 7, 1, "Taras Book 7", 1907 },
                    { 8, 1, "Taras Book 8", 1908 },
                    { 9, 1, "Taras Book 9", 1909 },
                    { 10, 1, "Taras Book 10", 1910 },
                    { 11, 2, "Lesya Book 1", 1911 },
                    { 12, 2, "Lesya Book 2", 1912 },
                    { 13, 2, "Lesya Book 3", 1913 },
                    { 14, 2, "Lesya Book 4", 1914 },
                    { 15, 2, "Lesya Book 5", 1915 },
                    { 16, 2, "Lesya Book 6", 1916 },
                    { 17, 2, "Lesya Book 7", 1917 },
                    { 18, 2, "Lesya Book 8", 1918 },
                    { 19, 2, "Lesya Book 9", 1919 },
                    { 20, 2, "Lesya Book 10", 1920 },
                    { 21, 3, "Ivan Book 1", 1921 },
                    { 22, 3, "Ivan Book 2", 1922 },
                    { 23, 3, "Ivan Book 3", 1923 },
                    { 24, 3, "Ivan Book 4", 1924 },
                    { 25, 3, "Ivan Book 5", 1925 },
                    { 26, 3, "Ivan Book 6", 1926 },
                    { 27, 3, "Ivan Book 7", 1927 },
                    { 28, 3, "Ivan Book 8", 1928 },
                    { 29, 3, "Ivan Book 9", 1929 },
                    { 30, 3, "Ivan Book 10", 1930 },
                    { 31, 4, "George Book 1", 1931 },
                    { 32, 4, "George Book 2", 1932 },
                    { 33, 4, "George Book 3", 1933 },
                    { 34, 4, "George Book 4", 1934 },
                    { 35, 4, "George Book 5", 1935 },
                    { 36, 4, "George Book 6", 1936 },
                    { 37, 4, "George Book 7", 1937 },
                    { 38, 4, "George Book 8", 1938 },
                    { 39, 4, "George Book 9", 1939 },
                    { 40, 4, "George Book 10", 1940 },
                    { 41, 5, "Ernest Book 1", 1941 },
                    { 42, 5, "Ernest Book 2", 1942 },
                    { 43, 5, "Ernest Book 3", 1943 },
                    { 44, 5, "Ernest Book 4", 1944 },
                    { 45, 5, "Ernest Book 5", 1945 },
                    { 46, 5, "Ernest Book 6", 1946 },
                    { 47, 5, "Ernest Book 7", 1947 },
                    { 48, 5, "Ernest Book 8", 1948 },
                    { 49, 5, "Ernest Book 9", 1949 },
                    { 50, 5, "Ernest Book 10", 1950 },
                    { 51, 6, "Fyodor Book 1", 1951 },
                    { 52, 6, "Fyodor Book 2", 1952 },
                    { 53, 6, "Fyodor Book 3", 1953 },
                    { 54, 6, "Fyodor Book 4", 1954 },
                    { 55, 6, "Fyodor Book 5", 1955 },
                    { 56, 6, "Fyodor Book 6", 1956 },
                    { 57, 6, "Fyodor Book 7", 1957 },
                    { 58, 6, "Fyodor Book 8", 1958 },
                    { 59, 6, "Fyodor Book 9", 1959 },
                    { 60, 6, "Fyodor Book 10", 1960 },
                    { 61, 7, "Mark Book 1", 1961 },
                    { 62, 7, "Mark Book 2", 1962 },
                    { 63, 7, "Mark Book 3", 1963 },
                    { 64, 7, "Mark Book 4", 1964 },
                    { 65, 7, "Mark Book 5", 1965 },
                    { 66, 7, "Mark Book 6", 1966 },
                    { 67, 7, "Mark Book 7", 1967 },
                    { 68, 7, "Mark Book 8", 1968 },
                    { 69, 7, "Mark Book 9", 1969 },
                    { 70, 7, "Mark Book 10", 1970 },
                    { 71, 8, "Agatha Book 1", 1971 },
                    { 72, 8, "Agatha Book 2", 1972 },
                    { 73, 8, "Agatha Book 3", 1973 },
                    { 74, 8, "Agatha Book 4", 1974 },
                    { 75, 8, "Agatha Book 5", 1975 },
                    { 76, 8, "Agatha Book 6", 1976 },
                    { 77, 8, "Agatha Book 7", 1977 },
                    { 78, 8, "Agatha Book 8", 1978 },
                    { 79, 8, "Agatha Book 9", 1979 },
                    { 80, 8, "Agatha Book 10", 1980 },
                    { 81, 9, "Stephen Book 1", 1981 },
                    { 82, 9, "Stephen Book 2", 1982 },
                    { 83, 9, "Stephen Book 3", 1983 },
                    { 84, 9, "Stephen Book 4", 1984 },
                    { 85, 9, "Stephen Book 5", 1985 },
                    { 86, 9, "Stephen Book 6", 1986 },
                    { 87, 9, "Stephen Book 7", 1987 },
                    { 88, 9, "Stephen Book 8", 1988 },
                    { 89, 9, "Stephen Book 9", 1989 },
                    { 90, 9, "Stephen Book 10", 1990 },
                    { 91, 10, "J.K. Book 1", 1991 },
                    { 92, 10, "J.K. Book 2", 1992 },
                    { 93, 10, "J.K. Book 3", 1993 },
                    { 94, 10, "J.K. Book 4", 1994 },
                    { 95, 10, "J.K. Book 5", 1995 },
                    { 96, 10, "J.K. Book 6", 1996 },
                    { 97, 10, "J.K. Book 7", 1997 },
                    { 98, 10, "J.K. Book 8", 1998 },
                    { 99, 10, "J.K. Book 9", 1999 },
                    { 100, 10, "J.K. Book 10", 2000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
