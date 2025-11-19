using System.Text;
using BrickWallAssignment.Constants;
using BrickWallAssignment.Middleware;
using BrickWallAssignment.Model;
using BrickWallAssignment.Util;

namespace BrickWallAssignment.Function;

/// <summary>
/// Exercise 3
/// </summary>
public class SuperSmartWallGenerator
{
    private readonly Random _random = new();
    
    public void BuildSuperSmartWall(int wallLength, int wallHeight)
    {
        BrickSelectorValidator.Validate(wallLength, wallHeight);

        List<int> previousJoints = [];
        HoleInfo? previousHole = null;
        List<string> rows = [];

        for (var height = 0; height < wallHeight; height++)
        {
            var isTopOrBottomLayer = height == 0 || height == wallHeight - 1;
            var currentLength = 0;
            char? previousChar = null;
            List<int> currentJoints = [];
            HoleInfo? currentHole = null;
            var rowBuilder = new StringBuilder();

            var shouldHaveHole = !isTopOrBottomLayer;
            
            while (currentLength < wallLength)
            {
                // Conditions: row must not be top or bottom, no current hole, enough space left
                if (shouldHaveHole && currentHole == null && currentLength > 0)
                {
                    var holeSize = _random.Next(1, 6); // Random hole size
                    
                    if (HolePlacementValidator.Validate(currentLength, holeSize, wallLength))
                    {
                        var holeEnd = currentLength + holeSize;
                        rowBuilder.Append(new string(' ', holeSize));
                        currentHole = new HoleInfo
                        {
                            Start = currentLength,
                            End = holeEnd
                        };
                        
                        currentLength += holeSize;
                        
                        if (currentLength < wallLength)
                            currentJoints.Add(currentLength);
                        
                        continue;
                    }
                }

                var brickSize = BrickConstants.AvailableBricks[_random.Next(BrickConstants.AvailableBricks.Length)];
                var brickEnd = currentLength + brickSize;
                
                if (brickEnd <= wallLength && 
                    BrickPlacementValidator.IsValidBrickPlacement(currentLength, brickSize, previousJoints) &&
                    BrickOnHoleValidator.CanPlaceBrickOverHole(currentLength, brickSize, previousHole))
                {
                    var brickStr = BrickCharSelector.GetRandomBrick(brickSize, previousChar);
                    previousChar = brickStr[0];
                    //Console.Write($"{brickSize}{brickStr}");
                    rowBuilder.Append(brickStr);
                    currentLength += brickSize;
                    
                    if (brickEnd < wallLength)
                        currentJoints.Add(brickEnd);
                }
            }
            
            rows.Add(rowBuilder.ToString());
            previousJoints = currentJoints;
            previousHole = currentHole;
        }
        
        // Print in reverse, because we print in reverse there are instance were function runs in infinite loop so it won't print anything
        for (var i = rows.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(rows[i]);
        }
    }
}