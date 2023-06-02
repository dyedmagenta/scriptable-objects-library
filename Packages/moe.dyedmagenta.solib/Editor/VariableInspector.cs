using SOLib.Variables;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using static SOLib.Editor.AssetPaths;

namespace SOLib.Editor
{
    [CustomEditor(typeof(ScriptableVariable<>), true)]
    public class VariableInspector : UnityEditor.Editor
    {
        private SerializedProperty initializeProperty;
        private SerializedProperty initialValueProperty;
        private SerializedProperty valueProperty;

        private bool scriptableVariablePropertiesCreated = false;

        public override VisualElement CreateInspectorGUI()
        {
            var container = new VisualElement();
            var iterator = serializedObject.GetIterator();
            scriptableVariablePropertiesCreated = false;

            initializeProperty = serializedObject.FindProperty("initialize");
            initialValueProperty = serializedObject.FindProperty("initialValue");
            valueProperty = serializedObject.FindProperty("value");

            if (!iterator.NextVisible(true))
            {
                return container;
            }

            do
            {
                var isPropertyAdded = AddDefaultMScriptProperty(iterator, container);

                if (!isPropertyAdded)
                {
                    isPropertyAdded = CreateScriptableVariableFields(iterator, container);
                }

                if (isPropertyAdded)
                {
                    continue;
                }

                //Add other fields as default
                var propertyField = new PropertyField(iterator.Copy()) { name = "PropertyField:" + iterator.propertyPath };
                container.Add(propertyField);
            } while (iterator.NextVisible(false));

            return container;
        }

        private bool AddDefaultMScriptProperty(SerializedProperty iterator, VisualElement container)
        {
            if (iterator.propertyPath != "m_Script" || serializedObject.targetObject == null)
            {
                return false;
            }

            var propertyField = new PropertyField(iterator.Copy()) { name = "PropertyField:" + iterator.propertyPath };
            propertyField.SetEnabled(value: false);
            container.Add(propertyField);
            return true;
        }

        private bool CreateScriptableVariableFields(SerializedProperty iterator, VisualElement container)
        {
            if (!IsIteratorPropertyScriptableVariableProperty(iterator))
            {
                return false;
            }

            if (!CanCreateScriptableVariableProperties())
            {
                return true;
            }

            var initializeField = new PropertyField(initializeProperty);
            container.Add(initializeField);

            if (initialValueProperty.propertyType.Equals(SerializedPropertyType.String))
            {
                AddMultilineTextVariables(container, initializeField, initializeProperty);
            }
            else
            {
                var initialValueField = new PropertyField(initialValueProperty);
                initialValueField.style.display = initializeProperty.boolValue ? DisplayStyle.Flex : DisplayStyle.None;
                initializeField.RegisterCallback<ChangeEvent<bool>>(changeEvent =>
                {
                    initialValueField.style.display = changeEvent.newValue ? DisplayStyle.Flex : DisplayStyle.None;
                });
                container.Add(initialValueField);

                var valueField = new PropertyField(valueProperty);
                container.Add(valueField);
            }

            scriptableVariablePropertiesCreated = true;
            return true;
        }

        private void AddMultilineTextVariables(VisualElement container, PropertyField initializeField, SerializedProperty initializeProperty)
        {
            var initialValueFieldLabel = new Label(initialValueProperty.displayName);
            initialValueFieldLabel.style.marginLeft = new StyleLength(3);
            container.Add(initialValueFieldLabel);

            var initialValueField = new TextField
            {
                name = "PropertyField:" + initialValueProperty.propertyPath,
                multiline = true,
            };
            initialValueField.style.marginBottom = new StyleLength(3);
            initialValueField.BindProperty(initialValueProperty);
            container.Add(initialValueField);

            initialValueFieldLabel.style.display = initializeProperty.boolValue ? DisplayStyle.Flex : DisplayStyle.None;
            initialValueField.style.display = initializeProperty.boolValue ? DisplayStyle.Flex : DisplayStyle.None;

            initializeField.RegisterCallback<ChangeEvent<bool>>(changeEvent =>
            {
                initialValueFieldLabel.style.display = changeEvent.newValue ? DisplayStyle.Flex : DisplayStyle.None;
                initialValueField.style.display = changeEvent.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            });

            var valueFieldLabel = new Label(valueProperty.displayName);
            valueFieldLabel.style.marginLeft = new StyleLength(3);
            container.Add(valueFieldLabel);

            var valueField = new TextField { name = "PropertyField:" + valueProperty.propertyPath, multiline = true };
            valueField.style.marginBottom = new StyleLength(3);
            valueField.BindProperty(valueProperty);
            container.Add(valueField);
        }

        private bool CanCreateScriptableVariableProperties()
        {
            return !scriptableVariablePropertiesCreated && serializedObject.targetObject != null;
        }

        private bool IsIteratorPropertyScriptableVariableProperty(SerializedProperty iterator)
        {
            return iterator.propertyPath == "initialize" || iterator.propertyPath == "initialValue" || iterator.propertyPath == "value";
        }
    }
}