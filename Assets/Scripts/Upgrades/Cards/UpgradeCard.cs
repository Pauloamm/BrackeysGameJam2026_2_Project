using System;
using UnityEngine;

public class UpgradeCard
{
    public string SourceLabel { get; }
    public string Title { get; }
    public string Description { get; }
    public Sprite Icon { get; }
    public Action Apply { get; }

    public UpgradeCard(string sourceLabel, string title, string description, Sprite icon, Action apply)
    {
        SourceLabel = sourceLabel;
        Title = title;
        Description = description;
        Icon = icon;
        Apply = apply;
    }
}