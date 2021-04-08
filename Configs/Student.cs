using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configs
{
    class Student
    {
        public string name;
        public string major;
        public double gpa;

        public Student(string aName, string aMajor, double aGPA)
        {
            name = aName;
            major = aMajor;
            gpa = aGPA;
        }

        public bool HasHonors()
        {
            if(gpa >= 3.5)
            {
                return true;
            }
            return false;
        }
    }
}
