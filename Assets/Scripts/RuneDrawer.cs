using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

// IngredientDrawerUIE
[CustomPropertyDrawer(typeof(Rune.Parameter<>))]
public class IngredientDrawerUIE : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        // Create property container element.
        var container = new VisualElement();

        // Create property fields.
        var nameField = new PropertyField(property.FindPropertyRelative("Name"));
        var valueField = new PropertyField(property.FindPropertyRelative("Value"));

        // Add fields to the container.
        container.Add(nameField);
        container.Add(valueField);

        return container;
    }
}
