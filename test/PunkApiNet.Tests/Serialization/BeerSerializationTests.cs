using NUnit.Framework;
using PunkApiNet.Tests.TestHelpers;
using PunkApiNet.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PunkApiNet.Tests.Serialization
{
    [TestFixture]
    public class BeerSerializationTests
    {

        [Test]
        public async Task Can_deseriliaze_test_json_data()
        {
            IEnumerable<Beer> beers;
            using (var jsonStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Data", "beersTestData.json")))
            {
                beers = await BeerJsonHelper.FromJsonStreamAsync(jsonStream);
            }

            Assert.NotNull(beers);
            Assert.IsNotEmpty(beers);
            Assert.AreEqual(1, beers.Count());
            
            var beer = beers.Single();
            Assert.AreEqual(192, beer.Id);
            Assert.AreEqual("Punk IPA 2007 - 2010", beer.Name);
            Assert.AreEqual("https://images.punkapi.com/v2/192.png", beer.ImageUrl);
        }
    }
}
