using Microsoft.Data.SqlClient;
using LMS.Model;
using System.Data;
using System.Windows;
namespace LMS.DataBase
{
    internal class bookConnection
    {
        private string querySearch = "SELECT BookID, Title, Author, Genre, ISBN, Availability FROM Books WHERE BookID = @BookID";
        private string queryAvailabilityUpdate = "UPDATE Books SET Availability = Availability + @Change WHERE BookID = @BookID";
        private string queryView = "SELECT BookID, Title, Author, Genre, ISBN, Availability FROM Books";
        private string queryDelete = "DELETE FROM Books WHERE BookID = @BookID";
        private string queryUpdate = "UPDATE Books SET Title = @NewTitle, Author = @NewAuthor, Genre = @NewGenre, Availability = @NewAvailability WHERE BookID = @BookID";
        private string queryAdd = "INSERT INTO Books (Title, Author, Genre, ISBN, Availability) VALUES (@Title, @Author, @Genre, @ISBN, @Availability)";
        private string connectionString = @"Data Source=DESKTOP-G1NBITB\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public void AddBook(bookModel add)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryAdd, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", add.title);
                    cmd.Parameters.AddWithValue("@Author", add.author);
                    cmd.Parameters.AddWithValue("@Genre", add.genre);
                    cmd.Parameters.AddWithValue("@ISBN", add.isbn);
                    cmd.Parameters.AddWithValue("@Availability", add.availability);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Book added successfully.");
                }
            }
        }
        public void UpdateBook(bookModel update)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", update.bookID);
                    cmd.Parameters.AddWithValue("@NewTitle", update.title);
                    cmd.Parameters.AddWithValue("@NewAuthor", update.author);
                    cmd.Parameters.AddWithValue("@NewGenre", update.genre);
                    cmd.Parameters.AddWithValue("@NewAvailability", update.availability);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Book details updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
            }
        }
        public void DeleteBook(bookModel delete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", delete.bookID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Book deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
            }
        }
        public DataTable ViewBook()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryView, connection))
                {
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable("Books");
                    dataAdapter.Fill(dataTable);
                    return dataTable;

                }

            }
        }
        public void UpdateBookAvailability(bookModel availabilityUpdate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryAvailabilityUpdate, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", availabilityUpdate.bookID);
                    cmd.Parameters.AddWithValue("@Change", availabilityUpdate.change);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Book availability updated.");
                }
            }
        }
        public bookModel BookSearch(int bookID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(querySearch, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new bookModel
                            {
                                title = reader["Title"].ToString(),
                                author = reader["Author"].ToString(),
                                genre = reader["Genre"].ToString(),
                                isbn = reader["ISBN"].ToString(),
                                availability = int.TryParse(reader["Availability"].ToString(), out int availability) ? availability : 0
                            };
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}
