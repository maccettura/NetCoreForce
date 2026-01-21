using Newtonsoft.Json;
using System.Collections.Generic;

namespace Forza.Net.Client.Models;

/// <summary>
/// Response from the /composite/sobjects endpoint when creating multiple records
/// </summary>
public class CompositeCreateResponse
{
    /// <summary>
    /// Array of results, one per input object
    /// </summary>
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Success flag
    /// </summary>
    [JsonProperty(PropertyName = "success")]
    public bool Success { get; set; }

    /// <summary>
    /// Errors if any
    /// </summary>
    [JsonProperty(PropertyName = "errors")]
    public List<CompositeCreateError> Errors { get; set; }
}

public class CompositeCreateError
{
    [JsonProperty(PropertyName = "statusCode")]
    public string StatusCode { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }

    [JsonProperty(PropertyName = "fields")]
    public List<string> Fields { get; set; }
}