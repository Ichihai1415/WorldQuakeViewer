using System;
using System.Collections.Generic;

namespace USGSQuakeClass
{
    public class Metadata
    {
        public long Generated { get; set; }
    }
    public class Properties
    {
        public double Mag { get; set; }
        public string Place { get; set; }
        public object Time { get; set; }
        public object Updated { get; set; }
        public string Url { get; set; }
        public string Alert { get; set; }
        public double? Mmi { get; set; }
        public string MagType { get; set; }
    }
    public class Geometry
    {
        public List<double> Coordinates { get; set; }
    }
    public class Feature
    {
        public Properties Properties { get; set; }
        public Geometry Geometry { get; set; }
        public string Id { get; set; }
    }
    public class USGSQuake
    {
        public Metadata Metadata { get; set; }
        public List<Feature> Features { get; set; }
    }
}
namespace WorldQuakeViewer
{
    public class History
    {
        public string Text { get; set; }
        public string UpdateTime { get; set; }
        public long EQTime { get; set; }
        public long TweetID { get; set; }
    }
}