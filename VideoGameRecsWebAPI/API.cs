public static class API
{
  private static readonly string s_ConnectionString = File.ReadAllText("C:/Users/user/Documents/postgres_login.txt");
  public static void ConfigureAPI(this WebApplication app)
  {
    app.MapGet("/random", GetRandomGame);
    app.MapGet("/id", GetGameById);
  }

  public static async Task<IResult> GetRandomGame()
  {
    DbGameDataAccess dbGameData = new(new(s_ConnectionString));
    try
    {
      return Results.Ok(await dbGameData.GetRandomGame());
    }
    catch (Exception ex)
    {
      return Results.Problem(ex.Message);
    }
  }

  public static async Task<IResult> GetGameById(int id)
  {
    DbGameDataAccess dbGameData = new(new(s_ConnectionString));
    try
    {
      return Results.Ok(await dbGameData.GetGameById(id));
    }
    catch (Exception ex)
    {
      return Results.Problem(ex.Message);
    }
  }
}
