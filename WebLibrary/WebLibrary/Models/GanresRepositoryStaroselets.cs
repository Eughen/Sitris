using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Models
{
    public interface IGanresRepository
    {
        void Create(GanresStaroseletsEV book);
        void Delete(int id);
        GanresStaroseletsEV Get(int id);
        List<GanresStaroseletsEV> GetBooks();
        void Update(GanresStaroseletsEV book);
    }

    public class GanresRepositoryStaroseletsEV : IGanresRepository
    {
        string connectionString = null;

        public GanresRepositoryStaroseletsEV(string conn)
        {
            connectionString = conn;
        }
        public void Create(GanresStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Ganres (GanresName) VALUES(@ganres)";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Ganres WHERE idGanres = @idGanres";
                db.Execute(sqlQuery, new { id });
            }
        }

        public GanresStaroseletsEV Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<GanresStaroseletsEV>("SELECT * FROM Ganres WHERE idGanres = @idGanres", new { id }).FirstOrDefault();
            }
        }

        public List<GanresStaroseletsEV> GetBooks()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<GanresStaroseletsEV>("SELECT * FROM Ganres").ToList();
            }
        }

        public void Update(GanresStaroseletsEV book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Ganres SET GanresName = @ganresName";
                db.Execute(sqlQuery, book);
            }
        }
    }
}
