using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models.CallingStoredProcedures
{
    public class ProjectsbyDate
    {
        string connectionString;

     

        //в конструкторе класса инициализируем наш Connection String для связи с Базой Данных
        public ProjectsbyDate(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }
        //Метод в котором описан вызов хранимой процедуры и получения данных от хранимой процедуры
        public List<Project> Get_Project(DateTime start, DateTime finish)
        {
            //string connectionString = ConnectionString.CName;
            List<Project> Project_list = new List<Project>();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Get_Project", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@begindate", start);
                cmd.Parameters.AddWithValue("@finishdate", finish);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Project project = new Project();
                    project.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                    project.Name = (rdr["Name"]).ToString();
                    project.Customer = (rdr["Customer"]).ToString();
                    project.Executor = (rdr["Executor"]).ToString();
                    //project.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    project.EmployeeName = (rdr["EmployeeName"]).ToString();
                    project.beginDate = Convert.ToDateTime(rdr["beginDate"]);
                    project.finishDate = Convert.ToDateTime(rdr["finishDate"]);
                    project.Priority = Convert.ToInt32(rdr["Priority"]);                   
                    Project_list.Add(project);
                }
            }
            return Project_list;
        }
        //Метод для вызова хранимой процедуру для вывода всей таблицы Project
        public IEnumerable<Project> GetAllData()
        {
            //string connectionString = ConnectionString.CName;
            List<Project> Project_list = new List<Project>();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Get_All", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Project project = new Project();
                    project.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                    project.Name = (rdr["Name"]).ToString();
                    project.Customer = (rdr["Customer"]).ToString();
                    project.Executor = (rdr["Executor"]).ToString();
                    //project.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    project.EmployeeName = (rdr["EmployeeName"]).ToString();
                    project.beginDate = Convert.ToDateTime(rdr["beginDate"]);
                    project.finishDate = Convert.ToDateTime(rdr["finishDate"]);
                    project.Priority = Convert.ToInt32(rdr["Priority"]);
                    Project_list.Add(project);
                }
            }
            return Project_list;
        }

    }
}
