using EFSandbox.Domain.SurveysAggregate.Draft;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSandbox.Infrastructure.Surveys.SchedulingInformation;

public class SchedulingInformationEntityConfiguration : IEntityTypeConfiguration<DraftSurvey.DraftSurveySchedulingInformation>
{
    public void Configure(EntityTypeBuilder<DraftSurvey.DraftSurveySchedulingInformation> builder)
    {
        builder.ToTable(nameof(DraftSurvey.SchedulingInformation));
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.EndsAt);
        
        builder.UseTphMappingStrategy()
            .HasDiscriminator<string>("Type")
            .HasValue<DraftSurvey.Immediate>(nameof(DraftSurvey.Immediate))
            .HasValue<DraftSurvey.Later>(nameof(DraftSurvey.Later));
    }
}

public class ImmediateSchedulingInformationEntityConfiguration : IEntityTypeConfiguration<DraftSurvey.Immediate>
{
    public void Configure(EntityTypeBuilder<DraftSurvey.Immediate> builder)
    {
    }
}

public class LaterSchedulingInformationEntityConfiguration : IEntityTypeConfiguration<DraftSurvey.Later>
{
    public void Configure(EntityTypeBuilder<DraftSurvey.Later> builder)
    {
        builder.Property(x => x.StartsAt);
    }
}