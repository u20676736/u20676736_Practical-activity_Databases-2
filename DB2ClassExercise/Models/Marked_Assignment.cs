using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB2ClassExercise.Models
{
    public class Marked_Assignment
    {
        public int ID { get; set; }
        public int _Course_ID { get; set; }
        public int _Marker_ID { get; set; }
        public int _Student_ID { get; set; }
        public string Course_ID { get; internal set; }
        public int Marker_ID { get; internal set; }
        public int Student_ID { get; internal set; }

        public Marked_Assignment(int id, int courseID, int Marker_ID, int Student_ID)
        {
            ID = id;
            _Course_ID = courseID;
            _Marker_ID = Marker_ID;
            _Student_ID = Student_ID;

        }

        public Marked_Assignment()
        {
        }
    }
}
