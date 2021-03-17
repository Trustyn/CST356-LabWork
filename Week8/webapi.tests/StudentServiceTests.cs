using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FakeItEasy;
using FluentAssertions;

public class StudentServiceTests
{
    private StudentService _studentService; // System Under Test (SUT)
    private IStudentRepository _studentRepository; // Mock
    //public static int OitIdCount = 9;
    public static string EmailType = "@oit.edu";

    [SetUp]
    public void Setup()
    {
        _studentRepository = A.Fake<IStudentRepository>();

        _studentService = new StudentService(_studentRepository);
    }

    [Test]
    public void ShouldNotReturnStudentsWithBadEmail()
    {
        // Arrange (Given)
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    StudentId = 1,
                    StudentName = "Todd Healy",
                    StudentEmail = "todd.healy@oit.edu",
                    StudentOitId = 918456123
                },
                new Student {
                    StudentId = 2,
                    StudentName = "Ben Blake",
                    StudentEmail = "ben.blake@oit.edu",
                    StudentOitId = 918789123
                },
            }
        );

        // Act (When)
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (NUnit Assertions) (Then)
        Assert.That(studentViewModels.Any(pdto => pdto.EmailType), Is.EqualTo(false));

        // Assert (FluentAssertions) (Then)
        studentViewModels.Any(pdto => pdto.EmailType).Should().BeFalse();
    }

    [Test]
    public void ShouldReturnStudentsWithBadEmail()
    {
        //var expectedEmailType = "@oit.edu";

        // Arrange (Given)
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    StudentId = 1,
                    StudentName = "Todd Healy",
                    StudentEmail = "todd.healy@gmail.com",
                    StudentOitId = 918456123
                },
                new Student {
                    StudentId = 2,
                    StudentName = "Ben Blake",
                    StudentEmail = "ben.blake@oit.edu",
                    StudentOitId = 918789123
                },
            }
        );

        // Act (When)
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (FluentAssertions)
        studentViewModels.Count(pdto => pdto.EmailType).Should().Be(1);
        //studentViewModels.Single(pdto => pdto.EmailType).StudentEmail.Should().Be(expectedEmailType);
        studentViewModels[1].EmailType.Should().BeTrue();
    }

}