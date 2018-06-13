
namespace GameUI
{
    using UnityEditor;
    using UnityEditor.SceneManagement;

    public class EditorSceneHelper
    {
        [MenuItem("Tools/OpenScene/Root %#R")]
        public static void OpenRootScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Root.unity");
        }
        [MenuItem("Tools/OpenScene/EditorUI %#E")]
        public static void OpenEditorUIScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/EditorUI.unity");
        }
    }
}
