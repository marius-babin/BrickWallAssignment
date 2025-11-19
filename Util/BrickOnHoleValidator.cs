using BrickWallAssignment.Model;

namespace BrickWallAssignment.Util;

/// <summary>
/// Validates if a brick can be placed over a hole according to the rules.
/// </summary>
public static class BrickOnHoleValidator
{
    public static bool CanPlaceBrickOverHole(int brickStart, int brickSize, HoleInfo? previousHole)
    {
        // No hole below, brick can be placed anywhere
        if (previousHole == null)
            return true;

        var brickEnd = brickStart + brickSize;
        var holeStart = previousHole.Value.Start;
        var holeEnd = previousHole.Value.End;
        
        // If brick overlaps hole, we will go to support checks
        var overlaps = brickStart < holeEnd && brickEnd > holeStart;
        if (!overlaps)
            return true;

        // Must have support at both ends
        var hasStartSupport = brickStart < holeStart;
        var hasEndSupport = brickEnd > holeEnd;
        
        if (!hasStartSupport || !hasEndSupport)
            return false;

        // Calculate knobs supporting the brick
        var supportAtStart = holeStart - brickStart;
        var supportAtEnd = brickEnd - holeEnd;
        var totalSupport = supportAtStart + supportAtEnd;
        
        // Amount of air below the brick
        var airBelow = Math.Max(0, Math.Min(brickEnd, holeEnd) - Math.Max(brickStart, holeStart));
        
        // The air below must not be bigger than the support
        return airBelow <= totalSupport;
    }
}