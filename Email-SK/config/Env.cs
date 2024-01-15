using Microsoft.Extensions.Configuration;

internal sealed class Env
{
    //<summary>

    //</summary>

    internal static string? Var(string name)
    {
        var configuration = new ConfigurationBuilder().Build();

        var value = configuration[name];
        if (!string.IsNullOrEmpty(value))
        {
            return value;
        }
        value = Environment.GetEnvironmentVariable(name);
        return value;
    }
}