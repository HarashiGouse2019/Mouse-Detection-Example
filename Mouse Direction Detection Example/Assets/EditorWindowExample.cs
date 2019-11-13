using UnityEngine;
using UnityEditor;

public class EditorWindowExample : EditorWindow
{
    public string m_string = "Hello World";
    public float value = 10f;

    [MenuItem("Window/Sample Studio")]
    public static void ShowWindow()
    {
        GetWindow<EditorWindowExample>("Sample Studio");
    }

    private void OnGUI()
    {
        //Window code here!!!!
        
        Debug.Log(value);
        EditorGUILayout.BeginScrollView(new Vector3(0,0), true, false);
        
        GUILayout.Label("This is a label", EditorStyles.boldLabel);
        m_string = EditorGUILayout.TextField("Name", m_string);
        value = GUILayout.HorizontalSlider(value, 0, 50);
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Press Me!!"))
            Debug.Log("Button was pressed");
    }
}
