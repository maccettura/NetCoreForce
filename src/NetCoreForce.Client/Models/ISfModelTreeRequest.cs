using Newtonsoft.Json;
using System.Collections.Generic;

namespace Forza.Net.Client.Models;

/// <summary>
/// Request wrapper for creating multiple ISfModel objects via the SObject Tree API
/// </summary>
public class ISfModelTreeRequest
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="records"></param>
    public ISfModelTreeRequest(List<object> records)
    {
        Records = records;
    }

    /// <summary>
    /// Required. A list of ISfModel objects. In a POST request using sObject Collections,
    /// set the type attribute for each object, but don't set the id field for any object.
    /// </summary>
    [JsonProperty(PropertyName = "records")]
    public List<object> Records { get; set; }
}