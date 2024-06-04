namespace Domain.Configurations;

public class ReviewConfiguration
    : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.UserId);

        builder.HasData(new List<ReviewEntity>
        {
            new()
            {
               Id = Guid.NewGuid(),
               UserId = Guid.Parse("cdc4a3b4-125f-47f6-8a26-99d057c47d5b"),
               Content = "Брал книгу в аренду на 1 месяц, после чего продлил еще на один, остался очень доволен!",
               Grade = 5,
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5"),
                Content = "Взяла на 2 недели сказку, Репка мне очень понравилась.",
                Grade = 5,
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("08278464-1115-440e-b6ab-5f70d77db79d"),
                Content = "Брал повесть о похождениях Петра Великого очень понравился рекомендую!",
                Grade = 4,
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("2f25fde8-c877-407c-adc9-cad036363c53"),
                Content = "Пользуюсь услугами этой организации уже 2 года очень довольна, всегда есть " +
                          "что взять почитать!",
                Grade = 5,
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("da9b2344-4237-4868-ad78-5e1e35a467fe"),
                Content = "Брал для учебы учебник по математике 11 класс, смогу подготовиться к ЕГЭ и сдал " +
                          "его на 82 балла, очень благодарен",
                Grade = 4,
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("85e3c09a-fa0c-4499-97c8-64644e588023"),
                Content = "Читаю каждый день, по 5 часов в день, очень благодарна данному проекта " +
                          "моего знакомого-друга Азиза!",
                Grade = 5,
            }
        });
    }
}