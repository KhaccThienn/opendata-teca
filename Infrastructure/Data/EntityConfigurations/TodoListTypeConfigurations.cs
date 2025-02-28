namespace Infrastructure.Data.EntityConfigurations
{
    public class TodoListTypeConfigurations : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.Property(t => t.Title)
               .HasMaxLength(200)
               .IsRequired();

            builder
                .OwnsOne(b => b.Colour);
        }
    }
}
