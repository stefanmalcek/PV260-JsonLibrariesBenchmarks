using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using ChoETL;
using JsonBenchmark.TestDTOs;
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
        public Root ChoETL_Deserialize_File()
        {
            return new ChoJSONReader<Root>(FilePath).FirstOrDefault();
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
    }
}
