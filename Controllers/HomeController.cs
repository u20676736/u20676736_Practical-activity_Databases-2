using DB2ClassExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using DB2ClassExercise.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System;

namespace DB2ClassExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SomeDataService dataService = SomeDataService.getInstance();
        private static SomeDataService instance;        
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-8UDALSA\\SQLEXPRESS;Initial Catalog=DB2;Integrated Security=True");


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Course> courses = dataService.getAvailableCourses();

            return View(courses);
        }

        public ActionResult ViewCourse(int courseID, int Marker_ID, int Student_ID)
        {
            List<Marked_Assignment> courseAssignmnts = dataService.getAssignmentsOfCourse(courseID, Marker_ID, Student_ID);
            Marked_Assignment marked = new Marked_Assignment();
            try
            {
                SqlCommand command = new SqlCommand("select * from Courses", sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        marked.ID = Convert.ToInt32(reader["ID"]);
                        marked.Course_ID = (reader["Name"]).ToString();
                        marked.Marker_ID = Convert.ToInt32(reader["CoursesDescription"]);
                        marked.Student_ID = Convert.ToInt32(reader["Staff"]);
                        marked.Add(reader["Courses"]);
                    }
                }
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }

            finally
            {
                sqlConnection.Close();
            }
            return View(marked);

        }


    } 
}
    
            

    

