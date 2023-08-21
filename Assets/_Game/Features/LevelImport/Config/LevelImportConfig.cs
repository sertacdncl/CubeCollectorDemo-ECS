using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class LevelImportConfig : ScriptableObject
    {
#if UNITY_EDITOR

        public float Scaling = 20f;
        public float PointsPerUnit = 1f;
        public Sprite[] Levels;

        public void GenerateAndSerialize()
        {
            string targetDirectory = $"{Application.dataPath}/_Game/Features/LevelImport/Resources/";

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            GenerateLevels();

            AssetDatabase.Refresh();
        }

		private void GenerateLevels()
        {
            LevelDataContainer level;
            for (int i = 0; i < Levels.Length; i++)
            {
                Debug.Log("Building Level: " + (i + 1));
                var assetObject = Levels[i];

                level = GetLevel(assetObject);

                var levelString = JsonUtility.ToJson(level);

                File.WriteAllText(
                    $"{Application.dataPath}/_Game/Features/LevelImport/Resources/{LevelImportTags.GeneratedLevel}{i}.txt",
                    levelString);
            }

            var levelInfoString = JsonUtility.ToJson(new LevelInfo(Levels.Length));
            File.WriteAllText(
                $"{Application.dataPath}/_Game/Features/LevelImport/Resources/{LevelImportTags.LevelInfo}.txt",
                levelInfoString);
        }

        private LevelDataContainer GetLevel(Sprite levelSprite)
        {
            var rect = levelSprite.rect;
            var coloredPixelList = new List<ColoredPixelData>();

            var minX = 99;
            var minY = 99;

            for (var col = 0; col < rect.width; col++)
            {
                for (var row = 0; row < rect.height; row++)
                {
                    var pixelColor = (Color32)levelSprite.texture.GetPixel(col + (int)rect.xMin, row + (int)rect.yMin);
                    var pixelPosition = new Vector2Int(col, row);

                    if(pixelColor.a == 0)
                        continue;


                    var findIndex = coloredPixelList.FindIndex(x => x.Color.IsEqual(pixelColor));
                    if (findIndex != -1)
                    {
                        coloredPixelList[findIndex].PixelList.Add(pixelPosition);

                    }
                    else
                    {
                        coloredPixelList.Add(new ColoredPixelData
                        {
                            Color = pixelColor,
                            PixelList = new List<Vector2Int> { pixelPosition }
                        });
                    }

                    if (pixelPosition.x < minX)
                        minX = pixelPosition.x;

                    if (pixelPosition.y < minY)
                        minY = pixelPosition.y;
                }
            }

            foreach (var coloredPixelData in coloredPixelList)
            {
                for (var index = 0; index < coloredPixelData.PixelList.Count; index++)
                {
                    var cellPos = coloredPixelData.PixelList[index];
                    coloredPixelData.PixelList[index] = new Vector2Int(cellPos.x - minX, cellPos.y - minY);
                }
            }


            return new LevelDataContainer
            {
                ColoredPixelList = coloredPixelList,
            };
        }
#endif
    }

    [Serializable]
    public struct LevelInfo
    {
        public int LevelCount;
        public LevelInfo(int levelCount) => LevelCount = levelCount;
    }

    [Serializable]
    public struct LevelDataContainer
    {
        public List<ColoredPixelData> ColoredPixelList;
    }

    [Serializable]
    public struct ColoredPixelData
    {
        public Color32 Color;
        public List<Vector2Int> PixelList;
    }
}


