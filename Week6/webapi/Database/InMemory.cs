using System.Collections.Generic;

namespace Database
{
    public static class InMemory
    {
        public static List<Student> Students = new List<Student> {
            new Student {
                Id = 1,
                FirstName = "Tom",
                LastName = "Jones"
            },
            new Student {
                Id = 2,
                FirstName = "Mary",
                LastName = "Smith"
            }
        };
        public static List<Instructor> Instructors = new List<Instructor> {
            new Instructor {
                Id = 1,
                FirstName = "Terry",
                LastName = "Cruz",
                Email = "terry.cruz@oit.edu"
            },
            new Instructor {
                Id = 2,
                FirstName = "Marrie",
                LastName = "Jane",
                Email = "marrie.jane@oit.edu"
            }
        };
    }
}