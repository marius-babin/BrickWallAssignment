using System.Text;
using BrickWallAssignment.Constants;
using BrickWallAssignment.Middleware;
using BrickWallAssignment.Util;

namespace BrickWallAssignment.Function;

/// <summary>
/// Exercise 1
/// </summary>
public class GenerateWall
{
    private readonly Random _random = new();
    
    public void BuildWall(int wallLength, int wallHeight)
    {
        BrickSelectorValidator.Validate(wallLength, wallHeight);
        
        List<string> rows = [];

        for (var height = 0; height < wallHeight; height++)
        {
            // Keep track of the current length of the wall being built
            var currentLength = 0;
            char? previousChar = null;
            var rowBuilder = new StringBuilder();

            Console.Write("");
            while (currentLength < wallLength)
            {
                var brickIndex = _random.Next(0, BrickConstants.AvailableBricks.Length);
                var brickSize = BrickConstants.AvailableBricks[brickIndex];

                if (currentLength + brickSize <= wallLength)
                {
                    var brickStr = BrickCharSelector.GetRandomBrick(brickSize, previousChar);
                    previousChar = brickStr[0];
                    
                    rowBuilder.Append(brickStr);
                    
                    currentLength += brickSize;
                }
            }
            rows.Add(rowBuilder.ToString());
        }
        
        // Print in reverse
        for (var i = rows.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(rows[i]);
        }
    }
}
