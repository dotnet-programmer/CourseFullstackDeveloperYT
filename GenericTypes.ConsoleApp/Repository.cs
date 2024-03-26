namespace GenericTypes.ConsoleApp;

// generic constraints - ograniczenia na typ T
// class - typ referencyjny
// new() - typ musi mieć konstruktor bezparametrowy
// IEntity - typ musi implementować interfejs IEntity
internal class Repository<T> where T : IEntity, new()
{
	private readonly List<T> _data = [];

	public void AddElement(T element)
	{
		T newElement = new()
		{
			Id = 23
		};

		if (element != null)
		{
			_data.Add(element);
			Console.WriteLine(element.Id);
		}
	}

	public T GetElementById(int id) 
		=> _data.FirstOrDefault(e => e.Id == id);

	public T GetElement(int index)
	{
		if (index < _data.Count)
		{
			return _data[index];
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
	private readonly Dictionary<TKey, TValue> _data = [];

	public void AddElement(TKey key, TValue element)
	{
		if (element != null)
		{
			_data.Add(key, element);
		}
	}

	public TValue GetElement(TKey key) 
		=> _data.TryGetValue(key, out TValue result) ? result : default;
}