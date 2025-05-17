using Dapper;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class NotificationDataAccess
    {
        public List<NotificationModel> GetAll()
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string query = @"SELECT * FROM bildirimler ORDER BY olusturma_zamani DESC";

                    // Dapper sorgusu
                    var notifications = connection.Query<NotificationModel>(query).ToList();
                    return notifications;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bildirim verisi çekme hatası: " + ex.Message);
                throw;
            }
        }

        public List<NotificationModel> GetLatest(int count)
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    // MySQL için
                    string query = @"SELECT id, sera_id, baslik, mesaj, tur, okundu, olusturma_zamani 
                             FROM bildirimler 
                             ORDER BY olusturma_zamani DESC 
                             LIMIT @Count";

                    var parameters = new { Count = count };
                    var notifications = connection.Query<NotificationModel>(query, parameters).ToList();
                    return notifications;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Son bildirimler çekilirken hata oluştu: " + ex.Message);
                throw;
            }
        }

        public List<NotificationModel> GetBySeraId(int seraId)
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string query = @"SELECT * FROM bildirimler WHERE sera_id = @SeraId ORDER BY olusturma_zamani DESC";

                    // Dapper sorgusu
                    var notifications = connection.Query<NotificationModel>(query, new { SeraId = seraId }).ToList();
                    return notifications;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bildirim verisi çekme hatası: " + ex.Message);
                throw;
            }
        }

        // NotificationDataAccess.cs içine eklenecek metotlar
        public void MarkAsRead(int notificationId)
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string query = "UPDATE bildirimler SET okundu = 1 WHERE id = @Id";
                    connection.Execute(query, new { Id = notificationId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bildirim okundu olarak işaretlenirken hata oluştu: {ex.Message}");
                throw;
            }
        }

        public void MarkAllAsRead()
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string query = "UPDATE bildirimler SET okundu = 1";
                    connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tüm bildirimler okundu olarak işaretlenirken hata oluştu: {ex.Message}");
                throw;
            }
        }
    }
}