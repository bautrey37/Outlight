using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
    float myFloat = 1f;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/God Mode")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        
        EditorWindow.GetWindow(typeof(MyWindow), false, "God Mode");
    }

    void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.Label("God mode settings", EditorStyles.boldLabel);

        GUILayout.Space(10);

        if (GUILayout.Button("+1000 Gold"))
        {
            Events.AddMoney(1000);
        }
        GUILayout.Space(5);

        if (GUILayout.Button("Kill all enemies"))
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy e in enemies)
            {
                GameObject.Destroy(e.gameObject);
            }
        }
        GUILayout.Space(5);

        if (GUILayout.Button("Trigger end level win"))
        {
            Events.EndLevel(true);
        }
        GUILayout.Space(5);

        if (GUILayout.Button("Trigger end level lose"))
        {
            Events.EndLevel(false);
        }
        GUILayout.Space(5);

        myFloat = EditorGUILayout.Slider("Time speed", myFloat, 0, 2);
        Time.timeScale = myFloat;
    }
}