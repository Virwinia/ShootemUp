using UnityEngine;
using UnityEditor;

public class ToolDeleteSaveData : EditorWindow
{
    [MenuItem("Tools/EditorPrefs/Delete SavedDataPrefs")]
    private static void DeletePlayerData()
    {
        PlayerPrefs.DeleteKey(StaticValues.SCOREDATA_KEY);
    }

    //-------------------
    // REMOVE ALL THE DATA PREFS IN GAME
    //-------------------
    // [MenuItem("Tools/EditorPrefs/Delete SaveDataPrefs (All)")]
    // private static void DeleteAllPlayerPrefs()
    // {
    //     PlayerPrefs.DeleteAll();
    // }


    //-------------------
    // CREATE A WINDOW TO REMOVE THE KEY YOU WANT -- YOU MUST WRITE THE NAME OF SUCH KEY
    //-------------------
    // string editorPref = "ShootemUp_KeyName";

    // [MenuItem("Tools/EditorPrefs/Clear Key Preference")]
    // static void Init()
    // {
    //     ToolDeleteSaveData window = GetWindowWithRect<ToolDeleteSaveData>(new Rect(0, 0, 250, 50));
    //     window.Show();
    // }

    // void OnGUI()
    // {
    //     editorPref = EditorGUILayout.TextField("Editor key name:", editorPref);
    //     if (GUILayout.Button("Delete"))
    //         if (EditorPrefs.HasKey(editorPref))
    //         {
    //             if (EditorUtility.DisplayDialog("Removing " + editorPref + "?",
    //                 "Are you sure you want to " +
    //                 "delete the editor key " +
    //                 editorPref + "?, This action cant be undone",
    //                 "Yes",
    //                 "No"))
    //                 EditorPrefs.DeleteKey(editorPref);
    //         }
    //         else
    //         {
    //             EditorUtility.DisplayDialog("Could not find " + editorPref,
    //                 "Seems that " + editorPref +
    //                 " does not exists or it has been deleted already, " +
    //                 "check that you have typed correctly the name of the key.",
    //                 "Ok");
    //         }
    // }

}
