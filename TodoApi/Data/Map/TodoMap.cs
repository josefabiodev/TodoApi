using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Models;

namespace TodoApi.Data.Map
{
    public class TodoMap : IEntityTypeConfiguration<TodoModel>
    {
        public void Configure(EntityTypeBuilder<TodoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x=>x.Description).HasMaxLength(1200);
            builder.Property(x=>x.Status).IsRequired();
            builder.Property(x => x.UserId);

            builder.HasOne(x=>x.User);
        }
    }
}
