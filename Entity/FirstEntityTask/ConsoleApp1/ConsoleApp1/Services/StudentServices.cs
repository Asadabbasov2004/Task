using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EntityFirstTask.Services
{
    internal class StudentServices
    {
        AppDbContext context;
        public StudentServices() {
            context = new AppDbContext();
        }
        public void Add(Student student)
        {
            if(student != null)
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Values are null");
            }
        }

        public void Remove(int id) {
            Student beforestudent = context.Students.FirstOrDefault(x => x.Id == id);
            if(beforestudent != null)
            {
                context.Remove(beforestudent);
                context.SaveChanges() ;
            }
            else
            {
                Console.WriteLine("id not found");
            }
        }
        public void GetAll()
        {
            List<Student> Students = context.Students.ToList();
            foreach (Student student in Students)
            {
                Console.WriteLine(student.Name +" "+student.Surname);
            }
        }
        public void Update(int id)
        {
            Student beforestudent = context.Students.FirstOrDefault(x=> x.Id == id );  
            if(beforestudent != null)
            {
                Console.WriteLine("please enter name");
                beforestudent.Name = Console.ReadLine();
                Console.WriteLine("please enter surname");
                beforestudent.Surname = Console.ReadLine();
                context.SaveChanges();
            }
        }
        public void Get(int id)
        {
            Student student = context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                Console.WriteLine("name is found");
            }
            else { Console.WriteLine("name not found"); }
        }
    }
}
