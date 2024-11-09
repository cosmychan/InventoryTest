#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Weapon weapon = (Weapon)target;

        // to show the basic item info
        EditorGUILayout.LabelField("Item Data", EditorStyles.boldLabel);
        weapon.itemName = EditorGUILayout.TextField(weapon.itemName);
        weapon.itemPrefac = (GameObject)EditorGUILayout.ObjectField(weapon.itemPrefac, typeof(GameObject),
            false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        weapon.itemDescription = EditorGUILayout.TextArea(weapon.itemDescription);


        // basic weapon info
        EditorGUILayout.LabelField("Weapon Properties", EditorStyles.boldLabel);
        weapon.weaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapon.weaponType);
        weapon.weaponDamage = EditorGUILayout.IntField("Damage", weapon.weaponDamage);
        weapon.useWeaponDurability = EditorGUILayout.Toggle("Use Durability", weapon.useWeaponDurability);

        // to show amount for durability if useDurability is true
        if (weapon.useWeaponDurability == true)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Durability Amount", EditorStyles.boldLabel);
            weapon.weaponDurability = EditorGUILayout.IntField("Amount", weapon.weaponDurability);
        }

        // Save changes
        if (GUI.changed)
            EditorUtility.SetDirty(weapon);
    }
}
#endif