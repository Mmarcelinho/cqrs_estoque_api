namespace CQRS.Estoque.Infrastructure.Mappings;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Titulo)
        .IsRequired()
        .HasColumnType("varchar(200)");
    }
}