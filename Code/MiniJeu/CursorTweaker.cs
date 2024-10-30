//https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition

class CursorTweaker
{
	public CursorTweaker()
	{
	}
	
	public void Start()
	{
		System.Console.Clear();
		System.Console.CursorVisible = false;
		Flush();
	}
	
	public void Finish()
	{
		System.Console.CursorVisible = true;
	}

	public void Write(int x, int y, char c)
	{
		System.Console.SetCursorPosition(x, y);
		//SetCursorPos(x, y);
		System.Console.Write(c);
	}

	public void Write(int x, int y, string s)
	{
		System.Console.SetCursorPosition(x, y);
		//SetCursorPos(x, y);
		System.Console.Write(s);
	}
	//string esc = "\u001b["+y+";"+x+"H";
	//System.Console.Write(esc); // \e[y;xH
	//linux https://en.wikipedia.org/wiki/ANSI_escape_code#Escape_sequences
	//windows https://stackoverflow.com/questions/32645596/how-do-i-manipulate-console-cursor-position-in-dotnet-core

	public void Flush()
	{
		System.Console.Out.Flush();
	}
}
