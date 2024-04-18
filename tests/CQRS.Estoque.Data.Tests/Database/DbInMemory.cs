namespace CQRS.Estoque.Data.Tests.Database;

public class DbInMemory
{
    private readonly Context _dataContext;

    private readonly SqliteConnection _connection;

    public DbInMemory()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<Context>()
        .UseSqlite(_connection)
        .EnableSensitiveDataLogging()
        .Options;

        _dataContext = new Context(options);

        InsertFakeData();
    }

    public Context GetContext() => _dataContext;

    public IDbConnection GetConnection() => _connection;

    public void Cleanup() => _connection.Close();

    private void InsertFakeData()
    {
        if (_dataContext.Database.EnsureCreated())
        {
            var ids = new[] { 1, 2, 3, 4 };

            ids.ToList().ForEach(id =>
            {
                CategoriaFakeData(id);
                FornecedorFakeData(id);
                LojaFakeData(id);
                ProdutoFakeData(id);
            });
            _dataContext.SaveChanges();
        }
    }

    private void CategoriaFakeData(int id) =>
        _dataContext.Categorias.Add(new Categoria(id, $"Categoria{id}"));

    private void FornecedorFakeData(int id)
    {
        _dataContext.Fornecedores.Add(new Fornecedor
        (id, $"Fornecedor{id}"));
    }

    private void LojaFakeData(int id)
    {
        _dataContext.Lojas.Add(new Loja(id, $"Loja{id}", $"Endereco{id}", id, $"Bairro{id}", "71999999999", "123456789101214"));
    }

    private void ProdutoFakeData(int id)
    {
        _dataContext.Produtos.Add(new Produto(id, $"Produto{id}", 10 * id, id, id, id));
    }
}

