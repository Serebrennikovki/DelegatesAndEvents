
using DelegatesAndEvents;

class Program
{
    private static void Main(string[] args)
    {
        string[] arr = ["1","2","qweq","4"];

        var directory = "./";
        var readerDir = new DirectoryReader(directory);
        readerDir.FileFound += WriteFileNameToConsole;
        readerDir.Start();
        Console.WriteLine(arr.GetMax(ConvertToNumber));
        readerDir.FileFound -= WriteFileNameToConsole;
        Console.ReadLine();
    }

    private static float ConvertToNumber(string number)
    {
        float result = 0;
        float.TryParse(number, out result);
        return result;
    }

    public static void WriteFileNameToConsole(FileArgs args)
    {
        Console.WriteLine(args.NameFile);
    }
}