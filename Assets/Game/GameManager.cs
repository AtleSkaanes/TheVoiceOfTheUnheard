using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    CurrentLevel,
    NextLevel,
    PrevLevel,
    FirstLevel,
    MainMenu,
    Diary
}

public static class GameManager
{
    public const int LevelCount = 6;
    public static int currentLevelIndex = 0;
    private static int levelSceneOffset = 2;

    public static int mainMenuSceneIndex = 0;
    public static int diarySceneIndex = 1;

    public static int currentLevelSceneIndex
    {
        get { return currentLevelIndex + levelSceneOffset; }
    }

    public static void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static IEnumerator ChangeSceneWithDelay(int sceneIndex, float delaySeconds = 0f)
    {
        yield return new WaitForSeconds(delaySeconds);

        SceneManager.LoadScene(sceneIndex);
    }
    public static IEnumerator ChangeSceneWithDelay(SceneType sceneType, float delaySeconds = 0f)
    {
        yield return new WaitForSeconds(delaySeconds);

        switch (sceneType)
        {
            case SceneType.MainMenu:
                SceneManager.LoadScene(mainMenuSceneIndex);
                break;
            case SceneType.Diary:
                SceneManager.LoadScene(diarySceneIndex);
                break;
            case SceneType.CurrentLevel:
                SceneManager.LoadScene(currentLevelIndex + levelSceneOffset);
                break;
            case SceneType.NextLevel:
                if (currentLevelIndex + 2 != LevelCount) {
                    SceneManager.LoadScene(currentLevelIndex + levelSceneOffset + 1);
                    currentLevelIndex++;
                }
                else
                {
                    SceneManager.LoadScene(mainMenuSceneIndex);
                }

                break;
            case SceneType.PrevLevel:
                SceneManager.LoadScene(currentLevelIndex + levelSceneOffset - 1);
                currentLevelIndex--;
                break;
            case SceneType.FirstLevel:
                SceneManager.LoadScene(levelSceneOffset);
                currentLevelIndex = 0;
                break;
        }
    }
}
