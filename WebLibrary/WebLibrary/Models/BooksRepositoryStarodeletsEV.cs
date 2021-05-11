using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Models
{
    public interface IBooksRepository
    {
        void Create(BooksStaroseletsEV book);
        void Delete(int id);
        BooksStaroseletsEV Get(int id);
        List<BooksStaroseletsEV> GetBooks();
        void Update(BooksStaroseletsEV book);
    }

    public class BooksRepositoryStarodeletsEV : IBooksRepository
    {
        string connectionString = null;

        public BooksRepositoryStarodeletsEV(string conn)
        {
            connectionString = conn;
        }
        public void Create(BooksStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Books (Name, Publisher, Anotation, Binding, Year, Author, Ganres, Count) " +
                    "VALUES(@name, @publisher, @anotation, @binding, @year, @author, @ganres, @count)";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery ="DELETE FROM Books WHERE idBooks = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public BooksStaroseletsEV Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BooksStaroseletsEV>("SELECT * FROM Books WHERE idBooks = @id", new { id }).FirstOrDefault();
            }
        }

        public List<BooksStaroseletsEV> GetBooks()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BooksStaroseletsEV>("SELECT [staroselets_e_v].[dbo].[Books].[Name],[Publisher],[Anotation],[Binding],[Year],[Count],[num],[Author],[GanresName],[staroselets_e_v].[dbo].[Publishers].PublisherName, [staroselets_e_v].[dbo].[Author].Sername " +
                    "FROM [staroselets_e_v].[dbo].[Books] " +
                    "INNER JOIN [staroselets_e_v].[dbo].[Author] ON " +
                    "[staroselets_e_v].[dbo].[Books].Author = [staroselets_e_v].[dbo].[Author].idAuthor " +
                    "INNER JOIN [staroselets_e_v].[dbo].[Publishers] ON " +
                    "[staroselets_e_v].[dbo].[Books].Publisher=[staroselets_e_v].[dbo].[Publishers].idPublisher " +
                    "INNER JOIN [staroselets_e_v].[dbo].[Ganres] ON " +
                    "[staroselets_e_v].[dbo].[Books].Ganres=[staroselets_e_v].[dbo].[Ganres].idGanres").ToList();
            }
        }

        public void Update(BooksStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Books SET Name = @name, Publisher = @publisher, Anotation = @anotation, Binding = @binding, Year = @year, Count = @count, Author = @author, Ganres = @ganres " +
                    "WHERE idBooks = @id";
                db.Execute(sqlQuery, book);
            }
        }
    }
}
