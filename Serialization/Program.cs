using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>();
            var students = new List<Student>();
            for (int i = 1; i < 10; i++)
            {
                groups.Add(new Group(i, "Группа " + i));
            }
            for (int i = 0; i < 300; i++)
            {
                var student = new Student(Guid.NewGuid().ToString().Substring(0, 5), i % 100)
                {
                    Group = groups[i % 9]
                };
                students.Add(student);

            }

            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, groups);
            }
            using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            {
                var newGroups = binFormatter.Deserialize(file) as List<Group>;
                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            Console.ReadLine();

            //SOAP
            var soapFormatter = new SoapFormatter();
            using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, groups.ToArray());
            }
            using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            {
                var newGroups = soapFormatter.Deserialize(file) as Group[];
                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.ReadLine();

            var xmlFormatter = new XmlSerializer(typeof(List<Group>));
            using (var file = new FileStream("groups.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, groups);
            }
            using (var file = new FileStream("groups.xml", FileMode.OpenOrCreate))
            {
                var newGroups = xmlFormatter.Deserialize(file) as List<Group>;
                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            Console.ReadLine();

            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));

            using (var file = new FileStream("students.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(file, students);
            }
            using (var file = new FileStream("students.json", FileMode.OpenOrCreate))
            {
                var newStudents = jsonFormatter.ReadObject(file) as List<Student>;
                if (newStudents != null)
                {
                    foreach (var student in newStudents)
                    {
                        Console.WriteLine(student);
                    }
                }
            }
            Console.ReadLine();

        }

    }


}