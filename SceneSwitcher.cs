using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public class SceneSwitcher : EditorWindow
    {
        [MenuItem("Switch Scene/MainMenu")]
        private static void OpenMainMenuScene()
        {
            OpenScene("MainMenu");
        }

        [MenuItem("Switch Scene/Game")]
        private static void OpenGameScene()
        {
            OpenScene("Game");
        }

        private static void OpenScene(string sceneName)
        {
            if (EditorApplication.isPlaying)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                string scenePath = $"Assets/Scenes/{sceneName}.unity";
                if (System.IO.File.Exists(scenePath))
                {
                    UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scenePath);
                }
                else
                {
                    Debug.LogError($"Сцена {sceneName} не найдена в {scenePath}!");
                }
            }
        }
    }
}