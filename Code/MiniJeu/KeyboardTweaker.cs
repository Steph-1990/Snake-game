//https://stackoverflow.com/questions/5620603/non-blocking-read-from-standard-i-o-in-c-sharp/5620647#5620647

using ConsoleKey = System.ConsoleKey;

class KeyboardTweaker
{
	
    public const ConsoleKey NO_EVENT = ConsoleKey.NoName;//implicitly static because const

	public const ConsoleKey KeyEscape = ConsoleKey.Escape;
	public const ConsoleKey KeyUp = ConsoleKey.Z;
	public const ConsoleKey KeyRight = ConsoleKey.D;
	public const ConsoleKey KeyDown = ConsoleKey.S;
	public const ConsoleKey KeyLeft = ConsoleKey.Q;
	 //... add whatever you need
	 //see https://docs.microsoft.com/en-us/dotnet/api/system.consolekey
        
	public KeyboardTweaker()
	{
	}

	public ConsoleKey NextEvent()
	{
		if(!System.Console.KeyAvailable)
		{
			return NO_EVENT;
		}
		System.ConsoleKeyInfo key = System.Console.ReadKey(true);
		return key.Key;
	}
}
