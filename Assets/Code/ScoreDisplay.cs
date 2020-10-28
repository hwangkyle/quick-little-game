using UnityEngine;

/// <summary>
/// Display the current score
/// </summary>
// ReSharper disable once UnusedMember.Global
public class ScoreDisplay : MonoBehaviour
{
    public GUIStyle Style;
    public Rect Rect = new Rect(100, 100, 300, 100);
    public bool ya = false; // this is such stupidity but it works

    internal void Start()
    {
        
    }

    /// <summary>
    /// Display the score
    /// Called once each GUI update.
    /// </summary>
    internal void OnGUI()
    {
        if(ya)
            GUI.Label(Rect, "Done", Style);
    }
}
