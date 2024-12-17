using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField] private int _gameSceneID;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();   
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_gameSceneID);
    }
}
