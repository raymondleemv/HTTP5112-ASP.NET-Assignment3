using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using HTTP5112Assignment3.Models;
//using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;

namespace HTTP5112Assignment3.Controllers
{
    public class ClassDataController : Controller
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext schoolDb = new SchoolDbContext();
        
        //This Controller Will access the classes table of our blog database.
        /// <summary>
        /// Returns a list of Authors in the system
        /// </summary>
        /// <example>GET api/ClassData/ListClass</example>
        /// <returns>
        /// A list of classes (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Class> ListClass()
        {
            //Create an instance of a connection
            MySqlConnection Conn = schoolDb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Class> Classes = new List<Class> {};

            //Loop Through Each Row the Result Set
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

                //Add the Author Name to the List
                Classes.Add(NewClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Classes;
        }


        /// <summary>
        /// Finds a class in the system given an ID
        /// </summary>
        /// <param name="id">The class primary key</param>
        /// <returns>A class object</returns>
        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();

            //Create an instance of a connection
            MySqlConnection Conn = schoolDb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where ClassId = @id";
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

                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            return NewClass;
        }
    }
}
