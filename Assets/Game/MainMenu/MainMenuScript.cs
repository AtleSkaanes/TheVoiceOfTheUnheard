using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button quitBtn;

    [SerializeField] private GameObject truck;
    private Rigidbody truckRb;

    [SerializeField] private Transition transition;


    private void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        quitBtn.onClick.AddListener(QuitGame);

        truckRb = truck.GetComponent<Rigidbody>();

    }

    private void StartGame()
    {
        truckRb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        truckRb.AddRelativeForce(new Vector3(0, 0, 2_000f), ForceMode.Impulse);

        float delay = 0.5f;
        transition.FadeOut(1f, delay);

        StartCoroutine(GameManager.ChangeSceneWithDelay(SceneType.FirstLevel, 1f));
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
