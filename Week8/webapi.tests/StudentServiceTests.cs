using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FakeItEasy;
using FluentAssertions;

public class StudentServiceTests
{
    private StudentService _studentService; // System Under Test (SUT)
    private IStudentRepository _studentRepository; // Mock
    public static int OitIdLength = 9;
    public static string EmailType = "@oit.edu";

    [SetUp]
    public void Setup()
    {
        _studentRepository = A.Fake<IStudentRepository>();

        _studentService = new StudentService(_studentRepository);
    }

    [Test]
    public void ShouldReturnStudentsHaveProperEmail()
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

        // Assert (FluentAssertions) (Then)
        studentViewModels.Count(pdto => pdto.EmailType).Should().Be(2);
    }

    [Test]
    public void ShouldReturnStudentHasBadEmail()
    {
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
        studentViewModels[1].EmailType.Should().BeTrue();
    }

        [Test]
    public void ShouldReturnStudentsHaveProperOitId()
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

        // Assert (FluentAssertions) (Then)
        studentViewModels.Count(pdto => pdto.OitIdLength).Should().Be(2);
    }

    [Test]
    public void ShouldReturnStudentHasBadOitId()
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
                    StudentOitId = 9187891
                },
            }
        );

        // Act (When)
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (FluentAssertions)
        studentViewModels.Count(pdto => pdto.OitIdLength).Should().Be(1);
        studentViewModels[1].OitIdLength.Should().BeFalse();
    }
}