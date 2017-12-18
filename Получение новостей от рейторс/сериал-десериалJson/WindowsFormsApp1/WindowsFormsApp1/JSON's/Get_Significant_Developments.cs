using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WindowsFormsApp1.JSON_s { 
public class Xrefs
{
    public string RepNo { get; set; }
    public int DevelopmentId { get; set; }
    public string Name { get; set; }
    public string Ticker { get; set; }
    public string RIC { get; set; }
    public string Country { get; set; }
}

public class Dates
{
    public DateTime Source { get; set; }
    public DateTime Initiation { get; set; }
    public DateTime LastUpdate { get; set; }
}

public class Flags
{
    public bool FrontPage { get; set; }
    public int Significance { get; set; }
}

public class Topic1
{
    public string Code { get; set; }
    public string Value { get; set; }
}

public class Topics
{
    public Topic1 Topic1 { get; set; }
}

public class Development
{
     //   [JsonProperty("Xrefs")]
        public Xrefs Xrefs { get; set; }

       // [JsonProperty("Dates")]
        public Dates Dates { get; set; }

        //[JsonProperty("Flags")]
        public Flags Flags { get; set; }

       // [JsonProperty("Topics")]
        public Topics Topics { get; set; }

       // [JsonProperty("Headline")]
        public string Headline { get; set; }

        //[JsonProperty("Description")]
        public string Description { get; set; }

}

public class FindResponse
{
        //[JsonProperty("Development")]
        public List<Development> Development { get; set; }
}

public class GetSignificantDevelopmentsResponse1
{
       // [JsonProperty("FindResponse")]
        public FindResponse FindResponse { get; set; }
}

public class RootObject
{
        public GetSignificantDevelopmentsResponse1 GetSignificantDevelopments_Response_1 { get; set; }
}
}