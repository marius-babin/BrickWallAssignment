using BrickWallAssignment.Exceptions;

namespace BrickWallAssignment.Middleware;

/// <summary>
/// Middleware to validate wall size inputs
/// </summary>
public static class BrickSelectorValidator
{
    public static void Validate(int wallLength, int wallHeight)
    {
        if (wallLength <= 0 || wallHeight <= 0)
        {
            throw new InvalidSizeException(wallLength, wallHeight);
        }
    }
}