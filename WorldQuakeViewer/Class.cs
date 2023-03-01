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
        public string PlaceJP { get; set; }
        public string PlaceEN { get; set; }
        public string LatLon { get; set; }
        public string Alert { get; set; }
        public string ID { get; set; }
        public string URL { get; set; }
        public double? MMI { get; set; }
        public double Depth { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public long Update { get; set; }
        public DateTime Time { get; set; }
    }
    public class History2
    {
        public string Text { get; set; }
        public string UpdateTime { get; set; }
        public long EQTime { get; set; }
        public long TweetID { get; set; }
        public int Display1LocX { get; set; }
        public int Display1LocY { get; set; }
        public string Display10 { get; set; }
        public string Display11 { get; set; }
        public string Display12 { get; set; }
        public string Display13 { get; set; }
        public string Display15 { get; set; }
        public string Display21 { get; set; }
        public string Display22 { get; set; }
        public string Display23 { get; set; }
    }
}