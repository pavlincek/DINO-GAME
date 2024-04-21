using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed Instance {get; private set; }
    public float initialSpeed = 5f;
    public float Increase = 0.1f;
    public float SPEED { get; private set; }

    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    private Player player;
    private SPAWNER spawner;

    private float score;

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
        } else
        {
            DestroyImmediate(gameObject);
        }
    }


    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }


    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<SPAWNER>();

        NewGame();
    }


    public void NewGame()
    {
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        SPEED = initialSpeed;
        score = 0f;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        SPEED = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        spawner.CancelInvoke();

        UpdateHiscore();
    }


    private void Update()
    {
        SPEED += Increase * Time.deltaTime;
        score += SPEED * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiscore()
    {

        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if(score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }



}
