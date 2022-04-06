using Net5.Fundamentals.Taller.Parallel.Client.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.Taller.Parallel.Client.Data.Helper
{
    public class Database
    {
        public List<Badge> ListBadges()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("ListBadges Start");

            List<Badge> badges = new List<Badge>();

            string strConn = "Data Source=.;Initial Catalog=StackOverflow2013;User ID=sa;Password=Password1234";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = @"
                    SELECT 
                        [Id],
                        [Name],
                        [UserId],
                        [Date]
                    FROM [StackOverflow2013].[dbo].[Badges]
                    ORDER BY [Id]
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader =  cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Badge badge = new Badge();
                            badge.Id = reader.GetInt32(0);
                            badge.Name = reader.GetString(1);
                            badge.UserId = reader.GetInt32(2);
                            badge.Date = reader.GetDateTime(3);

                            badges.Add(badge);
                        }
                    }

                    reader.Close();
                    conn.Close();
                }

                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine($"ListBadges, elapsed time : {elapsedTime}");

                return badges;
            }
        }
    }
}
