using EFSandbox.Domain.QuestionsAggregate.Questions;
using EFSandbox.Domain.SurveysAggregate;
using EFSandbox.Domain.SurveysAggregate.Close;
using EFSandbox.Domain.SurveysAggregate.Draft;
using EFSandbox.Domain.SurveysAggregate.Ready;
using EFSandbox.Domain.SurveysAggregate.Sent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSandbox.Infrastructure.Surveys;

public class SurveyEntityConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable(nameof(Survey));
        builder.HasKey(s => s.Id);

        builder.ComplexProperty(s => s.Title, propertyBuilder =>
        {
            propertyBuilder
                .Property(t => t.Value)
                .HasColumnName(nameof(Survey.Title))
                .HasMaxLength(Survey.SurveyTitle.MAX_LENGTH);
        });

        builder.ComplexProperty(s => s.CreatedAt, propertyBuilder =>
        {
            propertyBuilder
                .Property(c => c.Value)
                .HasColumnName(nameof(Survey.CreatedAt));
        });

        builder.OwnsMany(s => s.Questions, navigationBuilder =>
        {
            navigationBuilder.HasKey(sq => new { sq.SurveyId, sq.QuestionId, sq.Order });
            
            navigationBuilder
                .HasOne(x => x.Question)
                .WithOne()
                .HasForeignKey<Survey.SurveyQuestion>(x => x.QuestionId);
        });

        builder.UseTphMappingStrategy()
            .HasDiscriminator(s => s.Status)
            .HasValue<DraftSurvey>(Survey.SurveyStatus.Draft)
            .HasValue<ReadySurvey>(Survey.SurveyStatus.Ready)
            .HasValue<SentSurvey>(Survey.SurveyStatus.Sent)
            .HasValue<CloseSurvey>(Survey.SurveyStatus.Close);
    }
}

public class DraftSurveyEntityConfiguration : IEntityTypeConfiguration<DraftSurvey>
{
    public void Configure(EntityTypeBuilder<DraftSurvey> builder)
    {
        builder.HasOne(s => s.SchedulingInformation);
        builder.Navigation(a => a.SchedulingInformation)
            .AutoInclude();
    }
}

public class ReadySurveyEntityConfiguration : IEntityTypeConfiguration<ReadySurvey>
{
    public void Configure(EntityTypeBuilder<ReadySurvey> builder)
    {
        //builder.OwnsOne(s => s.SendingInformation);
        builder.OwnsOne(s => s.SendingInformation, navigationBuilder => navigationBuilder.ToTable(nameof(ReadySurvey.SendingInformation)));
    }
}

public class SentSurveyEntityConfiguration : IEntityTypeConfiguration<SentSurvey>
{
    public void Configure(EntityTypeBuilder<SentSurvey> builder)
    {
    }
}

public class CloseSurveyEntityConfiguration : IEntityTypeConfiguration<CloseSurvey>
{
    public void Configure(EntityTypeBuilder<CloseSurvey> builder)
    {
    }
}