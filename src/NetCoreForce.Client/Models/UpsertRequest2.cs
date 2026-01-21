using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetCoreForce.Client.Models;
public class UpsertRequest2
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="records"></param>
    /// <param name="allOrNone"></param>
    public UpsertRequest2(List<object> records, bool allOrNone = false)
    {
        Records = records;
        AllOrNone = allOrNone;
    }

    /// <summary>
    /// Required. A list of sObjects. In a POST request using sObject Collections,
    /// set the type attribute for each object, but don't set the id field for any object.
    /// </summary>
    [JsonProperty(PropertyName = "records")]
    public List<object> Records { get; set; }

    /// <summary>
    /// Optional. Indicates whether to roll back the entire request when the update of any object fails (true) or
    /// to continue with the independent update of other objects in the request. The default is false.
    /// </summary>
    [JsonProperty(PropertyName = "allOrNone")]
    public bool AllOrNone { get; set; }
}
