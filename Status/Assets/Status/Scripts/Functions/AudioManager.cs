using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip BasicButtonSound;
    [SerializeField] private AudioClip RegisterSound;
    [SerializeField] private AudioClip SignInSound;
    [SerializeField] private AudioClip CardPlaySound;
    [SerializeField] private AudioClip DrawCardsSound;
    [SerializeField] private AudioClip PenaltyDrawSound;
    [SerializeField] private AudioClip EndGameIndicationSound;
    [SerializeField] private AudioClip WinnerSound;
    [SerializeField] private AudioClip LoserSound;
    [SerializeField] private AudioClip EasterEggSound;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BasicButtonClickSound()
    {
        AudioSource.PlayOneShot(BasicButtonSound);
    }
    public void RegisterClickSound()
    {
        AudioSource.PlayOneShot(RegisterSound);
    }
    public void SignInClickSound()
    {
        AudioSource.PlayOneShot(SignInSound);
    }
    public void CardSound()
    {
        AudioSource.PlayOneShot(CardPlaySound);
    }
    public void EasterEgg()
    {
        AudioSource.PlayOneShot(EasterEggSound);
    }

    public void DrawSound()
    {
        AudioSource.PlayOneShot(DrawCardsSound);
    }
    public void PenaltySound()
    {
       
        AudioSource.PlayOneShot(PenaltyDrawSound,0.2f);
    }
    public void EndGame()
    {
        AudioSource.PlayOneShot(EndGameIndicationSound);
    }

    public void WinAudio()
    {
        AudioSource.PlayOneShot(WinnerSound);

    }

    public void LoseAudio()
    {
        AudioSource.PlayOneShot(LoserSound);

    }

}

