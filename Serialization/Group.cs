using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lesson1
{
    [Serializable]
    public class Group
    {
        [NonSerialized]
        private Random rnd = new Random(DateTime.Now.Millisecond);
        public int Number { get; set; }
        public string Name { get; set; }
        public Group()
        {
            Number = rnd.Next(1, 10);
            Name = "Группа " + rnd;
        }
        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
