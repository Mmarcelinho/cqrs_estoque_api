namespace CQRS.Estoque.Infrastructure.Mappings;

public class LojaMap : IEntityTypeConfiguration<Loja>
{
    public void Configure(EntityTypeBuilder<Loja> builder)
    {
        builder.ToTable("Lojas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
        .HasColumnType("varchar(50)")
        .IsRequired();

        builder.Property(x => x.Endereco)
        .HasColumnType("varchar(50)")
        .IsRequired();

        builder.Property(x => x.Numero)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.Bairro)
        .HasColumnType("varchar(50)")
        .IsRequired();

        builder.Property(x => x.Telefone)
        .HasColumnType("char(14)")
        .IsRequired();

        builder.Property(x => x.Cnpj)
        .HasColumnType("varchar(18)")
        .IsRequired();

    }
}