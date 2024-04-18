namespace CQRS.Estoque.Infrastructure.Mappings;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Titulo)
        .IsRequired()
        .HasColumnType("varchar(200)");

        builder.Property(p => p.Preco)
        .IsRequired()
        .HasColumnType("numeric(38,2)");

        builder.Property(p => p.DataEntrada)
        .HasColumnType("datetime");

        builder.HasOne(P => P.Categoria)
        .WithMany(p => p.Produtos)
        .HasForeignKey(p => p.CategoriaId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(P => P.Fornecedor)
        .WithMany(p => p.Produtos)
        .HasForeignKey(p => p.FornecedorId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(P => P.Loja)
        .WithMany(p => p.Produtos)
        .HasForeignKey(p => p.LojaId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}