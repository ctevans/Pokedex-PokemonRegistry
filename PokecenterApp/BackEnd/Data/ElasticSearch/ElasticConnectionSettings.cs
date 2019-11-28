/**
* Reference for ElasticConnectionSettings found from
* https://devadventures.net/2018/04/16/connect-your-asp-net-core-application-to-elasticsearch-using-nest-5/
**/
public class ElasticConnectionSettings
{
    public string ClusterUrl { get; set; }

    public string DefaultIndex
    {
        get
        {
            return this.defaultIndex;
        }
        set
        {
            this.defaultIndex = value.ToLower();
        }
    }

    private string defaultIndex;
}