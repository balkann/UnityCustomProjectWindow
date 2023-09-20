using Editor.CustomProjectWindow.CustomProjectWindowDetails;
using UnityEditor;
using UnityEngine;

namespace Editor.CustomProjectWindow
{
    public abstract class ProjectWindowCallbackExtensions
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorApplication.projectWindowItemOnGUI += OnOpenAsset;
        }
        
        private static void OnOpenAsset(string guid, Rect rect)
        {
            if (!ShouldShow(rect))
                return;
            
            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
            if (string.IsNullOrEmpty(assetPath))
                return;
            
            if (assetPath.Contains(".cs"))
            {
                var csSize = new ScriptSizeRect(assetPath, rect);
                GUI.Label(csSize.labelRect, csSize.fileSizeText, csSize.style);
            }
            else
            {
                var fileSizeRect = new FileSizeRect(assetPath, rect);
                GUI.Label(fileSizeRect.labelRect, fileSizeRect.fileSizeText, fileSizeRect.style);
            }
            
        }

        private static bool ShouldShow(Rect rect)
        {
            return rect.width > 100 
                   && !Application.isPlaying
                   && Event.current.type == EventType.Repaint;
        }
    }
}
    
