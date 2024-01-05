using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using TMPro;
using UnityEngine;

public class DiaryScript : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI diaryHeader;
    [SerializeField] private TextMeshProUGUI diaryContent;

    [SerializeField] private Transition transition;

    [Header("Diary text")]
    [SerializeField] private TextAsset diaryJson;

    void Start()
    {
        Diary currentDiary = GetCurrentDiary(GameManager.currentLevelIndex);

        diaryHeader.text = currentDiary.header;
        diaryContent.text = currentDiary.text;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transition.FadeOut(1f, 0.5f);
            StartCoroutine(GameManager.ChangeSceneWithDelay(SceneType.NextLevel, 1f));
        }
    }

    Diary GetCurrentDiary(int dayIndex)
    {
        Diaries diaries = JsonUtility.FromJson<Diaries>(diaryJson.text);
        return diaries.diaries[dayIndex];
    }
    
}

[System.Serializable]
class Diary
{
    public string header;
    public string text;
}

[System.Serializable]
class Diaries
{
    public Diary[] diaries;
}