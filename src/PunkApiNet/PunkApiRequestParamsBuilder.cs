using System;

namespace PunkApiNet
{
    public class PunkApiRequestParamsBuilder
    {
        private readonly PunkApiRequestParams _punkApiRequestParams = new PunkApiRequestParams();

        public PunkApiRequestParamsBuilder WithMaxResultsPerPage(int value)
        {
            _punkApiRequestParams.MaxResultCount = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithPage(int value)
        {
            _punkApiRequestParams.PageIndex = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithAbvGreatherThan(int value)
        {
            _punkApiRequestParams.AbvGreaterThan = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithAbvLessThan(int value)
        {
            _punkApiRequestParams.AbvLessThan = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithBeerName(string value)
        {
            _punkApiRequestParams.BeerName = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithBrewedAfter(DateTime value)
        {
            _punkApiRequestParams.BrewedAfter = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithBrewedBefore(DateTime value)
        {
            _punkApiRequestParams.BrewedBefore = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithEbcGreatherThan(int value)
        {
            _punkApiRequestParams.EbcGreaterThan = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithEbcLessThan(int value)
        {
            _punkApiRequestParams.EbcLessThan = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithFood(string value)
        {
            _punkApiRequestParams.Food = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithHops(string value)
        {
            _punkApiRequestParams.Hops = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithIbuGreatherThan(int value)
        {
            _punkApiRequestParams.IbuGreaterThan = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithIbuLessThan(int value)
        {
            _punkApiRequestParams.IbuLessThan = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithId(int value)
        {
            _punkApiRequestParams.Ids.Add(value);
            return this;
        }

        public PunkApiRequestParamsBuilder WithMalt(string value)
        {
            _punkApiRequestParams.Malt = value;
            return this;
        }

        public PunkApiRequestParamsBuilder WithYeast(string value)
        {
            _punkApiRequestParams.Yeast = value;
            return this;
        }

        public PunkApiRequestParams Build()
            => _punkApiRequestParams;
    }
}
