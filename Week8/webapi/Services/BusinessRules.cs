public static class BusinessRules
{
    public static bool SchoolEmailCheck(Student student) =>
        student.StudentEmail.ToLower().EndsWith(EmailType);

    public static bool OitIdLengthCheck(Student student) =>
        student.StudentOitId.ToString().Length == OitIdLength;

    public static int OitIdLength = 9;

    public static string EmailType = "@oit.edu";
}