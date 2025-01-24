using Microsoft.Data.SqlClient;
using LMS.Model;
using System.Data;
using System.Windows;
namespace LMS.DataBase
{
    internal class bookConnection
    {
        string queryDeleteLoans = "DELETE FROM dbo.Loans WHERE BookID = @BookID";
        private string queryCheck = "SELECT COUNT(1) FROM dbo.Books WHERE ISBN = @ISBN";
        private string querySearch = "SELECT BookID, Title, Author, Genre FROM Books WHERE BookID = @BookID";
        private string queryAvailabilityUpdate = "UPDATE Books SET Availability = Availability + @Change WHERE BookID = @BookID";
        private string queryView = "SELECT BookID, Title, Author, Genre, ISBN, Availability FROM Books";
        private string queryDelete = "DELETE FROM Books WHERE BookID = @BookID";
        private string queryUpdate = "UPDATE Books SET Title = @NewTitle, Author = @NewAuthor, Genre = @NewGenre WHERE BookID = @BookID";
        private string queryAdd = "INSERT INTO Books (Title, Author, Genre, ISBN, Availability) VALUES (@Title, @Author, @Genre, @ISBN, @Availability)";
        private string connectionString = @"Data Source=DESKTOP-G1NBITB\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public void AddBook(bookModel add)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                
                using (SqlCommand checkCmd = new SqlCommand(queryCheck, connection))
                {
                    checkCmd.Parameters.AddWithValue("@ISBN", add.isbn);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Book with this ISBN already exists.");
                        return;
                    }
                }

                
                using (SqlCommand cmd = new SqlCommand(queryAdd, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", add.title);
                    cmd.Parameters.AddWithValue("@Author", add.author);
                    cmd.Parameters.AddWithValue("@Genre", add.genre);
                    cmd.Parameters.AddWithValue("@ISBN", add.isbn);
                    cmd.Parameters.AddWithValue("@Availability", add.availability);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully.");
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

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book details updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Book not found.");
                    }
                }
            }
        }
        public void DeleteBook(bookModel delete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                using (SqlCommand checkCmd = new SqlCommand(queryDeleteLoans, connection))
                {
                    checkCmd.Parameters.AddWithValue("@BookID", delete.bookID);
                    int rowsAffected = checkCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        
                        return;
                    }
                }

                using (SqlCommand cmd = new SqlCommand(queryDelete, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", delete.bookID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Book not found.");
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
                    MessageBox.Show("Book availability updated.");
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
                                genre = reader["Genre"].ToString()                                                             
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
        public DataTable SearchBook(string searchTerm)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.Books WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm OR Genre LIKE @SearchTerm OR ISBN LIKE @SearchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
