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
        public long Time { get; set; }
        public long Updated { get; set; }
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
        public string URL { get; set; }
        public long Update { get; set; }
        public long TweetID { get; set; }

        //以下表示用
        public string Display21 { get; set; }
        public string Display22 { get; set; }
        public string Display23 { get; set; }

        //以下更新検知用
        public long Time { get; set; }
        public string HypoJP { get; set; }
        public string HypoEN { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Depth { get; set; }
        public string MagType { get; set; }
        public string Mag { get; set; }
        public double? MMI { get; set; }
        public string Alert { get; set; }
    }
}