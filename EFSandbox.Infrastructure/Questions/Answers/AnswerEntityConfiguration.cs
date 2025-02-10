using EFSandbox.Domain.QuestionsAggregate.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSandbox.Infrastructure.Questions.Answers;

public class AnswerEntityConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable(nameof(Answer));
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.User);
        builder.Navigation(a => a.User)
            .AutoInclude();

        builder.UseTphMappingStrategy()
            .HasDiscriminator<string>("Type")
            .HasValue(nameof(TextAnswer))
            .HasValue(nameof(MultipleChoiceAnswer));
    }
}

public class TextAnswerEntityConfiguration : IEntityTypeConfiguration<TextAnswer>
{
    public void Configure(EntityTypeBuilder<TextAnswer> builder)
    {
        builder.ComplexProperty(s => s.Response, propertyBuilder =>
        {
            propertyBuilder
                .Property(c => c.Value)
                .HasColumnName(nameof(TextAnswer.Response))
                .HasMaxLength(TextAnswer.TextResponse.MAX_LENGTH);
        });
    }
}

public class MultipleChoiceAnswerEntityConfiguration : IEntityTypeConfiguration<MultipleChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
    {
        builder.Property(m => m.OptionId);
    }
}