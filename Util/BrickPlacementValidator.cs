namespace BrickWallAssignment.Util;

public static class BrickPlacementValidator
{
    /// <summary>
    /// Validate if a brick can be placed. The brick cannot end at a previous joint.
    /// </summary>
    public static bool IsValidBrickPlacement(int brickStart, int brickSize, List<int> previousJoints)
    {
        var brickEnd = brickStart + brickSize;
        return !previousJoints.Contains(brickEnd);
    }
}