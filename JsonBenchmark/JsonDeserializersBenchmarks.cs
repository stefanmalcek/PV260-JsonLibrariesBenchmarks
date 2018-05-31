using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using LitJson;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_Deserialize_String()
        {
            return JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }

        [Benchmark]
        public Rootobject NewtonsoftJson_DeserializeAnotherJson_String()
        {
            return JsonConvert.DeserializeObject<Rootobject>(JsonAnotherSampleString);
        }

        [Benchmark]
        public Root NewtonsoftJson_Deserialize_File()
        {
            var data = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<Root>(data);
        }

        [Benchmark]
        public Root NewtonsoftJson_Deserialize_Stream()
        {
            using (var jsonFile = File.OpenText(FilePath))
            using (var jsonTextReader = new JsonTextReader(jsonFile))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Root>(jsonTextReader);
            }
        }

        [Benchmark]
        public Root ServiceStack_Deserialize_String()
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root LitJson_Deserialize_String()
        {
            return JsonMapper.ToObject<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root Utf8Json_Deserialize_String()
        {
            return Utf8Json.JsonSerializer.Deserialize<Root>(JsonSampleString);
        }
    }
}
