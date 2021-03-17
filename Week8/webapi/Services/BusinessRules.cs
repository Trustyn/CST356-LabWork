public static class BusinessRules
{
    //public static bool OitIdLengthCheck(Student student) => 
    //    student.StudentOitId < OitIdCount;

    public static bool SchoolEmailCheck(Student student) =>
        student.StudentName.ToLower().EndsWith(EmailType);

    //public static int OitIdCount = 9;

    public static string EmailType = "@oit.edu";
}