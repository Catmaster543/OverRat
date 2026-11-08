using UnityEngine;

public class GhoulNPC : MonoBehaviour
{
    public string pastText;
    public MainSceneFlipper flipper;
    public PreGameManager preGameManager;
    public Speaker ghoulSpeaker;

    public void Reaction()
    {
        Line[] newLines = new Line[1];
        newLines[0] = new Line();
        newLines[0].text = pastText;
        newLines[0].activeSpeaker = ghoulSpeaker;
        ghoulSpeaker.lines = newLines;
        flipper.objectiveText.text = "● Collect ingredients on the surface.";
        preGameManager.StartThePreGame();
    }
}
