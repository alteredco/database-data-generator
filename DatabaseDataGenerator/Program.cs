using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static string CreateTables()
        {
            return @"
DROP TABLE IF EXISTS `mark`;
DROP TABLE IF EXISTS `module`;
DROP TABLE IF EXISTS `class`;
DROP TABLE IF EXISTS `subject`;
DROP TABLE IF EXISTS `teacher`;
DROP TABLE IF EXISTS `guardian`;
DROP TABLE IF EXISTS `student`;
DROP TABLE IF EXISTS `contact_details`;
DROP TABLE IF EXISTS `address`;

CREATE TABLE `address` (
    id int not null auto_increment,
    house varchar(128) not null,
    street varchar(128),
    city varchar(128),
    country varchar(128),
    postcode varchar(8) not null
);

CREATE TABLE `student` (
    id int not null auto_increment,
    first_name varchar(128) not null,
    last_name varchar(128) not null,
    phone_number varchar(32),
    email varchar(128),
    address_id int not null,
    FOREIGN KEY (address_id) REFERENCES address(id)
);

CREATE TABLE `guardian` (
    id int not null auto_increment,
    student_id int not null,
    first_name varchar(128) not null,
    last_name varchar(128) not null,
    phone_number varchar(32),
    email varchar(128),
    address_id int not null,
    FOREIGN KEY (address_id) REFERENCES address(id)
);

CREATE TABLE `teacher` (
    id int not null auto_increment,
    first_name varchar(128) not null,
    last_name varchar(128) not null,
    phone_number varchar(32),
    email varchar(128),
    address_id int not null,
    FOREIGN KEY (address_id) REFERENCES address(id)
);

CREATE TABLE `subject` (
    id int not null auto_increment,
    name varchar(128)
);

CREATE TABLE `class` (
    id int not null auto_increment,
    student_id int not null,
    subject_id int not null,
    teacher_id int not null,
    FOREIGN KEY (student_id) REFERENCES student(id),
    FOREIGN KEY (subject_id) REFERENCES subject(id),
    FOREIGN KEY (teacher_id) REFERENCES teacher(id)
);

CREATE TABLE `module` (
    id int not null auto_increment,
    name varchar(128),
    subject_id int not null,
    FOREIGN KEY (subject_id) REFERENCES subject(id)
);

CREATE TABLE `mark` (
    id int not null auto_increment,
    student_id int not null,
    module_id int not null,
    score varchar not null,
    FOREIGN KEY (student_id) REFERENCES student(id),
    FOREIGN KEY (module_id) REFERENCES module(id)
);
";
        }
        
        private static readonly string[] Subjects = new[]
        {
            "Art", "Geography", "History", "English", "Maths", "Physics", "Chemistry", "Biology", "French", "German"
        };
        
        private static string CreateAddresses()
        {
            var output = "\nINSERT INTO `address` (house, street, city, country, postcode) VALUES\n";
            var random = new Random();
            
            for (var i = 0; i < 1000; i++)
            {
                output += $"(\"{random.Next(100)}\", \"{AddressGenerator.GetRandomStreetName()}\", \"London\", \"UK\", \"{AddressGenerator.GetRandomPostcode()}\"),\n";
            }
            
            return output;
        }

        private static string CreateStudents()
        {
            var output = "\nINSERT INTO `student` (first_name, last_name, phone_number, email, address_id) VALUES\n";
            var random = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var firstName = NameGenerator.GetRandomFirstName();
                var lastName = NameGenerator.GetRandomLastName();
                output += $"(\"{firstName}\", \"{lastName}\", null, \"{firstName}.{lastName}@school.ac.uk\", {random.Next(1, 1001)}),\n";
            }
            return output;
        }

        private static string CreateGuardians()
        {
            var output = "\nINSERT INTO `guardian` (student_id, first_name, last_name, phone_number, email, address_id) VALUES\n";
            var random = new Random();
            for (var i = 0; i < 1500; i++)
            {
                var firstName = NameGenerator.GetRandomFirstName();
                var lastName = NameGenerator.GetRandomLastName();
                output += $"({random.Next(1000)}, \"{firstName}\", \"{lastName}\", null, \"{firstName}.{lastName}@gmail.com\", {random.Next(1, 1001)}),\n";
            }
            return output;
        }

        private static string CreateSubjects()
        {
            var values = Subjects.Select(s => $"(\"{s}\")");
            return $"\nINSERT INTO `subject` (name) VALUES {string.Join(",\n", values)};\n";
        }
        
        private static string CreateTeachers()
        {
            var output = "\nINSERT INTO `teacher` (first_name, last_name, phone_number, email, address_id) VALUES\n";
            var random = new Random();
            for (var i = 0; i < 50; i++)
            {
                var firstName = NameGenerator.GetRandomFirstName();
                var lastName = NameGenerator.GetRandomLastName();
                output += $"(\"{firstName}\", \"{lastName}\", null, \"{firstName}.{lastName}@school.ac.uk\", {random.Next(1, 1001)}),\n";
            }
            return output;
        }
        
        private static string CreateClasses()
        {
            var output = "\nINSERT INTO `class` (student_id, subject_id, teacher_id) VALUES\n";
            var random = new Random();
            for (var i = 0; i < 50; i++)
            {
                output += $"({random.Next(1000)}, {random.Next(Subjects.Length) + 1}, {random.Next(50)}),\n";
            }
            return output;
        }
        
        private static string CreateModules()
        {
            var output = "\nINSERT INTO `module` (name, subject_id) VALUES\n";
            for (var subjectIndex = 0; subjectIndex < Subjects.Length; subjectIndex++)
            {
                for (var i = 0; i < 10; i++)
                {
                    output += $"(\"{Subjects[subjectIndex]} {i+1}\", {subjectIndex + 1}),\n";
                }
            }
            return output;
        }
        
        private static string CreateMarks()
        {
            var output = "\nINSERT INTO `class` (student_id, subject_id, teacher_id) VALUES\n";
            var random = new Random();
            for (var i = 0; i < 50; i++)
            {
                output += $"({random.Next(1000)}, {random.Next(Subjects.Length) + 1}, {random.Next(50)}),\n";
            }
            return output;
        }
        
        public static void Main(string[] args)
        {
            var output = CreateTables();
            output += CreateAddresses();
            output += CreateStudents();
            output += CreateGuardians();
            output += CreateSubjects();
            output += CreateTeachers();
            output += CreateClasses();
            output += CreateModules();
            output += CreateMarks();

            System.IO.File.WriteAllText("output.sql", output);
        }
    }
}