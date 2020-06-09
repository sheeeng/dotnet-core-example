using System.Globalization;
using System.Runtime.InteropServices;
using System;
using static System.Console;

public static class Program
{
    public static void Main(string[] args)
    {
        var defaultMessage = "Hello from .NET Core!";
        var message = args is object && args.Length > 0 ? string.Join(' ', args) : defaultMessage;

        WriteLine();
        WriteLine($"        {message}{GetBot()}");

        WriteLine("Environment:");
        WriteLine(RuntimeInformation.FrameworkDescription);
        WriteLine(RuntimeInformation.OSDescription);

        // An invariant culture is culture-insensitive.
        // Your application specifies the invariant culture by name using an empty string ("") or by its identifier.
        // https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-3.1#invariant-neutral-and-specific-cultures

        var veggieMessage = "Veggies es Lørenskog onion daikon bean garlic.";

        WriteLine(CultureInfo.CurrentCulture.TextInfo.ToString());
        WriteLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(veggieMessage));
        WriteLine(CultureInfo.CurrentCulture.TextInfo.ToUpper(veggieMessage));
        WriteLine(CultureInfo.CurrentCulture.TextInfo.ToLower(veggieMessage));

        TextInfo textInfo = new CultureInfo("nb-NO",false).TextInfo;
        WriteLine(textInfo.ToString());
        WriteLine(textInfo.ToTitleCase(veggieMessage));
        WriteLine(textInfo.ToUpper(veggieMessage));
        WriteLine(textInfo.ToLower(veggieMessage));

    }

    private static string GetBot()
    {
        return @"
        ---- Bot ----
        ";
    }
}
