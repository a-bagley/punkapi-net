using System;
using System.Collections.Generic;

namespace PunkApiNet
{
    public class PunkApiRequestParams
    {
        public const int DefaultMaxResultCount = 25;

        public int? MaxResultCount { get; set; }
        public int? PageIndex { get; set; }
        public int? AbvGreaterThan { get; set; }
        public int? AbvLessThan { get; set; }
        public int? IbuGreaterThan { get; set; }
        public int? IbuLessThan { get; set; }
        public int? EbcGreaterThan { get; set; }
        public int? EbcLessThan { get; set; }
        public string BeerName { get; set; }
        public string Yeast { get; set; }
        public DateTime? BrewedBefore { get; set; }
        public DateTime? BrewedAfter { get; set; }
        public string Hops { get; set; }
        public string Malt { get; set; }
        public string Food { get; set; }
        public IList<int> Ids { get; set; } = new List<int>();

        public static PunkApiRequestParams Default()
            => new PunkApiRequestParams { MaxResultCount = DefaultMaxResultCount };

    }
}
