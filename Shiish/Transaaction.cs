using Npgsql;
using System;

namespace Shiish
{
    internal class Transaction : DbManager
    {
        public void RentItem(int userId, int itemId)
        {
            try
            {
                // Sprawdź dostępność przedmiotu przed wypożyczeniem
                if (IsItemAvailable(itemId))
                {
                    // Dodaj informacje o transakcji do bazy danych
                    InsertTransaction(userId, itemId);

                    // Oznacz przedmiot jako wypożyczony
                    UpdateItemStatus(itemId, "Wypożyczony");

                    Console.WriteLine($"Przedmiot o ID {itemId} został wypożyczony przez użytkownika o ID {userId}.");
                }
                else
                {
                    Console.WriteLine($"Przedmiot o ID {itemId} jest niedostępny do wypożyczenia.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas wypożyczania przedmiotu: {ex.Message}");
            }
        }

        private bool IsItemAvailable(int itemId)
        {
            // Sprawdź, czy przedmiot jest dostępny do wypożyczenia
            string itemStatus = GetItemStatus(itemId);
            return itemStatus == "Dostępny";
        }

        private void InsertTransaction(int userId, int itemId)
        {
            // Dodaj rekord o transakcji do bazy danych
            InsertRecordTransaction("transactions", "user_id", userId.ToString(), "item_id", itemId.ToString());
        }

        private void UpdateItemStatus(int itemId, string newStatus)
        {
            // Zaktualizuj status przedmiotu w bazie danych
            ChangeValue(itemId, "items", "item_status", newStatus);
        }

        private string GetItemStatus(int itemId)
        {
            // Pobierz status przedmiotu z bazy danych
            return GetValueByColumn("item_id", itemId.ToString(), "items", "item_status");
        }

        private void InsertRecordTransaction(string tableName, string column1, string value1, string column2, string value2)
        {
            // Dodaj rekord transakcji do bazy danych
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                string query = $"INSERT INTO public.{tableName}({column1}, {column2}) VALUES (@value1, @value2)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
