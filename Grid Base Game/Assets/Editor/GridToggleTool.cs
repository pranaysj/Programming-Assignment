using UnityEngine;
using UnityEditor;

public class GridToggleWindow : EditorWindow
{
    const int width = 10;
    const int height = 10;

    bool[] grid = new bool[width * height];

    private float cellSize = 40f;

    private GridData targetAsset;

    [MenuItem("Window/Grid Toggle/Grid Tool")]
    public static void OpenWindow()
    {
        GetWindow<GridToggleWindow>("Grid Tool");
    }

    void OnEnable()
    {
        var multiple = width * height;

        if (grid == null || grid.Length != multiple)
        {
            grid = new bool[multiple];
        }
    }

    void OnGUI()
    {
        var saveButton = GUILayout.Button("Save to Asset", GUILayout.Height(28));
        var clearButon = GUILayout.Button("Clear", GUILayout.Height(28));

        if (clearButon) 
            ClearGrid();

        if (saveButton)
            SaveToAsset();
       

        EditorGUILayout.Space();

        for (int y = 0; y < height; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < width; x++)
            {
                int index = y * width + x;

                // Visual hint: use different GUIStyle to make button square
                bool current = grid[index];

                // Use Toggle styled as button for on/off look
                bool newVal = GUILayout.Toggle(current, GUIContent.none, "Button", GUILayout.Width(cellSize), GUILayout.Height(cellSize));

                if (newVal != current)
                {
                    grid[index] = newVal;
                    // Mark window dirty so it repaints
                    Repaint();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    void ClearGrid()
    {
        for (int i = 0; i < grid.Length; i++)
            grid[i] = false;

        Repaint();
    }

    void SaveToAsset()
    {
        if (targetAsset == null)
        {
            // Create a new asset if none assigned
            string path = EditorUtility.SaveFilePanelInProject("Create GridData", "GridDataSO", "asset", "Save GridData asset");

            if (string.IsNullOrEmpty(path)) 
                return;

            targetAsset = CreateInstance<GridData>();
            AssetDatabase.CreateAsset(targetAsset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(targetAsset);
        }

        // copy data
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                targetAsset.Set(x, y, grid[y * width + x]);

        EditorUtility.SetDirty(targetAsset);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
