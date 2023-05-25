using UnityEditor;
using UnityEngine.UIElements;

namespace SOLib.Variables.Editor
{
    [CustomEditor(typeof(ScriptableVariable<>), true)]
    public class VariableInspector : UnityEditor.Editor
    {
        public VisualTreeAsset inspectorXML;
        
        public override VisualElement CreateInspectorGUI()
        {
            // Create a new VisualElement to be the root of our inspector UI
            VisualElement myInspector = new VisualElement();

            // Load and clone a visual tree from UXML
            inspectorXML.CloneTree(myInspector);

            // Return the finished inspector UI
            return myInspector;
        }
        
    }
}