using LMS.Control;
using LMS.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Windows;


namespace LMS.DataBase
{
    internal class UserConnection
    {
        private string queryChangePassword = "UPDATE Users SET PasswordHash = @passwordHash WHERE UserID = @UserID";
        private string queryUpdate = "UPDATE Users SET Username = @Username ,PasswordHash = @passwordHash, Role = @Role WHERE UserID = @UserID";
        private string querySave = "INSERT INTO Users(Username, PasswordHash, Role) Values(@userName, @passwordHash, @role)";
        private string queryView = "SELECT UserID, Username, Role FROM Users";
        private string queryUniqueness = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
        private string queryRole = "SELECT Role FROM Users WHERE Username = @userName AND PasswordHash = @passwordHash";
        private string queryRegister = "INSERT INTO Users(Username, PasswordHash, Role) Values(@userName, @passwordHash, @role)";
        private string queryDelete = "DELETE FROM Users WHERE Username = @Username";
        private string connectionString = @"Data Source=DESKTOP-G1NBITB\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public bool checkUsernameUniqueness(userModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryUniqueness, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    int count = (int)cmd.ExecuteScalar();

                    return count == 0; 
                }
            }
        }

        public void registerUser(userModel user)
        {
            if (checkUsernameUniqueness(user))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(queryRegister, connection))
                    {
                        cmd.Parameters.AddWithValue("@userName", user.username);
                        cmd.Parameters.AddWithValue("@passwordHash", passwordEncryption.HashPassword(user));
                        cmd.Parameters.AddWithValue("@role", user.role);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User registered successfully");
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }

        public string loginUser(userLoginModel login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(queryRole, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", login.username);
                    userModel tempUser = new userModel { username = login.username, password = login.password };
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordEncryption.HashPassword(tempUser));

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void deleteUser(userSaveModel save)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(queryDelete, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", save.username);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }

            }
        }
        public DataTable userView()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryView, connection))
                {
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable("Users");
                    dataAdapter.Fill(dataTable);
                    return dataTable;

                }

            }
        }

        public void saveUser(userSaveModel save)
        {
            userModel user = new userModel { username = save.username, password = save.password, role = save.role };
            if (checkUsernameUniqueness(user))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(querySave, connection))
                    {
                        cmd.Parameters.AddWithValue("@userName", save.username);
                        cmd.Parameters.AddWithValue("@passwordHash", passwordEncryption.HashPassword(user));
                        cmd.Parameters.AddWithValue("@role", save.role);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User saved successfully");
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }

        public void updateUser(userUpdateModel update)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                {
                    userModel user = new userModel { username = update.username, password = update.password, role = update.role };

                    cmd.Parameters.AddWithValue("@UserID", update.userId);
                    cmd.Parameters.AddWithValue("@Username", update.username);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordEncryption.HashPassword(user));
                    cmd.Parameters.AddWithValue("@Role", update.role);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user. Please check the username.");
                    }
                }
            }
        }
        public void changePassword(userUpdateModel change)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(queryChangePassword, connection))
                {
                    userModel user = new userModel { username = change.username, password = change.password, role = change.role };

                    cmd.Parameters.AddWithValue("@UserID", change.userId);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordEncryption.HashPassword(user));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User password has changed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to change user password. Please check the userID.");
                    }
                }
            }
        }
        public userUpdateModel searchUser(int userID)
        {
            string querySearch = "SELECT Username, Role FROM Users WHERE UserID = @userID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(querySearch, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new userUpdateModel
                            {
                                username = reader["Username"].ToString(),
                                role = reader["Role"].ToString()
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

