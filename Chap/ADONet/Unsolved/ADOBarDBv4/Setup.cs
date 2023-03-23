
using Microsoft.Data.SqlClient;

public class Setup
{
    public DrinkDataService DrinkService { get; }
    public IngredientDataService IngredientService { get; }

    public Setup(string dataSource, string initialCatalog)
    {
        // Setup DB
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = dataSource;
        builder.InitialCatalog = initialCatalog;

        // Setup Repositories
        IngredientRepository iRepo = new IngredientRepository(builder.ConnectionString);
        DrinkDesolvedRepository ddRepo = new DrinkDesolvedRepository(builder.ConnectionString);

        // Setup services
        IngredientService = new IngredientDataService(iRepo);
        DrinkService = new DrinkDataService(iRepo, ddRepo);
    }
}
