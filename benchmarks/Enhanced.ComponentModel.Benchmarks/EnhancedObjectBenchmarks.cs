using System.ComponentModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Enhanced.ComponentModel.Benchmarks
{
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class EnhancedObjectBenchmarks
    {
        private const string Value1 = "Value1";
        private const string Value2 = "Value2";

        private readonly object _sampleEnhancedObject;
        private readonly PropertyDescriptor _sampleEnhancedPropertyDescriptor;
        private readonly object _sampleRegularObject;
        private readonly PropertyDescriptor _sampleRegularPropertyDescriptor;

        public EnhancedObjectBenchmarks()
        {
            EnhancedTypeDescriptionProvider.CreateBuilder()
                .RegisterContainer(typeof(SampleEnhancedObjectContainer))
                .Build()
                .Apply();

            _sampleEnhancedObject = new SampleEnhancedObject
            {
                Value = Value1
            };

            _sampleEnhancedPropertyDescriptor = TypeDescriptor
                .GetProperties(_sampleEnhancedObject)
                .Find(nameof(SampleEnhancedObject.Value), false);

            _sampleRegularObject = new SampleRegularObject
            {
                Value = Value1
            };

            _sampleRegularPropertyDescriptor = TypeDescriptor
                .GetProperties(_sampleRegularObject)
                .Find(nameof(SampleRegularObject.Value), false);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("GetValue")]
        public object? RegularGetValue()
        {
            return _sampleRegularPropertyDescriptor.GetValue(_sampleRegularObject);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("SetValue")]
        public void RegularSetValue()
        {
            _sampleRegularPropertyDescriptor.SetValue(_sampleRegularObject, Value2);
        }

        [Benchmark]
        [BenchmarkCategory("GetValue")]
        public object? EnhancedGetValue()
        {
            return _sampleEnhancedPropertyDescriptor.GetValue(_sampleEnhancedObject);
        }

        [Benchmark]
        [BenchmarkCategory("SetValue")]
        public void EnhancedSetValue()
        {
            _sampleEnhancedPropertyDescriptor.SetValue(_sampleEnhancedObject, Value2);
        }

        private class SampleRegularObject
        {
            public string Value { get; set; }
        }

        public class SampleEnhancedObject : EnhancedObject
        {
            public string Value { get; set; }
        }

        public class SampleEnhancedObjectContainer : EnhancedTypeDescriptionContainer
        {
            protected override void OnRegister()
            {
                Register<SampleEnhancedObject>(typeof(SampleEnhancedObject).FullName!)
                    .AddProperty<string>(nameof(SampleEnhancedObject.Value))
                    .AddGetter(s => s.Value)
                    .AddSetter((s, val) => s.Value = val);
            }
        }
    }
}