using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Models
{
    public interface IPublisherRepository
    {
        void Create(PublisherStaroseletsEV book);
        void Delete(int id);
        PublisherStaroseletsEV Get(int id);
        List<PublisherStaroseletsEV> GetBooks();
        void Update(PublisherStaroseletsEV book);
    }

    public class PublisherRepositoryStaroseletsEV : IPublisherRepository
    {
        string connectionString = null;

        public PublisherRepositoryStaroseletsEV(string conn)
        {
            connectionString = conn;
        }
        public void Create(PublisherStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Publishers (PublisherName, Adress, Phone, Mail) VALUES(@publisherName, @adress, @phone, @mail)";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Publishers WHERE idPublisher = @idPublisher";
                db.Execute(sqlQuery, new { id });
            }
        }

        public PublisherStaroseletsEV Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<PublisherStaroseletsEV>("SELECT * FROM Publishers WHERE idPublisher = @idPublisher", new { id }).FirstOrDefault();
            }
        }

        public List<PublisherStaroseletsEV> GetBooks()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<PublisherStaroseletsEV>("SELECT * FROM Publishers").ToList();
            }
        }

        public void Update(PublisherStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Author SET PublisherName = @PublisherName, Adress = @adress, Phone = @phone, Mail = @mail WHERE idPublisher = @idPublishr";
                db.Execute(sqlQuery, book);
            }
        }
    }
}
