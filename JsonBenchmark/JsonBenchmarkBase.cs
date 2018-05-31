using System;
using System.IO;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";
        protected string FilePath;
        protected string JsonSampleString;
        protected Root RootSampleObject;

        protected JsonBenchmarkBase()
        {
            FilePath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
            JsonSampleString = File.ReadAllText(FilePath);

            RootSampleObject = JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }
    }
}
