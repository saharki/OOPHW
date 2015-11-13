using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class RunPert
    {
        public static void Main(String[] args)
        {
            int n = 7;
            Pert p = new Pert(n);

            p.prerequisite(3, 1);
            p.prerequisite(3, 6);
            p.prerequisite(4, 6);
            p.prerequisite(4, 5);
            p.prerequisite(1, 2);
            p.prerequisite(5, 0);
            p.prerequisite(6, 2);

            p.printStages();

            n = 12;
            Courses c = new Courses(n);
            c.addCourse("Malam 61510");
            c.addCourse("Matam 61211");
            c.addCourse("Atam 61210");
            c.addCourse("Data Structures 61120");
            c.addCourse("OOP 61310");
            c.addCourse("Soft Eng 61101");
            c.addCourse("OS 61122");
            c.addCourse("OOP LANG 61313");
            c.addCourse("Real Time 61133");
            c.addCourse("Advanced Programming 61617");
            c.addCourse("Parallel Computing 61104");
            c.addCourse("Programming Languages 61110");
            c.prerequisite("Malam 61510", "Matam 61211");
            c.prerequisite("Malam 61510", "Atam 61210");
            c.prerequisite("Matam 61211", "Soft Eng 61101");
            c.prerequisite("Atam 61210", "Data Structures 61120");
            c.prerequisite("Matam 61211", "Data Structures 61120");
            c.prerequisite("OS 61122", "Parallel Computing 61104");
            c.prerequisite("OS 61122", "Real Time 61133");
            c.prerequisite("Data Structures 61120",
                                  "Programming Languages 61110");
            c.prerequisite("Atam 61210", "OS 61122");
            c.prerequisite("Data Structures 61120", "OS 61122");
            c.prerequisite("Matam 61211", "Programming Languages 61110");
            c.prerequisite("Matam 61211", "Advanced Programming 61617");
            c.prerequisite("Matam 61211", "OOP 61310");
            c.prerequisite("OOP 61310", "OOP LANG 61313");
            c.prerequisite("OOP 61310", "Soft Eng 61101");
            c.prerequisite("Data Structures 61120",
                                   "Advanced Programming 61617");

            c.printStages();


        } // main
    } // RunPert

}
