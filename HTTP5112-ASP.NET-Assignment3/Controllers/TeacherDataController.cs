using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using HTTP5112Assignment3.Models;
using MySql.Data.MySqlClient;

namespace HTTP5112Assignment3.Controllers
{
    public class TeacherDataController : Controller
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext schoolDb = new SchoolDbContext();
        
        //This Controller Will access the teachers table of our blog database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeacher/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeacher(string SearchKey = null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = schoolDb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            //cmd.CommandText = "Select * from teachers";

            cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of teachers
            List<Teacher> Teachers = new List<Teacher>{};

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["TeacherId"];
                string TeacherFname = ResultSet["TeacherFname"].ToString();
                string TeacherLname = ResultSet["TeacherLname"].ToString();
                string EmployeeNumber = ResultSet["EmployeeNumber"].ToString();
                string HireDate = ResultSet["HireDate"].ToString();
                float Salary = Convert.ToSingle(ResultSet["Salary"]);


                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                //Add the teacher to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teacher names
            return Teachers;
        }


        /// <summary>
        /// Finds a teacher in the system given an ID
        /// </summary>
        /// <param name="id">The teacher primary key</param>
        /// <returns>A teacher object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = schoolDb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where TeacherId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["TeacherId"];
                string TeacherFname = ResultSet["TeacherFname"].ToString();
                string TeacherLname = ResultSet["TeacherLname"].ToString();
                string EmployeeNumber = ResultSet["EmployeeNumber"].ToString();
                string HireDate = ResultSet["HireDate"].ToString();
                float Salary = Convert.ToSingle(ResultSet["Salary"]);

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            return NewTeacher;
        }

        /// <summary>
        /// Returns a list of classes that the teacher specified by the input id teaches
        /// </summary>
        /// <param name="id">The input number that specifies the teacher by id</param>
        /// <returns>A list of classes that the teacher specified by the input id teaches</returns>
        [HttpGet]
        public List<Class> ListClasses(int id)
        {
            List<Class> Classes = new List<Class> { };

            //Create an instance of a connection
            MySqlConnection Conn = schoolDb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "SELECT classid, classcode, classes.teacherid, startdate, finishdate, classname FROM teachers JOIN classes on classes.teacherid = teachers.teacherid WHERE teachers.teacherid = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = (int)ResultSet["ClassId"];
                string ClassCode = ResultSet["ClassCode"].ToString().ToUpper();
                int TeacherId = Convert.ToInt32(ResultSet["TeacherId"]);
                string StartDate = ResultSet["StartDate"].ToString();
                string FinishDate = ResultSet["FinishDate"].ToString();
                string ClassName = ResultSet["ClassName"].ToString();

                Class NewClass = new Class();
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;

                Classes.Add(NewClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            return Classes;
        }

    }
}
