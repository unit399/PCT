using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PCT.Infrastructure.PersonalValue.Configuration;

public class PersonalValueConfigurations : IEntityTypeConfiguration<Domain.PersonalValue.Entity.PersonalValue>
{
    public void Configure(EntityTypeBuilder<Domain.PersonalValue.Entity.PersonalValue> builder)
    {
        
    }
}