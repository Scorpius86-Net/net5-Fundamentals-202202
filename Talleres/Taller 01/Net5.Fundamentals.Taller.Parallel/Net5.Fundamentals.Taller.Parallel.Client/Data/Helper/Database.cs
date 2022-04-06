﻿using Net5.Fundamentals.Taller.Parallel.Client.Data.Entities;
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

        public List<Badge> ListBadgesParallel()
        {
            Stopwatch stopwatchAll = new Stopwatch();
            stopwatchAll.Start();

            Console.WriteLine("ListBadges Start");

            List<Badge> badges = new List<Badge>();

            int taskCount = 30;
            Task<List<Badge>>[] tasks = new Task<List<Badge>>[taskCount];
            int minId = 82946;
            int maxId = 29392944;
            int blockSize = (maxId - minId) / taskCount;

            for (int i = 0; i < taskCount; i++)
            {
                int startRange = minId + (blockSize * i) + i;
                int endRange = minId + (blockSize * (i + 1)) + i;

                tasks[i] = Task.Factory.StartNew((stateTask) =>
                {

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    TaskParameter parameter = (TaskParameter)stateTask;
                    List<Badge> badgesBlock = new List<Badge>();
                                        
                    string strConn = "Data Source=.;Initial Catalog=StackOverflow2013;User ID=sa;Password=Password1234";
                    string query = @$"SELECT [Id],[Name],[UserId],[Date]FROM [StackOverflow2013].[dbo].[Badges] WHERE [Id] BETWEEN {parameter.StartRange} AND {parameter.EndRange};";

                    Console.WriteLine($"Task[{parameter.TaskId}] Start, query : {query}");

                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Badge badge = new Badge();
                                    badge.Id = reader.GetInt32(0);
                                    badge.Name = reader.GetString(1);
                                    badge.UserId = reader.GetInt32(2);
                                    badge.Date = reader.GetDateTime(3);

                                    badgesBlock.Add(badge);
                                }
                            }

                            reader.Close();
                            conn.Close();
                        }
                    }

                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Task[{parameter.TaskId}] End, elapsed time : {elapsedTime}, Count : {badgesBlock.Count()}");

                    return badgesBlock;
                },new TaskParameter { TaskId=i,StartRange = startRange,EndRange = endRange});

            }

            Task.WaitAll(tasks);

            tasks.ToList().ForEach(task =>
            {
                badges.AddRange(task.Result);
            });

            stopwatchAll.Stop();
            TimeSpan ts = stopwatchAll.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"ListBadgeParallel, elapsed time : {elapsedTime}");

            return badges;
        }
    }

    public class TaskParameter
    {
        public int TaskId { get; set; }
        public int StartRange { get; set; }
        public int EndRange { get; set; }
    }
}
