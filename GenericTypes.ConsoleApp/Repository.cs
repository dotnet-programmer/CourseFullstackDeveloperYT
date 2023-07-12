namespace GenericTypes.ConsoleApp;

// generic constraints - ograniczenia na typ T
// class - typ referencyjny
// new() - typ musi mieć konstruktor bezparametrowy
// IEntity - typ musi implementować interfejs IEntity
internal class Repository<T> where T : IEntity, new()
{
	private readonly List<T> data = new();

	public void AddElement(T element)
	{
		T newElement = new()
		{
			Id = 23
		};

		if (element != null)
		{
			data.Add(element);
			Console.WriteLine(element.Id);
		}
	}

	public T GetElementById(int id) => data.FirstOrDefault(e => e.Id == id);

	public T GetElement(int index)
	{
		if (index < data.Count)
		{
			return data[index];
		}
		else
		{
			//throw new IndexOutOfRangeException();
			return default;
		}
	}
}

// można nakładać ograniczenia na każdy typ z osobna, dla każdego z nich trzeba użyć słowa kluczowego where
internal class Repository<TKey, TValue>
	where TKey : class
	where TValue : new()
{
	private readonly Dictionary<TKey, TValue> data = new();

	public void AddElement(TKey key, TValue element)
	{
		if (element != null)
		{
			data.Add(key, element);
		}
	}

	public TValue GetElement(TKey key)
	{
		if (data.TryGetValue(key, out TValue result))
		{
			return result;
		}
		else
		{
			return default;
		}
	}
}