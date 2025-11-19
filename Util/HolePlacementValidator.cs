namespace BrickWallAssignment.Util;

public static class HolePlacementValidator
{
    /// <summary>
    /// Validates if a hole can be placed at the given position
    /// </summary>
    public static bool Validate(int holeStart, int holeSize, int wallLength)
    {
        // Hole cannot start or end at the sides
        var holeEnd = holeStart + holeSize;
        return holeStart > 0 && holeEnd < wallLength;
    }
}