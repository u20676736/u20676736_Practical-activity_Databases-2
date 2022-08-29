using System;
using System.Collections.Generic;
using DB2ClassExercise.Models;
using System.Data.SqlClient;

namespace DB2ClassExercise.Data
{
    public class SomeDataService
    {

        private static SomeDataService instance;
        public String connectionString;
        private SqlConnection sqlConnection;
        private object ConfigurationManager;

        public static SomeDataService getInstance()
        {
            if (instance == null)
            {
                instance = new SomeDataService();
            }
            return instance;
        }

        public void setConnectionString(String someConnStr)
        {
            connectionString = someConnStr;
        }

        public List<Course> getAvailableCourses()
        {
            List<Course> data = new List<Course>();
            //TODO: Complete this
            try
            {
                sqlConnection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("select * from Courses", sqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Course datas = new Course();
                        datas.ID = Convert.ToInt32(reader["id"]);
                        datas.Name = reader["Name"].ToString();
                        datas.Description = reader["Description"].ToString();

                        data.Add(datas);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            return data;
        }

        //TODO: Uncommment and complete this


        public List<Marked_Assignment> getAssignmentsOfCourse(int courseID, int Marker_ID, int Student_ID)
        {
            List<Marked_Assignment> assignments = new List<Marked_Assignment>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-8UDALSA\\SQLEXPRESS;Initial Catalog=DB2;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("Select Courses.ID, Courses.Name, Courses.Description from Courses" +
                    " CourseAssignmentsMarking.ID, CourseAssignmentsMarking.CourseID, CourseAssignmentsMarking.MarkerID, CourseAssignmentsMarking.StudentID" +
                    " inner join Staff on CourseAssignmentsMarking.MarkerID = Staff.ID " +
                    " where Courses.ID =" + courseID, sqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Marked_Assignment marked = new Marked_Assignment();
                        marked.ID = Convert.ToInt32(reader["ID"]);
                        marked.Course_ID = (reader["Name"]).ToString();
                        marked.Marker_ID = Convert.ToInt32(reader["CoursesDescription"]);
                        marked.Student_ID = Convert.ToInt32(reader["Staff"]);
                        assignments.Add(marked);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            return assignments;
        }
    }
}
    

    

