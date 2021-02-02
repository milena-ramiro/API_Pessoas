using System.Collections.Generic;

namespace API_Pessoas.HyperMedia.Abstract
{
    public interface ISupportHypermedia
    {
        List<HypermediaLink> Links{get; set; }
    }
}