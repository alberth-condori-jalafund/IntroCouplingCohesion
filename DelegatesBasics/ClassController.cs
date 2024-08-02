namespace DelegatesBasics;

using System.Collections.Generic;

public class ClassController
{
    private readonly ClassService _classService;

    public ClassController()
    {
        _classService = new();
    }

    public List<Student> GetAllStudents(Token userToken)
    {
        return _classService.GetAllStudents(userToken);
    }
}
