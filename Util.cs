using System.Text.RegularExpressions;

namespace rmAlphabeticFromID3Title
{
	internal static class Util
	{
		internal static bool IsCharNotAlphabetic(char c)
			=> !Regex.IsMatch(c.ToString(), @"^([a-z]|\s|,|\.|'|\(|\)|-)$", RegexOptions.IgnoreCase);

		internal static bool IsNotAlphabeticBeforeBracket(string s, int pos)
		{
			if (pos == 0) return false;
			if (s[pos - 1] != ')' && s[pos - 1] != '(') return false;
			// if [pos - 1] char (before bracket) is NOT alphabetic, that bracket shouldn't deleted:
			//     return true
			if (IsCharNotAlphabetic(s[pos])) return true;
			else return false;
		}

		internal static bool IsNotAlphabeticAfterBracket(string s, int pos)
		{
			if (pos == s.Length - 1) return false;
			if (s[pos + 1] != ')' && s[pos + 1] != '(') return false;
			if (IsCharNotAlphabetic(s[pos])) return true;
			else return false;
		}
	}
}
