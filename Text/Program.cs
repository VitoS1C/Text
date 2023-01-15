
namespace Text
{
	internal class Program
	{
		static void Main()
		{
			ChooseOperation(out char operationType);

			switch (operationType)
			{
				case '1':
					CreateFile();
					break;

				case '2':
					ChooseFile();
					break;

				default:
					break;
			}

		}
		static void ChooseOperation(out char operationType)
		{
			while (true)
			{
				Console.WriteLine("Что хотите сделать?");
				Console.Write("1 - Создать файл, 2 - Получить список файлов: ");
				string userInput = Console.ReadLine() ?? "";

				if (userInput == "1" || userInput == "2")
				{
					operationType = userInput[0];
					break;
				}
				else
				{
					WrongInput("Недопустимая команда!");
				}

			}
		}
		
		static void CreateFile()
		{
			Console.Write("Введите имя файла: ");
			string path = $"{Console.ReadLine()}.txt";
			Console.WriteLine("\n");

			TextEditor textEditor = new(path);
			textEditor.WriteText();
		}

		static void ChooseFile()
		{

			DirectoryInfo directory = new(Environment.CurrentDirectory);
			FileInfo[] files = directory.GetFiles("*.txt");

			Console.WriteLine("\nВыбырите какой файл открыть\n");

			for (int i = 0; i < files.Length; i++)
			{
				if (i == files.Length - 1)
				{
					Console.Write($"{i + 1} - {files[i].Name} --> ");
				}
				else
					Console.WriteLine($"{i + 1} - {files[i].Name}");
			}

			int userInput;

			while (true)
			{
				int.TryParse(Console.ReadLine(), out userInput);

				if (userInput > files.Length - 1 || userInput == 0)
				{
					WrongInput("Такого файла нет!");
				}
				else
				{
					Console.WriteLine('\n');

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"{Path.GetFileNameWithoutExtension(files[userInput - 1].FullName)}\n");
					Console.ForegroundColor = ConsoleColor.Gray;

					TextEditor textEditor = new($"{files[userInput - 1].Name}");
					textEditor.ReadText();
				}
			}


		}

		static void WrongInput(string text)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"\n{text}\n");
			Console.ForegroundColor = ConsoleColor.Gray;
		}
	}

}
