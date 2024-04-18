namespace CQRS.Estoque.IoC.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
              this IServiceCollection services,
              IConfiguration configuration)
    {

        var SqlConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<Context>(opt => opt.UseSqlServer(SqlConnection));

        services.AddSingleton<IDbConnection>
        (provider =>
        {
            var connection = new SqlConnection(SqlConnection);
            connection.Open();
            return connection;
        });

        services.AddScoped<IRepositoryBase<Categoria>, RepositoryBase<Categoria>>();
        services.AddScoped<IRepositoryBase<Fornecedor>, RepositoryBase<Fornecedor>>();
        services.AddScoped<IRepositoryBase<Loja>, RepositoryBase<Loja>>();
        services.AddScoped<IRepositoryBase<Produto>, RepositoryBase<Produto>>();
        
        //Dapper
        services.AddScoped<IDapperRepositoryBase<Categoria>, CategoriaDapperRepository>();
        services.AddScoped<IDapperRepositoryBase<Fornecedor>, FornecedorDapperRepository>();
        services.AddScoped<IDapperRepositoryBase<Loja>, LojaDapperRepository>();
        services.AddScoped<IDapperRepositoryBase<Produto>, ProdutoDapperRepository>();

        //UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        var myHandlers = AppDomain.CurrentDomain.Load("CQRS.Estoque.Application");

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(myHandlers);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("CQRS.Estoque.Application"));
        

        return services;
    }
}
