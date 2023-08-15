using rmAlphabeticFromID3Title;

Console.OutputEncoding = System.Text.Encoding.UTF8;

foreach (string fileName in Directory.GetFiles(".", "*.flac", SearchOption.AllDirectories))
{
	using (var f = TagLib.File.Create(fileName))
	{
		string title = f.Tag.Title;

		int startIdx = 0;
		int endIdx = title.Length - 1;

		for (int i = 0; i < title.Length; i++)
		{
			if (Util.IsCharNotAlphabetic(title[i]))
			{
				startIdx = i;
				if (Util.IsNotAlphabeticBeforeBracket(title, i))
					endIdx--;
				break;
			}
		}

		for (int i = title.Length - 1; i >= 0; i--)
		{
			if (Util.IsCharNotAlphabetic(title[i]))
			{
				endIdx = i;
				if (Util.IsNotAlphabeticAfterBracket(title, i))
					endIdx++;
				break;
			}
		}

		int endLen = endIdx - startIdx + 1;

		string newTitle = title.Substring(startIdx, endLen);

		Console.WriteLine("\"{0}\"\n\t\"{1}\" -> \"{2}\"", fileName, title, newTitle);

		f.Tag.Title = newTitle;
		f.Save();
	}
}