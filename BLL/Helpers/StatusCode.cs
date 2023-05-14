namespace BLL.Helpers
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,
        
        CompanyNotFound = 10,

        EmployeeNotFound = 20,

        OK = 200,
        InternalServerError = 500
    }
}