using System.Collections.Generic;

namespace MICourses.Models
{
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
        public bool MaintainAspectRatio { get; set; } = false;
        public ChartPlugins Plugins { get; set; }
        public ChartScales Scales { get; set; }
        public string Cutout { get; set; }
    }

    public class ChartPlugins
    {
        public ChartLegend Legend { get; set; }
        public ChartTooltip Tooltip { get; set; }
    }

    public class ChartLegend
    {
        public bool Display { get; set; }
        public string Position { get; set; }
    }

    public class ChartTooltip
    {
        public bool Enabled { get; set; }
        public ChartTooltipCallbacks Callbacks { get; set; }
    }

    public class ChartTooltipCallbacks
    {
        public string Label { get; set; }
    }

    public class ChartScales
    {
        public ChartScale X { get; set; }
        public ChartScale Y { get; set; }
    }

    public class ChartScale
    {
        public bool BeginAtZero { get; set; }
        public ChartGridLines GridLines { get; set; }
    }

    public class ChartGridLines
    {
        public string Color { get; set; }
    }
}