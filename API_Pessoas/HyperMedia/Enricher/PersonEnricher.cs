using System.Text;
using System.Threading.Tasks;
using API_Pessoas.Data.VO;
using API_Pessoas.HyperMedia.Constants;
using Microsoft.AspNetCore.Mvc;

namespace API_Pessoas.HyperMedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PessoaVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PessoaVO content, IUrlHelper urlHelper)
        {
            var path = "api/pessoas/v1";
            string link = GetLink(content.Id, urlHelper, path);
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerbo.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerbo.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerbo.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerbo.PATCH,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPatch
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerbo.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });




            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new {controller = path, id = id};
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
        
        
    }
}