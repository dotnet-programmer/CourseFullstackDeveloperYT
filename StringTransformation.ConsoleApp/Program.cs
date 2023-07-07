// https://www.youtube.com/watch?v=pN-84UL2nuw

using System.Text;

Console.WriteLine("camelCase to kebab-case:");
string test1 = "thisIsSomeVariableInCamelCase";
Console.WriteLine(CamelCaseToKebabCase(test1));
Console.WriteLine();
Console.WriteLine("kebab-case to camelCase:");
string test2 = "this-is-some-variable-in-kebab-case";
Console.WriteLine(KebabCaseToCamelCase(test2));
Console.ReadLine();

static string CamelCaseToKebabCase(string text)
{
	StringBuilder sb = new();
	foreach (var letter in text)
	{
		if (char.IsUpper(letter))
		{
			sb.Append('-').Append(char.ToLower(letter));
		}
		else
		{
			sb.Append(letter);
		}
	}
	return sb.ToString();
}

static string KebabCaseToCamelCase(string text)
{
	StringBuilder sb = new();
	for (int i = 0; i < text.Length; i++)
	{
		if (text[i] == '-')
		{
			i++;
			sb.Append(char.ToUpper(text[i]));
		}
		else
		{
			sb.Append(text[i]);
		}
	}
	return sb.ToString();
}