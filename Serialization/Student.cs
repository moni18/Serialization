using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace Lesson1
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        public Group Group { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
