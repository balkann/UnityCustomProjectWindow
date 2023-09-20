using System.Globalization;
using System.IO;
using UnityEngine;

namespace Editor.CustomProjectWindow.CustomProjectWindowDetails
{
    public class FileSizeRect : CustomProjectWindowRectBase
    {
        private const float GreenSizeUpperBound = 100f;
        private const float YellowSizeUpperBound = 10000f;
        
        
        public FileSizeRect(string assetPath, Rect rect)
        {
            style = new GUIStyle
            {
                alignment = TextAnchor.MiddleRight
            };
            
            var labelWidth = 100f;
            var labelHeight = 10f;
            var labelX = rect.x + rect.width - labelWidth;
            var labelY = rect.y;
            
            labelRect = new Rect(labelX, labelY, labelWidth, labelHeight);
            
            var fileSize = GetFileSize(assetPath);
            
            if (fileSize != 0)
            {
                if (fileSize < GreenSizeUpperBound)
                {
                    style.normal.textColor = Color.green;
                }
                else if (fileSize < YellowSizeUpperBound)
                {
                    style.normal.textColor = Color.yellow;
                }
                else
                {
                    style.normal.textColor = Color.red;
                }
                fileSizeText = fileSize.ToString("N2",CultureInfo.InvariantCulture) + "KB";
            }
        }
        
        private static float GetFileSize(string assetPath)
        {
            var fileInfo = new FileInfo(assetPath);
            return fileInfo.Exists ? fileInfo.Length / 1024f : 0;
        }
    }
}