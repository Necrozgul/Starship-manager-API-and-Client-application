using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;


namespace ZNJXL9_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        [Test]
        public void TestCtor()
        {
            Starship storage = new LRU();
            Assert.That(storage.Recent, Is.Not.Null);
            Assert.That(storage.Recent, Is.Empty);
        }

        [Test]
        public void TestDefaultCtorParam()
        {
            LRU storage = new LRU();
            Assert.That(storage.ListLimit, Is.EqualTo(LRU.DEFAULT_LIMIT));
        }

        [TestCase(10)]
        [TestCase(5)]
        public void TestCtorLimitOnGoodParam(int limit)
        {
            LRU storage = new LRU(limit);
            Assert.That(storage.ListLimit, Is.EqualTo(limit));
        }

        // Edge cases, boundary testing
        // random testing: monkey testing, fuzzing
        [TestCase(0)]
        [TestCase(-45)]
        public void TestCtorLimitOnBadParam(int limit)
        {
            Assert.That(
                () => { LRU storage = new LRU(limit); },
                Throws.TypeOf<ArgumentOutOfRangeException>()
            );
        }

        // testing on one LRU

        const int LIMIT = 5;
        LRU lru;
        [SetUp]
        public void Setup()
        {
            lru = new LRU(LIMIT);
        }

        [Test]
        public void TestAddNullShouldThrowException()
        {
            Assert.That(
                () => { lru.Add(null); },
                Throws.ArgumentNullException
            );
        }

        [Test]
        public void TestLimitWorks()
        {
            object[] instances = new object[LIMIT * 2];
            for (int i = 0; i < instances.Length; i++)
            {
                instances[i] = new { IDX = i };
                lru.Add(instances[i]);
            }
            Assert.That(lru.Recent.Count, Is.EqualTo(LIMIT));
            for (int i = 0; i < LIMIT; i++)
            {
                Assert.That(lru.Recent, Does.Contain(instances[i + LIMIT]));
            }
        }

        // ***NO*** IEnumarable<object[]> since nunit/issues/1792
        static IEnumerable<TestCaseData> TestCountsSource
        {
            get
            {
                var first = new { IDX = 1 };
                var second = new { IDX = 2 };
                var third = new { IDX = 3 };
                List<TestCaseData> output = new List<TestCaseData>();
                output.Add(new TestCaseData(new object[] { first, second, third }, 3));
                output.Add(new TestCaseData(new object[] { first, second, second }, 2));
                output.Add(new TestCaseData(new object[] { first, first, first }, 1));
                return output;
                // alternative: yield return
            }
        }

        [TestCaseSource(nameof(TestCountsSource))]
        [TestCaseSource(nameof(TestCountSourceYield))]
        public void TestCounts(object[] instances, int expectedCount)
        {
            foreach (object item in instances) lru.Add(item);
            Assert.That(lru.Recent.Count, Is.EqualTo(expectedCount));
        }

        static IEnumerable<TestCaseData> TestCountSourceYield
        {
            get
            {
                var first = new { IDX = 1 };
                var second = new { IDX = 2 };
                var third = new { IDX = 3 };
                yield return new TestCaseData(new object[] { first, second, third }, 3);
                yield return new TestCaseData(new object[] { first, second, second }, 2);
                yield return new TestCaseData(new object[] { first, first, first }, 1);
            }
        }

        public static IEnumerable<TestCaseData> TestOrderSource
        {
            get
            {
                var first = new { IDX = 1 };
                var second = new { IDX = 2 };
                var third = new { IDX = 3 };
                List<TestCaseData> output = new List<TestCaseData>();
                output.Add(new TestCaseData
                (
                    new object[] { first, second, third }, // items added
                    new object[] { third, second, first } // expected order
                ));
                output.Add(new TestCaseData
                (
                    new object[] { first, second, second }, // items added
                    new object[] { second, first } // expected order
                ));
                output.Add(new TestCaseData
                (
                    new object[] { first, second, first }, // items added
                    new object[] { first, second } // expected order
                ));
                return output;
            }
        }

        public static IEnumerable<TestCaseData> TestOrderSourceYield
        {
            get
            {
                var first = new { IDX = 1 };
                var second = new { IDX = 2 };
                var third = new { IDX = 3 };
                yield return new TestCaseData
                (
                    new object[] { first, second, third }, // items added
                    new object[] { third, second, first } // expected order
                );
                yield return new TestCaseData
                (
                    new object[] { first, second, second }, // items added
                    new object[] { second, first } // expected order
                );
                yield return new TestCaseData
                (
                    new object[] { first, second, first }, // items added
                    new object[] { first, second } // expected order
                );
            }
        }

        [TestCaseSource(nameof(TestOrderSourceYield))]
        public void TestOrder(object[] instancesToAdd, object[] expectedOrder)
        {
            foreach (object item in instancesToAdd) lru.Add(item);
            for (int i = 0; i < expectedOrder.Length; i++)
            {
                Assert.That(lru.Recent[i], Is.SameAs(expectedOrder[i]));
            }
            // REGRESSION: fixes in #7
        }


    }
}
