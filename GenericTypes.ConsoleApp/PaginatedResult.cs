namespace GenericTypes.ConsoleApp;

public class PaginatedResult<T>
{
	public List<T> Results { get; set; }
	public int ResultsFrom { get; set; }
	public int ResultsTo { get; set; }
	public int TotalPages { get; set; }
	public int TotalResults { get; set; }
}

public class Restaurant : IEntity
{
	public int Id { get; set; }
}

public class User : IEntity
{
    public User()
    {
		
    }
    public User(string name, int id)
    {
        Name = name;
		Id = id;
    }
    public string Name { get; set; }
	public int Id { get; set; }
}

public interface IEntity
{
    int Id { get; set; }
}