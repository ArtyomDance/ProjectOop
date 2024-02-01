using Npgsql;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Shiish
{
    internal class DbManager
    {
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost; Port=5432; User Id=postgres; Password=2135467; Database=projectoop");
        }

        public void ChangeValue(int id, string tableName, string columnName, string newValue)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                string query = $"UPDATE public.{tableName} SET {columnName} = @newValue WHERE item_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@newValue", newValue);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Record with ID {id} updated successfully in table {tableName}. {columnName} changed to {newValue}.");
                    }
                    else
                    {
                        Console.WriteLine($"No records found with ID {id} in table {tableName}.");
                    }
                }
            }
        }
        // comennt
        public string GetValueByColumn(string columnName, string columnValue, string tableName, string resultColumnName)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                string query = $"SELECT {resultColumnName} FROM public.{tableName} WHERE {columnName} = @value";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@value", columnValue);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public void InsertRecordUser(string tableName, string column1, string value1, string column2, string value2, string column3, string value3, string column4, string value4)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                string query = $"INSERT INTO public.{tableName}({column1}, {column2}, {column3}, {column4}) VALUES (@value1, @value2, @value3, @value4)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.Parameters.AddWithValue("@value3", value3);
                    cmd.Parameters.AddWithValue("@value4", value4);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertRecordItem(string tableName, string column1, string value1, string column2, string value2, string column3, string value3)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                string query = $"INSERT INTO public.{tableName}({column1}, {column2}, {column3}) VALUES (@value1, @value2, @value3)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.Parameters.AddWithValue("@value3", value3);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LoadDataIntoDataGridView(DataGridView dataGridView)
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM items";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Привязка данных к DataGridView
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        public void DeleteRecordById(int id, string tableName)
        {
            using (NpgsqlConnection con = GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand($"DELETE FROM public.{tableName} WHERE item_id = @id", con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                // Здесь нет вывода в консоль
            }
        }
    }
}
