using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class MyClass
    {
        public string name;
        public string id; 
        public string email;  

    }
    public class MyResult
    {
        public string degree;
        public ushort year;
        public string institution;

    }

    public class PersonalDetails 
    {
        public string name;
        public string age;
        public string email;
        public string phone;
        public string position;
    }
    public class Project 
    {
        public string ProjectName;
        public string ProjectDetails;
    }

    public class Referance
    {
        public string name;
        public string email;
        public string contact;
    }
}