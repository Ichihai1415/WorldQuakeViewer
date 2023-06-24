namespace WorldQuakeViewer
{
    public class History
    {
        public string URL { get; set; }
        public long Update { get; set; }
        public long TweetID { get; set; }

        //表示用
        public string Display1 { get; set; }
        public string Display2 { get; set; }
        public string Display3 { get; set; }

        //更新検知用
        public long Time { get; set; }
        public string HypoJP { get; set; }
        public string HypoEN { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Depth { get; set; }
        public string MagType { get; set; }
        public double Mag { get; set; }
        public double? MMI { get; set; }
        public string Alert { get; set; }
    }
}