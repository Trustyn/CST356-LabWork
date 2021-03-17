using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("student")]
public class Student
{
    [Column("student_id")]
    [Key]
    public long StudentId {get; set;}

    [Column("student_name")]
    public string StudentName{get; set;}

     [Column("student_email")]
    public string StudentEmail {get; set;}

     [Column("student_oit_id")]
    public long StudentOitId {get; set;}

}