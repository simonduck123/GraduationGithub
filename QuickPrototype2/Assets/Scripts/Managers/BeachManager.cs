using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;

    public TimelineManager timelineManager;

    private void Start()
    {
        actionMap = new Dictionary<string, System.Action>();

        actionMap.Add("/beach/cam/start", timelineManager.PlayTimeline);
        actionMap.Add("/beach/cam/restart", timelineManager.RestartTimeline);
        actionMap.Add("/beach/cam/pause", timelineManager.PauseTimeline);
        actionMap.Add("/beach/cam/skip", timelineManager.SkipTimeline);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
