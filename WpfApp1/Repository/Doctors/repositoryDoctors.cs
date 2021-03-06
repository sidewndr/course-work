﻿using System;
using System.Collections.Generic;
using WpfApp1.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.Repository
{
    class repositoryDoctors
    {
        public static List<Doctors> GetAllDoctors()
        {
            var result = new List<Doctors>();

            var db = new DB();

            string table = "doctors";
            string query = $"SELECT * FROM {table}";

            db.OpenConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var data = new Doctors
                    (
                        Int32.Parse(reader.GetValue(0).ToString()),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString()
                    );

                result.Add(data);
            }

            db.CloseConnection();

            return result;
        }

        public static void AddDoctor(Doctors data)
        {
            var db = new DB();

            string query = $"INSERT doctors VALUES (null, '{data.Name}', '{data.Type}')";

            db.OpenConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.ExecuteNonQuery();

            db.CloseConnection();
        }

        public static void DeleteDoctor(int id)
        {
            var db = new DB();

            string query = $"DELETE FROM doctors WHERE id = {id}";

            db.OpenConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.ExecuteNonQuery();

            db.CloseConnection();
        }
    }
}
