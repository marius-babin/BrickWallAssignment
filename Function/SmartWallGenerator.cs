using System.Text;
using BrickWallAssignment.Constants;
using BrickWallAssignment.Middleware;
using BrickWallAssignment.Util;

namespace BrickWallAssignment.Function;

/// <summary>
/// Exercise 2
/// </summary>
public class SmartWallGenerator
{
    private readonly Random _random = new();
    
    public void BuildSmartWall(int wallLength, int wallHeight)
    {
        BrickSelectorValidator.Validate(wallLength, wallHeight);
        
        List<int> previousJoints = [];
        List<string> rows = [];
        
        for (var height = 0; height < wallHeight; height++)
        {
            var currentLength = 0;
            char? previousChar = null;
            List<int> currentJoints = [];
            var rowBuilder = new StringBuilder();
        
            while (currentLength < wallLength)
            {
                var brickIndex = _random.Next(0, BrickConstants.AvailableBricks.Length);
                var brickSize = BrickConstants.AvailableBricks[brickIndex];
                
                var brickEnd = currentLength + brickSize;
                if (brickEnd <= wallLength && BrickPlacementValidator.IsValidBrickPlacement(brickEnd, previousJoints))
                {
                    var brickStr = BrickCharSelector.GetRandomBrick(brickSize, previousChar);
                    previousChar = brickStr[0];
                    
                    rowBuilder.Append(brickStr);
                    
                    currentLength += brickSize;
        
                    // Wall end is not a joint
                    if (brickEnd < wallLength)
                        currentJoints.Add(brickEnd);
                }
            }
            rows.Add(rowBuilder.ToString());
            
            previousJoints = currentJoints;
        }
        
        // Print in reverse
        for (var i = rows.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(rows[i]);
        }
    }
}