namespace BrickWallAssignment.Util;

public static class BrickPlacementValidator
{
    /// <summary>
    /// Validate if a brick can be placed. The brick cannot end at a previous joint.
    /// </summary>
    public static bool IsValidBrickPlacement(int brickEnd, List<int> previousJoints)
    {
        return !previousJoints.Contains(brickEnd);
    }
}