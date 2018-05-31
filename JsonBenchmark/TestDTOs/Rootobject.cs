namespace JsonBenchmark.TestDTOs
{
    public class Rootobject
    {
        public ResultData[] result { get; set; }
        public int status_code { get; set; }
    }

    public class ResultData
    {
        public int id { get; set; }
        public string name_cs { get; set; }
        public string name_en { get; set; }
        public string address { get; set; }
        public string link { get; set; }
        public int available_computers { get; set; }
        public int total_computers { get; set; }
        public Schedule schedule { get; set; }
        public string[] additional_services { get; set; }
        public string[] room_codes { get; set; }
    }

    public class Schedule
    {
        public Monday[] monday { get; set; }
        public Tuesday[] tuesday { get; set; }
        public Wednesday[] wednesday { get; set; }
        public Thursday[] thursday { get; set; }
        public Friday[] friday { get; set; }
        public Saturday[] saturday { get; set; }
        public Sunday[] sunday { get; set; }
    }

    public class Monday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Tuesday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Wednesday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Thursday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Friday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Saturday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Sunday
    {
        public string from { get; set; }
        public string to { get; set; }
    }

}