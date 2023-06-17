using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] public bool gameIsOver { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        gameIsOver = true;
        GameOverScreen goScreen = Instantiate(gameoverScreen, GameObject.FindWithTag("Canvas").transform).GetComponent<GameOverScreen>();

        goScreen.mainmenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
