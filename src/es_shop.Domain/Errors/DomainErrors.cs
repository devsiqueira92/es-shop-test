using EsShop.Domain.Shared;

namespace EsShop.Domain.Errors;

public static class DomainErrors
{
    public static class Employee
    {
        public static readonly Error DateBirthInvalid = new(
            "DateBirth.Invalid",
            "Date of birth is invalid");
    }

    public static class Token
    {
        public static readonly Error InvalidToken = new(
            "Token.Invalid",
            "Token is invalid");

        public static readonly Error EmptyToken = new(
            "Token.Empty",
            "Token is empty");
    }

    public static class Upload
    {
        public static readonly Error InvalidImage = new(
            "Upload.Invalid",
            "Upload format is invalid.");
    }

    public static class Generic
    {
        public static readonly Error NotFound = new(
            "Generic.NotFound",
            "Resource not found.");

        public static readonly Error AlreadyExists = new(
            "Generic.AlreadyExists",
            "Resource already exists.");
    }

    public static class Workday
    {
        public static readonly Error InitialKmHigherThenEnd = new(
            "InitalKm.Invalid",
            "Initial KM is higher then End KM.");

        public static readonly Error WorkdayDone = new(
           "WorkDay.IsFinished",
           "This Workday is already finished.");
    }
}
