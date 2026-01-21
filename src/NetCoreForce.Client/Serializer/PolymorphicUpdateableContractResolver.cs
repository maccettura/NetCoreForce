using NetCoreForce.Client.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Forza.Net.Client.Serializer;

/// <summary>
/// Contract resolver for serializing polymorphic ISfModel objects in update requests.
/// Allows ISfModel types to serialize without [Updateable] attributes.
/// Ensures 'attributes' field is serialized first in ALL objects (including nested ones).
/// </summary>
public class PolymorphicUpdateableContractResolver : DefaultContractResolver
{
    List<string> _fieldsToNull;

    public PolymorphicUpdateableContractResolver(List<string> fieldsToNull = null)
    {
        _fieldsToNull = fieldsToNull;
        NamingStrategy = new DefaultNamingStrategy();
    }

    protected override JsonObjectContract CreateObjectContract(Type objectType)
    {
        var contract = base.CreateObjectContract(objectType);

        // Reorder properties so 'attributes' comes first
        if (contract.Properties != null && contract.Properties.Count > 0)
        {
            var attributesProperty = contract.Properties.FirstOrDefault(p =>
                string.Equals(p.PropertyName, "attributes", StringComparison.OrdinalIgnoreCase));

            if (attributesProperty != null)
            {
                contract.Properties.Remove(attributesProperty);
                contract.Properties.Insert(0, attributesProperty);
            }
        }

        return contract;
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization serialization)
    {
        var property = base.CreateProperty(member, serialization);

        // Get the type where this property is declared
        var declaringType = member.DeclaringType;

        // Check if this is an ISfModel type (doesn't require [Updateable] attribute)
        // ISfModel needs to be added
        var isISfModelType = true;
                             //declaringType != null &&
                             //typeof(ISfModel).IsAssignableFrom(declaringType);

        // For ISfModel types, allow all properties except those explicitly marked [JsonIgnore]
        if (isISfModelType)
        {
            var jsonIgnoreAttribute = member.GetCustomAttribute<JsonIgnoreAttribute>();
            if (jsonIgnoreAttribute != null)
            {
                property.Ignored = true;
            }
            else
            {
                // Explicitly allow serialization by NOT setting ShouldSerialize
                // This ensures properties serialize unless they're null and ignoreNulls is true
                property.ShouldSerialize = null;
            }
        }
        else
        {
            // For other types, check for [Updateable] attribute
            var updateableAttribute = member.GetCustomAttribute<UpdateableAttribute>();
            if (updateableAttribute != null && !updateableAttribute.Updateable)
            {
                property.ShouldSerialize = x => false;
            }
        }

        // Always include ID fields
        if (string.Equals(property.PropertyName, "id", StringComparison.OrdinalIgnoreCase))
        {
            property.ShouldSerialize = x => true;
        }

        // Handle fields to null
        if (_fieldsToNull != null && _fieldsToNull.FindIndex(x => x.Equals(property.PropertyName, System.StringComparison.OrdinalIgnoreCase)) != -1)
        {
            property.NullValueHandling = NullValueHandling.Include;
        }

        return property;
    }
}