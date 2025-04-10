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
    public object BorderColor { get; set; }
    public int BorderWidth { get; set; } = 1;
}

public class ChartOptions
{
    public bool Responsive { get; set; } = true;
    public object MaintainAspectRatio { get; set; } = false;
    public ChartPlugins Plugins { get; set; }
    public ChartScales Scales { get; set; }
}

public class ChartPlugins
{
    public ChartLegend Legend { get; set; }
}

public class ChartLegend
{
    public bool Display { get; set; }
    public string Position { get; set; }
}

public class ChartScales
{
    public ChartScale Y { get; set; }
    public ChartScale X { get; set; }
}

public class ChartScale
{
    public bool BeginAtZero { get; set; } = false;
}
