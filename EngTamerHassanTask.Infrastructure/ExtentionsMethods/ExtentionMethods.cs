namespace EngTamerHassanTask.Infrastructure;

public static class ExtentionMethods
{
    public static void CheckIsNull<TEntity>(this TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
    }

    public static string GetExceptionErrorSimplified(this Exception exception)
    {
        string exceptionMessege =
            GetNewLineSeparator() +
            $"Exception Source: {exception.Source}\n\n" +
            $"Exception Stack Trace: {exception?.StackTrace}\n\n" +
            $"Exception Target Site Name: {exception?.TargetSite?.Name}\n\n" +
            $"Exception Message: {exception?.Message}\n\n" +
            $"Inner Exception Message: {exception?.InnerException?.Message ?? exception?.StackTrace}" +
            GetNewLineSeparator();

        return exceptionMessege;
    }

    public static string GetNewLineSeparator() =>
           "\n\n************************************************************************************************\n\n";
}