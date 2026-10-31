namespace CSharpPracticum.Common;

/// <summary>
/// Defines a practical assignment that can be run from the application menu.
/// </summary>
public interface ITask
{
    /// <summary>
    /// Gets the assignment title.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Gets the assignment description.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Gets the assignment requirements.
    /// </summary>
    string[] Requirements { get; }

    /// <summary>
    /// Runs the assignment.
    /// </summary>
    void Run();
}
