using System.Reflection;

namespace Assignment12_2_2;

internal class Program
{
    static void Main()
    {
        // Keep the learning notes with this project, including when it is run elsewhere.
        using Stream stream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Assignment12_2_2.LearningNotes.txt")
            ?? throw new InvalidOperationException("The embedded learning notes are missing.");
        using StreamReader reader = new(stream);
        Console.WriteLine(reader.ReadToEnd());
    }
}
