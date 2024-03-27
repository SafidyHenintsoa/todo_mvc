using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Todo_MVC.Models
{
    public static class DBConnect
    {
        public static NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public static long Login(User user)
        {
            long id;

            try
            {
                string query = $"SELECT id FROM public.\"User\" WHERE username='{user.Username}' AND password='{user.Password}'";
                connection.Open();
                var command = new NpgsqlCommand(query,connection);
                id = long.Parse(command.ExecuteScalar() == null? "-1" : command.ExecuteScalar().ToString());
                connection.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
            return id;
        }

        public static void AddUser(User user)
        {
            var req = $"INSERT INTO public.\"User\"(username, password)VALUES ('{user.Username}', '{user.Password}')";
            try
            {
                connection.Open();
                var cmd = new NpgsqlCommand(req,connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }catch (Exception e)
            {
                throw e;
            }
        }

        public static void AddTask(Tasks tasks,long user_id)
        {
            var req = $"INSERT INTO public.\"Tasks\"(name, user_id, completed)VALUES ('{tasks.Name}', '{user_id}', '{tasks.Completed}')";
            try
            {
                connection.Open();
                var cmd = new NpgsqlCommand(req,connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeleteTask(long task_id)
        {
            var req = $"DELETE FROM public.\"Tasks\" WHERE id={task_id}";
            try
            {
                connection.Open();
                var cmd = new NpgsqlCommand(req, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void UpdateTask(long id,string name)
        {
            var req = $"UPDATE public.\"Tasks\" SET name='{name}'WHERE id={id}";
            try
            {
                connection.Open();
                var cmd = new NpgsqlCommand(req, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ToggleTask(long id, bool completed)
        {
            var req = $"UPDATE public.\"Tasks\" SET completed={!completed} WHERE id={id}";
            try
            {
                connection.Open();
                var cmd = new NpgsqlCommand(req, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Tasks> GetAllTask(long id)
        {
            List<Tasks> list = new List<Tasks>();

            var req = $"SELECT id,name,completed FROM public.\"Tasks\" WHERE user_id={id} ORDER BY name";

            try
            {
                connection.Open();
                var commad = new NpgsqlCommand(req, connection);
                var reader = commad.ExecuteReader();
                while (reader.Read())
                {
                    Tasks tasks = new Tasks(reader.GetInt64(0),reader.GetString(1),reader.GetBoolean(2));
                    list.Add(tasks);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }
    }
}