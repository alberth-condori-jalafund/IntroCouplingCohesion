namespace DelegatesBasics;

using System;
using System.Collections.Generic;

public class Student
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }
}

public class Token
{
    public string UserToken { get; set; }
}

public class StudentsRepository
{
    public StudentsRepository(Token userToken)
    {
    }

    public List<Student> SelectStudents()
    {
        return new List<Student>(); 
    }
}
