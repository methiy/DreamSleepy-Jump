using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour
{

    [SerializeField] private GameObject editorMenuPanel;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button editorButton;
    [SerializeField] private Button RestartButtion;
        

    public Slider bgmSlider; // 背景音乐滑动条
    public Slider sfxSlider; // 音效滑动条
    public Button muteAllButton; // 关闭所有声音按钮
    public Button closeButton; // 关闭面板按钮

    [SerializeField]private AudioSource bgmSource; // 背景音乐来源
    [SerializeField]private AudioSource sfxSource; // 音效来源
    public GameObject Player;//玩家预制体

    private void Start()
    {
        
        startButton?.onClick.AddListener(StartGame);
        exitButton?.onClick.AddListener(ExitGame);
        pauseButton?.onClick.AddListener(PauseGame);
        resumeButton?.onClick.AddListener(ResumeGame);
        editorButton?.onClick.AddListener(ShowEditorPanel);
        RestartButtion.onClick.AddListener(ReStartGame);

        resumeButton?.gameObject.SetActive(false);
        editorMenuPanel?.SetActive(false);

        // 初始化滑动条
        bgmSlider.value = bgmSource.volume;
        sfxSlider.value = sfxSource.volume;

        // 设置滑动条的事件监听
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

        // 设置按钮的点击事件
        muteAllButton.onClick.AddListener(MuteAll);
        closeButton.onClick.AddListener(CloseEditorPanel);
    }

    private void StartGame()
    {
        
        Player.SetActive(true);
    }

    private void PauseGame()
    {
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    private void ShowEditorPanel(){
        editorMenuPanel.SetActive(true);
    }
    private void CloseEditorPanel()
    {
        editorMenuPanel.SetActive(false);
    }
    private void OnBGMVolumeChanged(float volume)
    {
        bgmSource.volume = volume;
    }

    private void OnSFXVolumeChanged(float volume)
    {
        sfxSource.volume = volume;
    }

    private void MuteAll()
    {
        bgmSource.mute = true;
        sfxSource.mute = true;
    }
    private void ReStartGame()
    {

        SceneManager.LoadScene("Gamescene");
    }
}