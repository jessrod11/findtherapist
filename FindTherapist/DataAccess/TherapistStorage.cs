using Dapper;
using FindTherapist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.DataAccess
{
    public class TherapistStorage
    {
        DatabaseInterface _db;

        public TherapistStorage(DatabaseInterface db)
        {
            _db = db;
        }

        // Get all Therapists 
        public List<Therapists> GetAllTherapists()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "Select * from Therapists";
                return db.Query<Therapists>(sql).ToList();
            }
        }

       // Get first 20 Therapists
        public List<Therapists> GetSomeTherapists()
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"Select top 20
                                t.id, 
	                            t.firstname,
	                            t.lastname,
	                            t.img,
	                            t.specialty
                                From Therapists t";
                return db.Query<Therapists>(sql).ToList();
            }
        }

        // Get Single Therapist
        public Therapists GetSingleTherapist(int TherapistId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.QueryFirstOrDefault<Therapists>(@"SELECT * From Therapists Where Id = @id", new { id = TherapistId });
                return sql;
            }
        }

        // Get By Specialty

        public List <Therapists> GetSpecialty(string Specialty)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Query<Therapists>(@"Select * from Therapists Where Specialty = @specialty", new { specialty = Specialty });
                return sql.ToList();
            }
        }

        // Delete Single Therapist

        public bool DeleteById(int TherapistId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Execute(@"Delete from Therapists Where Id = @id", new { id = TherapistId });
                return sql == 1;
            }
        }
    }
}
