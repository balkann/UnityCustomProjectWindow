using System.IO;
using UnityEngine;

namespace Editor.CustomProjectWindow.CustomProjectWindowDetails
{
    public class ScriptSizeRect : CustomProjectWindowRectBase
    {
        
        private const int GreenSizeUpperBound = 50;
        private const int YellowSizeUpperBound = 100;
        
        public ScriptSizeRect(string assetPath, Rect rect)
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
            var lineSize = GetLineSize(assetPath);
            if (lineSize != -1)
            {
                if (lineSize < GreenSizeUpperBound)
                {
                    style.normal.textColor = Color.green;
                }
                else if (lineSize < YellowSizeUpperBound)
                {
                    style.normal.textColor = Color.yellow;
                }
                else
                {
                    style.normal.textColor = Color.red;
                }

                fileSizeText = lineSize + " Line";
            }
        }

        private static int GetLineSize(string assetPath)
        {
            if (!File.Exists(assetPath)) return -1;
            var lines = File.ReadAllLines(assetPath);
            return lines.Length;
        }
        
    }
}