namespace GameUI
{
    using UnityEditor;
    //[CustomEditor(typeof(MonoUI), true)]
    public class MonoUIEditor : Editor
    {
        SerializedProperty m_Style;
        public void OnEnable()
        {
            m_Style = serializedObject.FindProperty("style");
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.PropertyField(m_Style);
            EditorGUILayout.EndVertical();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
