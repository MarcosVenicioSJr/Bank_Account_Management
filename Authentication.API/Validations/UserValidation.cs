namespace Authentication.API.Validations;

public static class UserValidation
{
    public static bool IsNull(object value)
    {
        if (value == null)
            return true;

        return false;
    }
}