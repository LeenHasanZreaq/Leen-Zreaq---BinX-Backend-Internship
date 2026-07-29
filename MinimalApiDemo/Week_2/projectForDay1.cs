using System;
using System.Collections.Generic;

namespace Project
{
    class Project
    {
        public static void Main(string[] args)
        {

            // student
            Repository<Student> studentRepo = new Repository<Student>();

            studentRepo.Add(new Student { Name = "sara", Id = 1 });
            studentRepo.Add(new Student { Name = "ahmad", Id = 2 });


            Student s = studentRepo.Find(s => s.Name == "sara");
            Console.WriteLine("student : " + s?.Name);


            // employee
            Repository<Employee> employeeRepo = new Repository<Employee>();


            employeeRepo.Add(new Employee { Name = "Omar", Salary = 5000 });
            employeeRepo.Add(new Employee { Name = "Lina", Salary = 6000 });

            Employee highPaid = employeeRepo.Find(e => e.Salary > 5500);
            Console.WriteLine("employee: " + highPaid?.Name);
        }
    }

    public class Repository<T> where T : class
    {
        List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }

        public IReadOnlyList<T> GetAll()
        {
            return items;
        }

        public T Find(Func<T, bool> pre)
        {
            foreach (var item in items)
            {
                if (pre(item))
                {
                    return item;
                }
            }
            return null;
        }
    }

    public class Student
    {
        public string Name;
        public int Id;
    }

    public class Employee
    {
        public string Name;
        public double Salary;
    }
}