using Dapper;
using FindTherapist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.DataAccess
{
    public class ReviewStorage
    {
        DatabaseInterface _db;

        public ReviewStorage(DatabaseInterface db)
        {
            _db = db;
        }

        // Get Single Review

        public Reviews GetSingleReview(int ReviewId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.QueryFirstOrDefault<Reviews>(@"SELECT * From Reviews Where Id = @id", new { id = ReviewId });
                return sql;
            }
        }

        // Add Review

        public bool Add(Reviews review)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.Execute(@"INSERT INTO [dbo].[Reviews]([review],[therapistId])
                                          Values (@review, @therapistId)", review);

                return result == 1;
            }
        }

        // Update Review

        public bool Edit(Reviews review)
        {
            using (var db = _db.GetConnection())
            {

                string sql = @"UPDATE Reviews
                                 SET Review = @review,
                                TherapistId = @therapistId
                            WHERE Id = @id";
                var result = db.Execute(sql, review);
                return result == 1;
            }
        }

        // Delete Review

        public bool DeleteById(int ReviewId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Execute(@"Delete from Reviews Where Id = @id", new { id = ReviewId });
                return sql == 1;
            }
        }

    }
}
