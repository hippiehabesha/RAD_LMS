using LMS.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace LMS.DataBase
{
    internal class LoanConnection
    {
        private string connectionString = @"Data Source=DESKTOP-G1NBITB\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private string queryIssueBook = "INSERT INTO Loans (UserID, BookID, LoanDate, DueDate) VALUES (@UserID, @BookID, @LoanDate, @DueDate)";
        private string queryUpdateAvailability = "UPDATE Books SET Availability = Availability + @Change WHERE BookID = @BookID";
        private string queryReturnBook = "UPDATE Loans SET ReturnDate = @ReturnDate, Fine = @Fine WHERE LoanID = @LoanID";
        private string queryViewLoans = "SELECT LoanID, UserID, BookID, LoanDate, DueDate, ReturnDate, Fine FROM Loans";
        private string querySearchLoansView = "SELECT * FROM Loans WHERE LoanID LIKE @SearchTerm";


        public void IssueBook(LoanModel loan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand updateCmd = new SqlCommand(queryUpdateAvailability, connection))
                {
                    updateCmd.Parameters.AddWithValue("@BookID", loan.BookID);
                    updateCmd.Parameters.AddWithValue("@Change", -1); 
                    updateCmd.ExecuteNonQuery();
                }

                using (SqlCommand issueCmd = new SqlCommand(queryIssueBook, connection))
                {
                    issueCmd.Parameters.AddWithValue("@UserID", loan.UserID);
                    issueCmd.Parameters.AddWithValue("@BookID", loan.BookID);
                    issueCmd.Parameters.AddWithValue("@LoanDate", loan.LoanDate);
                    issueCmd.Parameters.AddWithValue("@DueDate", loan.DueDate);
                    issueCmd.ExecuteNonQuery();

                    MessageBox.Show("Book issued successfully.");
                }
            }
        }

        public void ReturnBook(LoanModel loan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                double fine = 0;

                if (loan.ReturnDate.Date > loan.DueDate.Date)
                {
                    
                    int overdueDays = (loan.ReturnDate.Date).Day - (loan.DueDate.Date).Day;

                    fine = overdueDays * 5;
                }
                using (SqlCommand updateCmd = new SqlCommand(queryUpdateAvailability, connection))
                {
                    updateCmd.Parameters.AddWithValue("@BookID", loan.BookID);
                    updateCmd.Parameters.AddWithValue("@Change", 1);
                    updateCmd.ExecuteNonQuery();
                }

                using (SqlCommand returnCmd = new SqlCommand(queryReturnBook, connection))
                {
                    returnCmd.Parameters.AddWithValue("@LoanID", loan.LoanID);
                    returnCmd.Parameters.AddWithValue("@ReturnDate", loan.ReturnDate);
                    returnCmd.Parameters.AddWithValue("@Fine", fine);
                    returnCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Book returned successfully. Fine: $" + fine);
            }
        }

        public DataTable ViewLoans()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryViewLoans, connection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable("Loans");
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public DataTable SearchLoanView(string searchTerm)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(querySearchLoansView, connection))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable ViewOwnLoans(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryViewOwnLoans = "SELECT LoanID, UserID, BookID, LoanDate, DueDate, ReturnDate, Fine FROM Loans WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(queryViewOwnLoans, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable("Loans");
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

    }
}
