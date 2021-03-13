using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("student")]
public class Student
{
    [Column("student_id")]
    [Key]
    public long StudentID {get; set;}

    [Column("email_address")]
    public string Email {get; set;}

}