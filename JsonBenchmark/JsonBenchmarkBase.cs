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
        protected string JsonAnotherSampleString;
        protected Root RootSampleObject;
        protected Rootobject AnotherRootSampleObject;

        protected JsonBenchmarkBase()
        {
            FilePath = CombinePath("chucknorris.json");
            JsonSampleString = File.ReadAllText(FilePath);
            JsonAnotherSampleString = File.ReadAllText(CombinePath("localities.json"));

            RootSampleObject = JsonConvert.DeserializeObject<Root>(JsonSampleString);
            AnotherRootSampleObject = JsonConvert.DeserializeObject<Rootobject>(JsonAnotherSampleString);
        }

        private static string CombinePath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, TestFilesFolder, fileName);
        }
    }
}
