using DotNetEnv;

namespace Quiz.Environments;

public static class EnvironmentsSettings
{
    static EnvironmentsSettings()
    {
        Env.Load();
    }

    public static string GetDatabaseSettings()
    {
        string host = GetEnvironmentVariableOrThrow("DB_HOST");
        string port = GetEnvironmentVariableOrThrow("DB_PORT");
        string database = GetEnvironmentVariableOrThrow("DB_NAME");
        string username = GetEnvironmentVariableOrThrow("DB_USERNAME");
        string password = GetEnvironmentVariableOrThrow("DB_PASSWORD");

        return $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    }

    private static string GetEnvironmentVariableOrThrow(string variableName)
    {
        var environmentValue = Environment.GetEnvironmentVariable(variableName);

        if (string.IsNullOrEmpty(environmentValue))
        {
            throw new ArgumentNullException(variableName, $"{variableName} environment variable is not set.");
        }

        return environmentValue;
    }
}
