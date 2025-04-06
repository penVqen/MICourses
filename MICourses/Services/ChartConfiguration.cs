public class ChartConfiguration
{
    public string Type { get; set; }
    public ChartData Data { get; set; }
    public ChartOptions Options { get; set; }
}

public class ChartData
{
    public List<string> Labels { get; set; }
    public List<ChartDataset> Datasets { get; set; }
}

public class ChartDataset
{
    public string Label { get; set; }
    public List<double> Data { get; set; }
    public object BackgroundColor { get; set; }
    public string BorderColor { get; set; }
    public int BorderWidth { get; set; } = 1;
}

public class ChartOptions
{
    public bool Responsive { get; set; } = true;
    public object MaintainAspectRatio { get; set; } = false;
    public ChartTitle Title { get; set; }
}

public class ChartTitle
{
    public bool Display { get; set; }
    public string Text { get; set; }
}