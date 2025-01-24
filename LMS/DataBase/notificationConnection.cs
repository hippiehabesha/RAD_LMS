﻿using Microsoft.Data.SqlClient;
using LMS.Model;
using System.Data;
using System.Windows;
using LMS.View.Notification;

namespace LMS.DataBase
{
    internal class notificationConnection
    {
        
        private string queryCreate = "INSERT INTO Notifications (UserID, Message, IsRead) VALUES (@UserID, @Message, 0)";
        private string queryFetch = "SELECT NotificationID, Message, IsRead FROM Notifications WHERE UserID = @UserID ORDER BY IsRead ASC, NotificationID DESC";
        private string queryMarkAsRead = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @NotificationID";
        private string queryDelete = "DELETE FROM Notifications WHERE NotificationID = @NotificationID";
        private string connectionString = @"Data Source=DESKTOP-G1NBITB\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

       
        public void CreateNotification(notificationModel add)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryCreate, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", add.UserID);
                    cmd.Parameters.AddWithValue("@Message", add.Message);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Notification created successfully.");
                }
            }
        }

        public DataTable FetchNotifications(notificationModel view)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryFetch, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", view.UserID);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable("Notifications");
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void MarkAsRead(int notificationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryMarkAsRead, connection))
                {
                    cmd.Parameters.AddWithValue("@NotificationID", notificationID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Notification marked as read.");
                    }
                    else
                    {
                        MessageBox.Show("Notification not found.");
                    }
                }
            }
        }

        // Delete a notification
        public void DeleteNotification(notificationModel delete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, connection))
                {
                    cmd.Parameters.AddWithValue("@NotificationID", delete.NotificationID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Notification deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Notification not found.");
                    }
                }
            }
        }
    }
}
