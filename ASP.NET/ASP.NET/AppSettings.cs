namespace ASP.NET;

public class AppSettings
{
    public string RandomApi { get; set; }
    public Settings Settings { get; set; }
}

public class Settings
{
    public List<string> BlackList { get; set; }
}