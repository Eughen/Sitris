using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Models
{
    public interface IAuthorRepository
    {
        void Create(AuthorStaroseletsEV book);
        void Delete(int id);
        AuthorStaroseletsEV Get(int id);
        List<AuthorStaroseletsEV> GetBooks();
        void Update(AuthorStaroseletsEV book);
    }

    public class AuthorRepositoryStaroseletsEV: IAuthorRepository
    {
        string connectionString = null;

        public AuthorRepositoryStaroseletsEV(string conn)
        {
            connectionString = conn;
        }
        public void Create(AuthorStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Author (Name, SecondName, Sername, Psevdonim) VALUES(@name, @secondName, @sername, @psevdonim)";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Author WHERE idAuthor = @idAuthor";
                db.Execute(sqlQuery, new { id });
            }
        }

        public AuthorStaroseletsEV Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorStaroseletsEV>("SELECT * FROM Author WHERE idAuthor = @idAuthor", new { id }).FirstOrDefault();
            }
        }

        public List<AuthorStaroseletsEV> GetBooks()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorStaroseletsEV>("SELECT * FROM Author").ToList();
            }
        }

        public void Update(AuthorStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Author SET Name = @name, SecondName = @secondName, Sername = @sername, Psevdonim = @psevdonim WHERE idAuthor = @idAuthor";
                db.Execute(sqlQuery, book);
            }
        }
    }
}

