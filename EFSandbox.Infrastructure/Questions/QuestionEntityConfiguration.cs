using EFSandbox.Domain.QuestionsAggregate.Questions;
using EFSandbox.Domain.QuestionsAggregate.Questions.MultipleChoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace EFSandbox.Infrastructure.Questions;

public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable(nameof(Question));
        builder.HasKey(q => q.Id);
        
        builder.ComplexProperty(s => s.Title, propertyBuilder =>
        {
            propertyBuilder
                .Property(c => c.Value)
                .HasColumnName(nameof(Question.Title));
        });
        
        builder.ComplexProperty(s => s.Description, propertyBuilder =>
        {
            propertyBuilder
                .Property(c => c.Value)
                .HasColumnName(nameof(Question.Description));
        });
        
        builder.ComplexProperty(s => s.CreatedAt, propertyBuilder =>
        {
            propertyBuilder
                .Property(c => c.Value)
                .HasColumnName(nameof(Question.CreatedAt));
        });

        builder.HasMany(q => q.Answers);
        builder.Navigation(q => q.Answers)
            .AutoInclude();

        builder.UseTphMappingStrategy()
            .HasDiscriminator(q => q.Type)
            .HasValue<TextQuestion>(Question.QuestionType.Text)
            .HasValue<MultipleChoiceQuestion>(Question.QuestionType.MultipleChoice);
    }
}

public class TextQuestionEntityConfiguration : IEntityTypeConfiguration<TextQuestion>
{
    public void Configure(EntityTypeBuilder<TextQuestion> builder)
    {
    }
}

public class MultipleChoiceQuestionEntityConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
    {
        builder.OwnsMany(q => q.Options, navigationBuilder =>
        {
            navigationBuilder.ToTable(nameof(Options));
            navigationBuilder.HasKey(x => x.Id);

            navigationBuilder.Property(x => x.Title);
        });
    }
}