using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class RenameWindow : EditorWindow{
    public string captionText { get; set; }
    public string buttonText { get; set; }
    public string newName { get; set; }
    public System.Action<string> OnClickButtonDelegate { get; set; }

    private void OnGUI()
    {
        newName = EditorGUILayout.TextField (captionText, newName);
        if(GUILayout.Button(buttonText))
        {
            if(OnClickButtonDelegate != null)
            {
                OnClickButtonDelegate.Invoke(newName.Trim());
            }

            Close();
            GUIUtility.ExitGUI();
        }
    }
}

public class NestedAnimationCreator : MonoBehaviour {

    [MenuItem("Assets/Create/NestedAnimation")]
    public static void Create(){
        AnimatorController selectedAnimatorController = Selection.activeObject as AnimatorController;

        if (selectedAnimatorController == null) return;

        // 생성할 애니매이션 클립의 이름을 입력할 대화상자를 연다.
        RenameWindow renameWindow = EditorWindow.GetWindow<RenameWindow>("Create Nested Animation");

        renameWindow.captionText = "New AnimationName";
        renameWindow.newName = "New Clip";
        renameWindow.buttonText = "Create";

        renameWindow.OnClickButtonDelegate = (string newName) =>
        {
            if (string.IsNullOrEmpty(newName)) return;

            AnimationClip animationClip = AnimatorController.AllocateAnimatorClip(newName);

            AssetDatabase.AddObjectToAsset(animationClip, selectedAnimatorController);

            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(selectedAnimatorController));
        };
    }

    [MenuItem("Assets/Delete Sub Asset")]
    public static void Delete()
    {
        Object[] selectedAssets = Selection.objects;
        if (selectedAssets.Length < 1) return;

        foreach (object obj in selectedAssets)
        {
            if (AssetDatabase.IsSubAsset((UnityEngine.Object)obj))
            {
                {
                    string path = AssetDatabase.GetAssetPath((UnityEngine.Object)obj);
                    DestroyImmediate((UnityEngine.Object)obj, true);
                    AssetDatabase.ImportAsset(path);
                }
            }
        }
    }
}

