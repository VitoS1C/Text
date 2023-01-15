
namespace Text
{
	internal class TextEditor
	{
		public string Path { get; }

		public TextEditor(string path)
		{
			Path = path;
		}

		public async void WriteText()
		{
			Console.WriteLine("Вводите текст. Чтобы закончить печать, наберите \"Quit\"");

			FileStream fs = new(Path, FileMode.OpenOrCreate);
			fs.Close();

			while (true)
			{
				using StreamWriter streamWriter = new(Path, true);
				string userInput = Console.ReadLine() ?? "";

				if (userInput.ToLower() == "quit")
				{
					break;
				}
				else
				{
					await streamWriter.WriteLineAsync(userInput);

				}

			}
			
		}

		public void ReadText()
		{
			string[] text = File.ReadAllLines(Path);

			for (int i = 0; i < text.Length; i++)
			{
				Console.WriteLine(text[i]);
			}

		}

	}
}
