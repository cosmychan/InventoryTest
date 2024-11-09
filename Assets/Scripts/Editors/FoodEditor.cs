#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Food))]
public class FoodEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Food food = (Food)target;

        // to show the basic item info
        EditorGUILayout.LabelField("Item Data", EditorStyles.boldLabel);
        food.itemName = EditorGUILayout.TextField(food.itemName);
        food.itemPrefac = (GameObject)EditorGUILayout.ObjectField(food.itemPrefac, typeof(GameObject),
            false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        food.itemImage = (Sprite)EditorGUILayout.ObjectField(food.itemImage, typeof(Sprite),
           false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        food.isStackable = EditorGUILayout.Toggle("Is Stackable", food.isStackable);
        food.itemDescription = EditorGUILayout.TextArea(food.itemDescription);


        // basic food info
        EditorGUILayout.LabelField("Food Properties", EditorStyles.boldLabel);
        food.foodType = (FoodType)EditorGUILayout.EnumPopup("Food Type", food.foodType);
        food.fullAmount = EditorGUILayout.IntField("Nourishment Value", food.fullAmount);

        // to show the buff only if food type = complex
        if (food.foodType == FoodType.Complex)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Buff Properties", EditorStyles.boldLabel);
            food.buffType = (BuffType)EditorGUILayout.EnumPopup("Buff Type", food.buffType);
            food.buffAmount = EditorGUILayout.IntField("Buff Amount", food.buffAmount);
        }

        // to show the buff only if food type = poison
        if (food.foodType == FoodType.Poison)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Debuff Properties", EditorStyles.boldLabel);
            food.debuffType = (DebuffType)EditorGUILayout.EnumPopup("Debuff Type", food.debuffType);
            food.debuffAmount = EditorGUILayout.IntField("Debuff Amount", food.debuffAmount);
        }

        // Save changes
        if (GUI.changed)
            EditorUtility.SetDirty(food);
    }
}
#endif

