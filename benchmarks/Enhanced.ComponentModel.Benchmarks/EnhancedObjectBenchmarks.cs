using System.ComponentModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Enhanced.ComponentModel.Benchmarks
{
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class EnhancedObjectBenchmarks
    {
        private const string StrValue1 = "Value1";
        private const string StrValue2 = "Value2";
        private const int IntValue1 = 26;
        private const int IntValue2 = 72;

        private readonly object _sampleEnhancedObject;
        private readonly PropertyDescriptor _sampleEnhancedStrPropertyDescriptor;
        private readonly PropertyDescriptor _sampleEnhancedIntPropertyDescriptor;
        private readonly object _sampleRegularObject;
        private readonly PropertyDescriptor _sampleRegularStrPropertyDescriptor;
        private readonly PropertyDescriptor _sampleRegularIntPropertyDescriptor;

        public EnhancedObjectBenchmarks()
        {
            var sampleEnhancedTypeDescriptionProvider = EnhancedTypeDescriptionProvider.CreateBuilder()
                .RegisterContainer(typeof(SampleEnhancedObjectContainer))
                .Build();

            _sampleEnhancedObject = new SampleEnhancedObject
            {
                StrValue = StrValue1,
                IntValue = IntValue1,
            };

            _sampleEnhancedStrPropertyDescriptor = sampleEnhancedTypeDescriptionProvider.GetTypeDescriptor(_sampleEnhancedObject)!
                .GetProperties()
                .Find(nameof(SampleEnhancedObject.StrValue), false);

            _sampleEnhancedIntPropertyDescriptor = sampleEnhancedTypeDescriptionProvider.GetTypeDescriptor(_sampleEnhancedObject)!
                .GetProperties()
                .Find(nameof(SampleEnhancedObject.IntValue), false);

            _sampleRegularObject = new SampleRegularObject
            {
                StrValue = StrValue1,
                IntValue = IntValue1,
            };

            _sampleRegularStrPropertyDescriptor = TypeDescriptor
                .GetProperties(_sampleRegularObject)
                .Find(nameof(SampleRegularObject.StrValue), false);

            _sampleRegularIntPropertyDescriptor = TypeDescriptor
                .GetProperties(_sampleRegularObject)
                .Find(nameof(SampleRegularObject.IntValue), false);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("GetValue_String")]
        public object? Regular_GetValue_String()
        {
            return _sampleRegularStrPropertyDescriptor.GetValue(_sampleRegularObject);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("SetValue_String")]
        public void Regular_SetValue_String()
        {
            _sampleRegularStrPropertyDescriptor.SetValue(_sampleRegularObject, StrValue2);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("GetValue_Int")]
        public object? Regular_GetValue_Int()
        {
            return _sampleRegularIntPropertyDescriptor.GetValue(_sampleRegularObject);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("SetValue_Int")]
        public void Regular_SetValue_Int()
        {
            _sampleRegularIntPropertyDescriptor.SetValue(_sampleRegularObject, IntValue2);
        }

        [Benchmark]
        [BenchmarkCategory("GetValue_String")]
        public object? Enhanced_GetValue_String()
        {
            return _sampleEnhancedStrPropertyDescriptor.GetValue(_sampleEnhancedObject);
        }

        [Benchmark]
        [BenchmarkCategory("SetValue_String")]
        public void Enhanced_SetValue_String()
        {
            _sampleEnhancedStrPropertyDescriptor.SetValue(_sampleEnhancedObject, StrValue2);
        }

        [Benchmark]
        [BenchmarkCategory("GetValue_Int")]
        public object? Enhanced_GetValue_Int()
        {
            return _sampleEnhancedIntPropertyDescriptor.GetValue(_sampleEnhancedObject);
        }

        [Benchmark]
        [BenchmarkCategory("SetValue_Int")]
        public void Enhanced_SetValue_Int()
        {
            _sampleEnhancedIntPropertyDescriptor.SetValue(_sampleEnhancedObject, IntValue2);
        }

        private class SampleRegularObject
        {
            public string StrValue { get; set; }
            public int IntValue { get; set; }
        }

        private class SampleEnhancedObject : EnhancedObject
        {
            public string StrValue { get; set; }
            public int IntValue { get; set; }
        }

        private class SampleEnhancedObjectContainer : EnhancedTypeDescriptionContainer
        {
            protected override void OnRegister()
            {
                Register<SampleEnhancedObject>(typeof(SampleEnhancedObject).FullName!)
                    .AddProperty(nameof(SampleEnhancedObject.StrValue), s => s.StrValue, (s, val) => s.StrValue = val)
                    .AddProperty(nameof(SampleEnhancedObject.IntValue), s => s.IntValue, (s, val) => s.IntValue = val);
            }
        }
    }
}