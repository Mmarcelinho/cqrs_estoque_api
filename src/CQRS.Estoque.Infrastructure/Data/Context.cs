namespace CQRS.Estoque.Infrastructure.Data;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    { }

    public DbSet<Fornecedor> Fornecedores { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Loja> Lojas { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}
