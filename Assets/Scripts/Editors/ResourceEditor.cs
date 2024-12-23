#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Resources))]
public class ResourceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Resources resource = (Resources)target;

        // to show the basic item info
        EditorGUILayout.LabelField("Item Data", EditorStyles.boldLabel);
        resource.itemName = EditorGUILayout.TextField(resource.itemName);
        resource.itemPrefac = (GameObject)EditorGUILayout.ObjectField(resource.itemPrefac, typeof(GameObject),
            false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        resource.itemImage = (Sprite)EditorGUILayout.ObjectField(resource.itemImage, typeof(Sprite),
           false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        resource.isStackable = EditorGUILayout.Toggle("Is Stackable", resource.isStackable);
        resource.maxStack = EditorGUILayout.IntField("Max Stack", resource.maxStack);
        resource.itemDescription = EditorGUILayout.TextArea(resource.itemDescription);


        // basic resource info
        EditorGUILayout.LabelField("Resource Properties", EditorStyles.boldLabel);
        resource.resourceType = (ResourceType)EditorGUILayout.EnumPopup("Resource Type", resource.resourceType);

        // to show the type of plants to choose from
        if (resource.resourceType == ResourceType.Plant)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Type of Plant", EditorStyles.boldLabel);
            resource.plantType =(PlantType)EditorGUILayout.EnumPopup("Plant Type", resource.plantType);
        }

        // Save changes
        if (GUI.changed)
            EditorUtility.SetDirty(resource);
    }
}
#endif