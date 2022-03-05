using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegisterProject
{

    class DotNetClass
    {
        public DotNetClass(Student[] students)
        {
            ClassSize = students.Length;
            Students = students;
            
        }

        public int ClassSize { get; }
        public Student[] Students { get; }

        public void PrintClassDetails()
        {
            foreach (Student dev in Students)
            {
                Console.Write(dev.ToString());
            }
        }
    }







}
