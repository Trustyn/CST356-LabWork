using System.Collections.Generic;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRespository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRespository = studentRepository;
    }

    public List<StudentModel> GetAllStudents()
    {
        var studentViewModels = new List<StudentModel>();

        foreach(var student in _studentRespository.GetAllStudents())
        {
            studentViewModels.Add(new StudentModel {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                StudentEmail = student.StudentEmail,
                StudentOitId = student.StudentOitId,
                EmailType = BusinessRules.SchoolEmailCheck(student),
                OitIdLength = BusinessRules.OitIdLengthCheck(student)
            });
        }

        return studentViewModels;
    }

    public StudentModel GetStudentById(long studentId)
    {
        var student = _studentRespository.GetStudentById(studentId);

        return new StudentModel {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                StudentEmail = student.StudentEmail,
                StudentOitId = student.StudentOitId,
                EmailType = BusinessRules.SchoolEmailCheck(student),
                OitIdLength = BusinessRules.OitIdLengthCheck(student)
        };
    }
}