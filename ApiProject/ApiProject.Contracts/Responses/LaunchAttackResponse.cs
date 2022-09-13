using ApiProject.Contracts.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ApiProject.Contracts.Responses;

public record LaunchAttackResponse(
    [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
    AttackStatus Status
);
