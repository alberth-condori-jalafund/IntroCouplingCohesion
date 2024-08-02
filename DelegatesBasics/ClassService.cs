namespace DelegatesBasics;

using System.Collections.Generic;

public class ClassService
{
    public readonly Func<Token, StudentsRepository> _studentsRepository;

    public ClassService()
    {
        _studentsRepository = token => new StudentsRepository(token);
        // varios repositories...
    }

    public List<Student> GetAllStudents(Token userToken)
    {
        return _studentsRepository(userToken).SelectStudents();
    }

    // Tenemos otro metodos para obtener planillas, estadisticas del teacher
}
