namespace Mix;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }
}

public class Indexer
{
    private readonly List<Student> _students;

    public Indexer()
    {
        _students = [];
    }

    public Student this[int index]
    {
        get
        {
            return _students[index];
        }
        set
        {
            _students[index] = value;
        }
    }

    public Student this[string lastname]
    {
        get
        {
            var student = _students.Find(x => x.LastName == lastname);

            return student;
        }
        set
        {
            var student = _students.FirstOrDefault(x => x.LastName == lastname);

            if (student is null)
            {
                _students.Add(student);
            }
            else
            {
                _students.Remove(student);
                _students.Add(value);
            }
        }
    }

    public Student this[Guid id]
    {
        get
        {
            var student = _students.Find(x => x.Id == id);

            return student;
        }
        set
        {
            var student = _students.FirstOrDefault(x => x.Id == id);

            if (student is null)
            {
                _students.Add(student);
            }
            else
            {
                _students.Remove(student);
                _students.Add(value);
            }
        }
    }
}
