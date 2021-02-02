using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pessoas.HyperMedia.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Pessoas.HyperMedia.Filters
{
    public class HypermediaFilter : ResultFilterAttribute
    {
        private readonly HypermediaFilterOptions _hypermediaFilterOptions;

        public HypermediaFilter(HypermediaFilterOptions hypermediaFilterOptions)
        {
            _hypermediaFilterOptions = hypermediaFilterOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher =
                    _hypermediaFilterOptions
                        .ContentResponseEnricherList
                        .FirstOrDefault(x => x.CanEnrich(context));

                if (enricher != null)
                {
                    Task.FromResult(enricher.Enrich(context));
                }
            }
        }
    }
}