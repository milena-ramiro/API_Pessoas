using System.Collections.Generic;
using API_Pessoas.HyperMedia.Abstract;

namespace API_Pessoas.HyperMedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}