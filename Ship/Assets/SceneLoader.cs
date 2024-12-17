using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button loadSceneButton;
    [SerializeField] private string sceneName;

    private void Start()
    {
        if (loadSceneButton != null)
        {
            loadSceneButton.onClick.AddListener(LoadScene);
        }
    }

    private void LoadScene()
    {
        StartCoroutine(LoadYourScene());
    }

    private IEnumerator LoadYourScene()
    {
        // ��������� ����������� �������� �����
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // ����, ���� ����� ����������
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // ������������� ����������� ����� ��� ��������
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        DynamicGI.UpdateEnvironment();
    }
}