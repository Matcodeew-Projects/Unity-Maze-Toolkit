using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Matcodeew.Maze_Toolkit
{
    internal class ToolkitEditorWindow : EditorWindow
    {
        private GridPreview gridPreview;
        private GridSettings gridSettings;

        [MenuItem("Tools/Maze Toolkit")]
        public static void OpenWindow()
        {
            ToolkitEditorWindow window =
                GetWindow<ToolkitEditorWindow>();

            window.titleContent =
                new GUIContent("Maze Toolkit");
        }

        public void CreateGUI()
        {
            if (!LoadAsset(
                "Assets/Script/Editor/Window/EditorWindowVisualTree.uxml",
                out VisualTreeAsset editorWindow))
            {
                return;
            }

            editorWindow.CloneTree(rootVisualElement);

            MazeEditorContext context =
                new MazeEditorContext(10, 10, 25f);


            VisualElement gridPreviewRoot =
                rootVisualElement.Q<VisualElement>("GridPreview");
            gridPreview =
                new GridPreview(gridPreviewRoot, context);


            VisualElement gridSettingsRoot =
               rootVisualElement.Q<VisualElement>("GridSettings");

            gridSettings =
                new GridSettings(context, gridSettingsRoot);

        }

        private bool LoadAsset(string path, out VisualTreeAsset asset)
        {
            asset =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);

            if (asset != null)
                return true;

            Debug.LogError(
                $"Maze Toolkit: Unable to load asset at {path}");

            return false;
        }
    }
}