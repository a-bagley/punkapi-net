using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PunkApiNet
{
    public static class PunkQueryParamCreator
    {
        public static string BuildQueryParamsString(PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams == null)
                return string.Empty;

            var queryBuilder = new StringBuilder();

            AddPageIndex(queryBuilder, punkApiRequestParams);
            AddMaxResults(queryBuilder, punkApiRequestParams);
            AddAbvGreaterThan(queryBuilder, punkApiRequestParams);
            AddAbvLessThan(queryBuilder, punkApiRequestParams);
            AddIbuGreaterThan(queryBuilder, punkApiRequestParams);
            AddIbuLessThan(queryBuilder, punkApiRequestParams);
            AddEbcGreaterThan(queryBuilder, punkApiRequestParams);
            AddEbcLessThan(queryBuilder, punkApiRequestParams);
            AddBeerName(queryBuilder, punkApiRequestParams);
            AddYeast(queryBuilder, punkApiRequestParams);
            AddBrewedBefore(queryBuilder, punkApiRequestParams);
            AddBrewedAfter(queryBuilder, punkApiRequestParams);
            AddHops(queryBuilder, punkApiRequestParams);
            AddMalt(queryBuilder, punkApiRequestParams);
            AddFood(queryBuilder, punkApiRequestParams);
            AddIds(queryBuilder, punkApiRequestParams);

            return queryBuilder.ToString();
        }

        private static void AddMaxResults(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.MaxResultCount.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("per_page");
                AddValue(stringBuilder, punkApiRequestParams.MaxResultCount.Value);
            }
        }

        private static void AddPageIndex(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.PageIndex.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("page");
                AddValue(stringBuilder, punkApiRequestParams.PageIndex.Value);
            }
        }

        private static void AddAbvGreaterThan(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.AbvGreaterThan.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("abv_gt");
                AddValue(stringBuilder, punkApiRequestParams.AbvGreaterThan.Value);
            }
        }

        private static void AddAbvLessThan(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.AbvLessThan.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("abv_lt");
                AddValue(stringBuilder, punkApiRequestParams.AbvLessThan.Value);
            }
        }

        private static void AddIbuGreaterThan(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.IbuGreaterThan.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("ibu_gt");
                AddValue(stringBuilder, punkApiRequestParams.IbuGreaterThan.Value);
            }
        }

        private static void AddIbuLessThan(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.IbuLessThan.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("ibu_lt");
                AddValue(stringBuilder, punkApiRequestParams.IbuLessThan.Value);
            }
        }

        private static void AddEbcGreaterThan(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.EbcGreaterThan.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("ebc_gt");
                AddValue(stringBuilder, punkApiRequestParams.EbcGreaterThan.Value);
            }
        }

        private static void AddEbcLessThan(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.EbcLessThan.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("ebc_lt");
                AddValue(stringBuilder, punkApiRequestParams.EbcLessThan.Value);
            }
        }

        private static void AddBeerName(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (!string.IsNullOrWhiteSpace(punkApiRequestParams.BeerName))
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("beer_name");
                AddValue(stringBuilder, punkApiRequestParams.BeerName);
            }
        }

        private static void AddYeast(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (!string.IsNullOrWhiteSpace(punkApiRequestParams.Yeast))
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("yeast");
                AddValue(stringBuilder, punkApiRequestParams.Yeast);
            }
        }

        private static void AddBrewedBefore(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.BrewedBefore.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("brewed_before");
                AddValue(stringBuilder, punkApiRequestParams.BrewedBefore.Value.ToString("MM-yyyy"));
            }
        }

        private static void AddBrewedAfter(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.BrewedAfter.HasValue)
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("brewed_after");
                AddValue(stringBuilder, punkApiRequestParams.BrewedAfter.Value.ToString("MM-yyyy"));
            }
        }

        private static void AddHops(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (!string.IsNullOrWhiteSpace(punkApiRequestParams.Hops))
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("hops");
                AddValue(stringBuilder, punkApiRequestParams.Hops);
            }
        }

        private static void AddMalt(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (!string.IsNullOrWhiteSpace(punkApiRequestParams.Malt))
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("malt");
                AddValue(stringBuilder, punkApiRequestParams.Malt);
            }
        }

        private static void AddFood(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (!string.IsNullOrWhiteSpace(punkApiRequestParams.Food))
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("food");
                AddValue(stringBuilder, punkApiRequestParams.Food);
            }
        }

        private static void AddIds(StringBuilder stringBuilder, PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams.Ids != null
                && punkApiRequestParams.Ids.Any())
            {
                AddParamConnector(stringBuilder);
                stringBuilder.Append("ids");
                AddValue(stringBuilder, punkApiRequestParams.Ids);
            }
        }

        private static void AddParamConnector(StringBuilder stringBuilder)
        {
            if (stringBuilder.Length == 0)
            {
                stringBuilder.Append("?");
            }
            else
            {
                stringBuilder.Append("&");
            }
        }

        private static void AddValue(StringBuilder stringBuilder, int value)
        {
            stringBuilder.Append($"={value}");
        }

        private static void AddValue(StringBuilder stringBuilder, string value)
        {
            stringBuilder.Append($"={SpacesToUnderscores(value)}");
        }

        private static string SpacesToUnderscores(string value) => value.Replace(' ', '_');
        
        private static void AddValue(StringBuilder stringBuilder, IEnumerable<int> values)
        {
            stringBuilder.Append("=");
            foreach (var value in values)
            {
                stringBuilder.Append(value).Append("|");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
    }
}
