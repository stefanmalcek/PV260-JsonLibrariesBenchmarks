﻿using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using Newtonsoft.Json;

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
    }
}
