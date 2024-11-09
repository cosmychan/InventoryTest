#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Armor))]
public class ArmorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Armor armor = (Armor)target;

        // to show the basic item info
        EditorGUILayout.LabelField("Item Data", EditorStyles.boldLabel);
        armor.itemName = EditorGUILayout.TextField(armor.itemName);
        armor.itemPrefac = (GameObject)EditorGUILayout.ObjectField(armor.itemPrefac, typeof(GameObject),
            false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        armor.itemDescription = EditorGUILayout.TextArea(armor.itemDescription);


        // basic armor info
        EditorGUILayout.LabelField("Armor Properties", EditorStyles.boldLabel);
        armor.armorType = (ArmorType)EditorGUILayout.EnumPopup("Armor Type", armor.armorType);
        armor.shieldAmount = EditorGUILayout.IntField("Shield/Protection Amount", armor.shieldAmount);
        armor.useArmorDurability = EditorGUILayout.Toggle("Use Durability", armor.useArmorDurability);

        // to show amount for durability if useDurability is true
        if (armor.useArmorDurability == true)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Durability Amount", EditorStyles.boldLabel);
            armor.armorDurability = EditorGUILayout.IntField("Amount", armor.armorDurability);
        }

        // Save changes
        if (GUI.changed)
            EditorUtility.SetDirty(armor);
    }
}
#endif