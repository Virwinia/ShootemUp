/*
    CSV converter/importer file to Unity--> It will read the CSV file to create new npcs scriptable objects.
    This script MUST BE in the same folder than the script to generate (NpcSO).
    When generating the Build, this script MUST BE in Editor folder.
   
*/
using UnityEngine;
using UnityEditor;
using System.IO;

public class CsvToNpcSO : MonoBehaviour
{
    static string npcCSVPath = "/Assets/Editor/CSV/Npc.csv";  // Where in my Project the csv file is located .

    [MenuItem("Tools/CSVImporter/Generate Npcs")]  // Create a new option in Unity Menu called Tools, which will hold the csv conversor.
    public static void GenerateNpcs() // This method says what will do the tool when it is clicked on.
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + npcCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            if (splitData.Length != 5)  // Error note if the array lenght does not match.
            {
                Debug.LogWarning("<b>CSVtoItem script says:</b> " + s + " does not have 4 values");
                return;
            }

            NpcSO npc = ScriptableObject.CreateInstance<NpcSO>();
            npc.id = int.Parse(splitData[0]);   // Because the array is for strings, we need to cast the integer --> Conver text from csv to number int in Unity.

            // Ship Data
            npc.npcName = splitData[1];
            // npc.level = int.Parse(splitData[2]);
            // npc.weight = int.Parse(splitData[3]);
            npc.amountCannons = int.Parse(splitData[4]);
            npc.fireRate = int.Parse(splitData[5]);
            //Health
            npc.health = int.Parse(splitData[6]);
            npc.score = int.Parse(splitData[7]);
            npc.chanceToLoot = float.Parse(splitData[8]);
            //Movement ---> REVIEW DATA -IMPROVE SYSTEM
            npc.speed = float.Parse(splitData[9]);
            npc.amplitude = float.Parse(splitData[10]);
            npc.alphaDelta = float.Parse(splitData[11]);


            AssetDatabase.CreateAsset(npc, $"Assets/Scripts/ScriptableObject/Killables/{npc.npcName}.asset");   // Indicate where the new generated assets will be saved. 
        }
        AssetDatabase.SaveAssets();
    }
}
