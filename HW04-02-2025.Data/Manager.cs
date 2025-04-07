using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HW04_02_2025.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }


    public class Manager
    {
        private string _connectionString;

        public Manager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "Select * From People";
            connection.Open();
            var p = new List<Person>();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                p.Add(new Person
                { 
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                }); 
            }
            return p;
        }

        public void AddMultiple(List<Person> p)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO people " +
                "Values(@first, @last,@age)";
            connection.Open();
            foreach(var person in p)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@first", person.FirstName);
                cmd.Parameters.AddWithValue("@last", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMultiple(List<int> id)
        {
            using var connection = new SqlConnection(_connectionString);

            List<string> parameters = new List<string>();
            for (int i = 0; i <id.Count; i++)
            {
                parameters.Add($"@id{i}");
            }

            string s = $"DELETE FROM people WHERE ID In({string.Join(",", parameters)})";
            using SqlCommand cmd = new SqlCommand(s, connection);
            for (int i = 0; i < id.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@id{i}", id[i]);
            }
            connection.Open();
            cmd.ExecuteNonQuery();

        }
    }
}
