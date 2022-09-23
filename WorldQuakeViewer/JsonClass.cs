using System;
using System.Collections.Generic;

namespace USGSQuakeClass
{
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
        public List<Feature> Features { get; set; }
    }
}
namespace USGSFERegionsClass
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Metadata
    {
        public string Request { get; set; }
        public DateTime Submitted { get; set; }
        public List<string> Types { get; set; }
        public string Version { get; set; }
    }

    public class Properties
    {
        public int? Number { get; set; }
        public string Name { get; set; }
    }

    public class Feature
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public object Geometry { get; set; }
        public Properties Properties { get; set; }
    }

    public class Fe
    {
        public string Type { get; set; }
        public int Count { get; set; }
        public List<Feature> Features { get; set; }
    }

    public class USGSFERegions
    {
        public Metadata Metadata { get; set; }
        public Fe Fe { get; set; }
    }
}
namespace USGSFERegionsClass2
{
    public class Properties
    {
        public string Name { get; set; }
    }
    public class Feature
    {
        public Properties Properties { get; set; }
    }
    public class Fe
    {
        public List<Feature> Features { get; set; }
    }
    public class USGSFERegions2
    {
        public Fe Fe { get; set; }
    }

}
namespace WorldQuakeViewer
{
    public class Tokens_JSON
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
    }
}