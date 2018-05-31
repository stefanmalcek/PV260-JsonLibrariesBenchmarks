using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using LitJson;
using Newtonsoft.Json;
using JsonSerializer = ServiceStack.Text.JsonSerializer;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonSerializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public string NewtonsoftJson_Serialize()
        {
            return JsonConvert.SerializeObject(RootSampleObject);
        }

        [Benchmark]
        public string NewtonsoftJson_SerializeAnotherObject()
        {
            return JsonConvert.SerializeObject(AnotherRootSampleObject);
        }

        [Benchmark]
        public string ServiceStack_Serialize()
        {
            return JsonSerializer.SerializeToString(RootSampleObject);
        }

        [Benchmark]
        public string LitJson_Serialize()
        {
            return JsonMapper.ToJson(RootSampleObject);
        }

        [Benchmark]
        public string Utf8Json_Serialize()
        {
            return Utf8Json.JsonSerializer.ToJsonString(RootSampleObject);
        }
    }
}
