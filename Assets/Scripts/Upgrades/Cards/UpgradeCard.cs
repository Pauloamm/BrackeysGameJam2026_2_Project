using System;

/// <summary>
/// Immutable data describing a single upgrade offer shown on the level-up screen.
/// Carries no Unity UI types and no knowledge of which manager it came from —
/// "Apply" is a closure built by the owning provider that already knows exactly
/// which method to call on which manager instance.
/// </summary>
public class UpgradeCard
{
    public string SourceLabel { get; }
    public string Title { get; }
    public string Description { get; }
    public Action Apply { get; }

    public UpgradeCard(string sourceLabel, string title, string description, Action apply)
    {
        SourceLabel = sourceLabel;
        Title = title;
        Description = description;
        Apply = apply;
    }
}
