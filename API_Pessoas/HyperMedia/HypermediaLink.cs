using System.Text;

namespace API_Pessoas.HyperMedia
{
    public class HypermediaLink
    {
        public string Rel { get; set; }
        
        private string _href;
        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(_href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { _href = value; }
        }
        
        public string Type { get; set; }
        public string Action { get; set; }
    }
}