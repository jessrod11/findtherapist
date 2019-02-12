using FindTherapist.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.DataAccess
{
    public class SavedStorage
    {
        DatabaseInterface _db;

        public SavedStorage(DatabaseInterface db)
        {
            _db = db;
        }

        // Get Saved Therapists

        public List<SavedTherapist> GetAll()
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"Select 
                                Id = Therapists.id,
                                FirstName = Therapists.firstname,
                                LastName = Therapists.lastname,
                                Img = Therapists.img,
                                Specialty = Therapists.specialty
                                from SavedTherapist s
                                join Therapists on Therapists.id = s.therapistId";
                return db.Query<SavedTherapist>(sql).ToList();
            }
        }

        // Get Saved Therapist By Id

        public SavedTherapist GetSingleTherapist(int TherapistId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.QueryFirstOrDefault<SavedTherapist>(@"SELECT * From SavedTherapist Where TherapistId = @id", new { id = TherapistId });
                return sql;
            }
        }


        // Save a Therapist

        public bool Add(SavedTherapist saved)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.Execute(@"INSERT INTO [dbo].[SavedTherapist]([therapistId])
                                          Values (@therapistId)", saved);

                return result == 1;
            }
        }

        // Delete a Saved Therapist

        public bool DeleteById(int TherapistId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Execute(@"Delete from SavedTherapist Where TherapistId = @id", new { id = TherapistId });
                return sql == 1;
            }
        }
    }
}
