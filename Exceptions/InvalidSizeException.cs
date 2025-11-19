namespace BrickWallAssignment.Exceptions;

public class InvalidSizeException : Exception
{
    /// <summary>
    /// Exception for invalid wall size
    /// </summary>
    /// <param name="wallLength">Length of wall</param>
    /// <param name="wallHeight">Height of wall</param>
    public InvalidSizeException(int wallLength, int wallHeight)
        : base($"Invalid wall size: Length '{wallLength}' and Height '{wallHeight}' must be positive integers.")
    {
    }
}