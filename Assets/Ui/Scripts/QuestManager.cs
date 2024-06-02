using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
   public static QuestManager Instance {  get;  set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public List<Quest> allActiveQuests;
    public List<Quest> allCompletedQuests;

    [Header("QuestMenu")]
    public GameObject questMenu;
    public bool isQuestMenuOpen;

    public GameObject activeQuestPrefab;
    public GameObject completedQuestPrefab;

    public GameObject questMenucontent;

    [Header("QuestTracker")]
    public GameObject questTrackerContent;
    public GameObject trackerRowPrefab;

    public List<Quest> allTrackedQuests;

    public void TrackQuest(Quest quest)
    {
        allTrackedQuests.Add(quest);
        RefreshTrackerList();
    }

    public void UnTrackQuest(Quest quest)
    {
        allTrackedQuests.Remove(quest);
        RefreshTrackerList();
    }

    private void RefreshTrackerList()
    {
        // Destroying the previous list
        foreach (Transform child in questTrackerContent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Quest trackedQuest in allTrackedQuests)
        {
            GameObject trackerPrefab = Instantiate(trackerRowPrefab, Vector3.zero, Quaternion.identity);
            trackerPrefab.transform.SetParent(questTrackerContent.transform, false);

            TrackerRow tRow = trackerPrefab.GetComponent<TrackerRow>();

            tRow.questName.text = trackedQuest.questName;
            tRow.description.text = trackedQuest.questDescription;

            if (trackedQuest.info.secondRequirmentItem != "") // if we have 2 requirements
            {
                tRow.requirements.text = $"{trackedQuest.info.firstRequirmentItem}" + "0/" + $"{trackedQuest.info.firstRequirementAmount}\n" +
               $"{trackedQuest.info.secondRequirmentItem}" + "0/" + $"{trackedQuest.info.secondRequirementAmount}\n";
            }
            else // if we have only one
            {
                tRow.requirements.text = $"{trackedQuest.info.firstRequirmentItem}" + "0/" + $"{trackedQuest.info.firstRequirementAmount}\n";
            }


        }
    }
    public void AddActiveQuest(Quest quest)
    {
        allActiveQuests.Add(quest);
        TrackQuest(quest);
    }

    public void MarkQuestCompleted(Quest quest)
    {
        UnTrackQuest(quest);
    }
}
