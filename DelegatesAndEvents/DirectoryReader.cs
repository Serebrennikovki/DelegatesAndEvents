namespace DelegatesAndEvents;

public class DirectoryReader
{
    private string DirectoryPath { get; init; }

    private bool Cancelation { get; set; } = false;
    
    public DirectoryReader(string path)
    {
        DirectoryPath = path;
    }

    public delegate void EventHandler(FileArgs args);
    
    public event EventHandler FileFound;

    public void Start()
    {
        Cancelation = false;
        var files = Directory.GetFiles(DirectoryPath);
        TimerCallback tc = new TimerCallback(Stop);
        Timer timer = new Timer(tc, 0, 0, 2000);
            foreach (var fileName in files)
            {
                do
                {
                FileFound.Invoke(new FileArgs{NameFile = fileName});
                Thread.Sleep(100);
                } while (!Cancelation);
            }
        
    }

    public void Stop(object obj)
    {
        Cancelation = true;
    }
    
}

public class FileArgs : EventArgs
{
    public string NameFile { get; set; }
}