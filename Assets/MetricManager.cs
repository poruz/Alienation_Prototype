using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

// This class encapsulates all of the metrics that need to be tracked in your game. These may range
// from number of deaths, number of times the player uses a particular mechanic, or the total time
// spent in a level. These are unique to your game and need to be tailored specifically to the data
// you would like to collect. The examples below are just meant to illustrate one way to interact
// with this script and save data.
public class MetricManager : MonoBehaviour
{
    // You'll have more interesting metrics, and they will be better named.
    private static int[] levelTimeMetrics;
    private static int[] deathTypeMetrics;

    public Dictionary<string, int> levelNameToIndex; //Hash table - hashes level name to index

    private static MetricManager Instance;

    void Awake()
    {
        //We want to make sure that only one instance of the script
        //exists throughout the game
        //Therefore we destroy any instances created after the first instantiation
        //of the script

        if (Instance != null) //another Instance already exists
        {
            DestroyImmediate(gameObject);
        }
        else //Instance == null - First instantiation of script
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            levelNameToIndex = new Dictionary<string, int>();
            levelNameToIndex.Add("RitualLevel", 0);
            levelNameToIndex.Add("CaveLevel", 1);
            levelNameToIndex.Add("VillageLevel", 2);
            levelNameToIndex.Add("CombatLevel", 3);
            levelNameToIndex.Add("LastLevel", 4);

            levelTimeMetrics = new int[5];
            levelTimeMetrics[0] = 0;
            levelTimeMetrics[1] = 0;
            levelTimeMetrics[2] = 0;
            levelTimeMetrics[3] = 0;
            levelTimeMetrics[4] = 0;

            deathTypeMetrics = new int[3];
            deathTypeMetrics[0] = 0; //Fallen
            deathTypeMetrics[1] = 0; //Gem
            deathTypeMetrics[2] = 0; //Spikes
        }
    }

    // Public method to add to Metric 1.
    public void AddToLevelMetric(int valueToAdd, int index)
    {
        levelTimeMetrics[index] += valueToAdd;
        //Debug.Log("Reaching here\n");
        //Debug.Log(levelTimeMetrics[index]);
    }

    // Public method to add to Metric 2.
    public void AddToDeathMetric(int valueToAdd, int index)
    {
        deathTypeMetrics[index] += valueToAdd;
    }

    // Converts all metrics tracked in this script to their string representation
    // so they look correct when printing to a file.
    private string ConvertMetricsToStringRepresentation()
    {
        string metrics = "Here are my metrics:\n";

        metrics += "Ritual Level time: " + levelTimeMetrics[0].ToString() + "\n";
        metrics += "Cave Level time: " + levelTimeMetrics[1].ToString() + "\n";
        metrics += "Village Level time: " + levelTimeMetrics[2].ToString() + "\n";
        metrics += "Combat Level time: " + levelTimeMetrics[3].ToString() + "\n";
        metrics += "Last Level time: " + levelTimeMetrics[4].ToString() + "\n\n";

        metrics += "Fallen off death: " + deathTypeMetrics[0].ToString() + "\n";
        metrics += "Killed by gem: " + deathTypeMetrics[1].ToString() + "\n";
        metrics += "Killed by spikes: " + deathTypeMetrics[2].ToString() + "\n\n";

        return metrics;
    }

    // Uses the current date/time on this computer to create a uniquely named file,
    // preventing files from colliding and overwriting data.
    private string CreateUniqueFileName()
    {
        string dateTime = System.DateTime.Now.ToString();
        dateTime = dateTime.Replace("/", "_");
        dateTime = dateTime.Replace(":", "_");
        dateTime = dateTime.Replace(" ", "___");
        return "Alienation_metrics_" + dateTime + ".txt";
    }

    // Generate the report that will be saved out to a file.
    private void WriteMetricsToFile()
    {
        string totalReport = "Report generated on " + System.DateTime.Now + "\n\n";
        totalReport += "Total Report:\n";
        totalReport += ConvertMetricsToStringRepresentation();
        totalReport = totalReport.Replace("\n", System.Environment.NewLine);
        string reportFile = CreateUniqueFileName();

#if !UNITY_WEBPLAYER
        File.WriteAllText(reportFile, totalReport);
#endif
    }

    // The OnApplicationQuit function is a Unity-Specific function that gets
    // called right before your application actually exits. You can use this
    // to save information for the next time the game starts, or in our case
    // write the metrics out to a file.
    private void OnApplicationQuit()
    {
        WriteMetricsToFile();
    }
}