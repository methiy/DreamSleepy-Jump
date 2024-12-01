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
        

    public Slider bgmSlider; // �������ֻ�����
    public Slider sfxSlider; // ��Ч������
    public Button muteAllButton; // �ر�����������ť
    public Button closeButton; // �ر���尴ť

    [SerializeField]private AudioSource bgmSource; // ����������Դ
    [SerializeField]private AudioSource sfxSource; // ��Ч��Դ
    public GameObject Player;//���Ԥ����

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

        // ��ʼ��������
        bgmSlider.value = bgmSource.volume;
        sfxSlider.value = sfxSource.volume;

        // ���û��������¼�����
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

        // ���ð�ť�ĵ���¼�
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