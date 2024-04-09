using UnityEngine;
using UnityEditor;

public class ItemEditor : Editor
{
    [CustomEditor(typeof(ItemSO))]
    public class ObjetoObtenibleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ItemSO itemSo = (ItemSO)target;

            if (itemSo.ItemImage != null)
            {
                GUILayout.Label("Imagen del Item:");
                Rect rect = GUILayoutUtility.GetRect(25, 300);
                EditorGUI.DrawTextureTransparent(rect, itemSo.ItemImage.texture);
            }
        }
    }
}
