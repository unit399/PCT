using PCT.Domain.Common.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace PCT.Domain.PersonalValue.Entities;

[SwaggerSchema(Required = new[] {"Name", "Description"})]

public sealed class PersonalValue : BaseEntity
{
    [SwaggerRequestBody(Description = "Name", Required = true)]
    public string Name { get; set; } = string.Empty;
    [SwaggerRequestBody(Description = "Description", Required = true)]
    public string Description { get; set; } = string.Empty;
}