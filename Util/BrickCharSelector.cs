namespace BrickWallAssignment.Util;

public static class BrickCharSelector
{
    private static readonly char[] Chars = ['|', 'X', '-', '.'];
    private static readonly Random Random = new();
    
    public static string GetRandomBrick(int brickSize, char? previousChar = null)
    {
        var availableChars = previousChar.HasValue
            ? Chars.Where(c => c != previousChar.Value).ToArray()
            : Chars;

        var brickChar = availableChars[Random.Next(availableChars.Length)];
        return new string(brickChar, brickSize);
    }

}