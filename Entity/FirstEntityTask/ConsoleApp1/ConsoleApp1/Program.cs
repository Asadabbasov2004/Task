using EntityFirstTask.Services;
using System;
namespace EntityFirstTask;
    internal class Program
    {
        static void Main(string[] args)
        {
        GroupServices groupservices = new GroupServices();
        Group group1 = new Group();
        group1.Name = "A";
          groupservices.Add(group1);
        Group group2 = new Group()
        {
            Name = "B",
        };
        Group group3 = new Group()
        {
            Name = "C",
        };
        Group group4 = new Group()
        { Name = "D", };
        groupservices.Add(group2);
        groupservices.Add(group3);
        groupservices.Add(group4);
        groupservices.Remove(3);
        groupservices.GetAll();
        groupservices.Get(3);

        ///student
        ///
        StudentServices studentServices = new StudentServices();    
        Student student1 = new Student()
        {
            Name="Aa",
            Surname="bb",
          
        };
        Student student2 = new Student()
        {
            Name="B",
            Surname="B",
        };
        Student student3 = new Student()
        {
            Name = "Bc",
            Surname = "Bc",
        };

        studentServices.Add(student1);
        studentServices.Add(student2);
        studentServices.Add(student3);

        studentServices.Update(1);
    }
    }
