using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource poolerSource;
    public AudioSource hitSource; // Âm thanh khi trúng đạn của tiểu hành tinh
    public AudioSource explodeSource; // Âm thanh cho vụ nổ tiểu hành tinh

    public AudioSource collectStarSource; // Âm thanh cho việc thu thập sao

    public AudioSource gameMusicSource; // Âm thanh nhạc nền của trò chơi


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundOneShot(AudioSource sound)
    {
        sound.PlayOneShot(sound.clip);
    }

    public void PlayMusic()
    {
        if (gameMusicSource != null && !gameMusicSource.isPlaying)
        {
            gameMusicSource.loop = true;
            gameMusicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (gameMusicSource != null && gameMusicSource.isPlaying)
        {
            gameMusicSource.Stop();
        }
    }
}
