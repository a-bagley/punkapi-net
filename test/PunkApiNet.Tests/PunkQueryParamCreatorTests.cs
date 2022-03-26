using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PunkApiNet.Tests
{
    [TestFixture]
    public class PunkQueryParamCreatorTests
    {
        [TestCaseSource(nameof(BuildQueryParamsStringTestCases))]
        public void BuildQueryParamsString_should_build_correct_param_string(PunkApiRequestParams punkApiRequestParams, string expectedString)
        {
            var candidate = PunkQueryParamCreator.BuildQueryParamsString(punkApiRequestParams);

            Assert.AreEqual(expectedString, candidate);
        }

        private static IEnumerable BuildQueryParamsStringTestCases
        {
            get
            {
                yield return new TestCaseData(null, string.Empty).SetArgDisplayNames("Null params");
                yield return new TestCaseData(new PunkApiRequestParams(), string.Empty).SetArgDisplayNames("No params");
                yield return new TestCaseData(new PunkApiRequestParams { PageIndex = 2 }, "?page=2").SetArgDisplayNames("?page=2");
                yield return new TestCaseData(new PunkApiRequestParams { AbvGreaterThan = 1 }, "?abv_gt=1").SetArgDisplayNames("?abv_gt=1");
                yield return new TestCaseData(new PunkApiRequestParams { AbvLessThan = 2 }, "?abv_lt=2").SetArgDisplayNames("?abv_lt=2");
                yield return new TestCaseData(new PunkApiRequestParams { EbcGreaterThan = 3 }, "?ebc_gt=3").SetArgDisplayNames("?ebc_gt=3");
                yield return new TestCaseData(new PunkApiRequestParams { EbcLessThan = 4 }, "?ebc_lt=4").SetArgDisplayNames("?ebc_lt=4");
                yield return new TestCaseData(new PunkApiRequestParams { IbuGreaterThan = 5 }, "?ibu_gt=5").SetArgDisplayNames("?ibu_gt=5");
                yield return new TestCaseData(new PunkApiRequestParams { IbuLessThan = 6 }, "?ibu_lt=6").SetArgDisplayNames("?ibu_lt=6");
                yield return new TestCaseData(new PunkApiRequestParams { AbvGreaterThan = 2, AbvLessThan = 5 }, "?abv_gt=2&abv_lt=5").SetArgDisplayNames("?abv_gt=2&abv_lt=5");
                yield return new TestCaseData(new PunkApiRequestParams { BeerName = "gamma ray" }, "?beer_name=gamma_ray").SetArgDisplayNames("?beer_name=gamma_ray");
                yield return new TestCaseData(new PunkApiRequestParams { BeerName = "gamma ray", Yeast = "american" }, "?beer_name=gamma_ray&yeast=american").SetArgDisplayNames("?beer_name=gamma_ray&yeast=american");
                yield return new TestCaseData(new PunkApiRequestParams { BrewedBefore = new DateTime(2022, 01, 08) }, "?brewed_before=01-2022").SetArgDisplayNames("?brewed_before=01-2022");
                yield return new TestCaseData(new PunkApiRequestParams { BrewedAfter = new DateTime(2022, 01, 08) }, "?brewed_after=01-2022").SetArgDisplayNames("?brewed_after=01-2022");
                yield return new TestCaseData(new PunkApiRequestParams { Hops = "chinook" }, "?hops=chinook").SetArgDisplayNames("?chinook=chinook");
                yield return new TestCaseData(new PunkApiRequestParams { Malt = "pale" }, "?malt=pale").SetArgDisplayNames("?malt=pale");
                yield return new TestCaseData(new PunkApiRequestParams { Food = "burger" }, "?food=burger").SetArgDisplayNames("?food=burger");
                yield return new TestCaseData(new PunkApiRequestParams { Ids = new List<int>() }, string.Empty).SetArgDisplayNames("Empty Ids");
                yield return new TestCaseData(new PunkApiRequestParams { Ids = new[] { 1 } }, "?ids=1").SetArgDisplayNames("?ids=1");
                yield return new TestCaseData(new PunkApiRequestParams { Ids = new[] { 1, 2 } }, "?ids=1|2").SetArgDisplayNames("?ids=1|2");
                yield return new TestCaseData(new PunkApiRequestParams { Ids = new[] { 1, 2, 3 } }, "?ids=1|2|3").SetArgDisplayNames("?ids=1|2|3");
            }
        }
    }
}
