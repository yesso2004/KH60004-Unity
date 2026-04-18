using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;

   
    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private Transform PlayerHandZone;
    [SerializeField] private Transform AIHandZone;

    [SerializeField] private TextMeshProUGUI RoundNumberTxt;
    [SerializeField] private Image StatusLogo;

    [SerializeField] private GameObject EndScreen;
    [SerializeField] private TextMeshProUGUI EndTitleTxt;

    private void Awake()
    {
        Instance = this;
    }

    public void DsiplayCard(Card CardData,Player player)
    {
        Transform TargetedHand = null;
        bool Hidden = false;
        if (player == GameManager.instance.Me)
        {
             Hidden = false;
             TargetedHand = PlayerHandZone;
        }
        else
        {
            Hidden = true;
            TargetedHand = AIHandZone;
        }

        if (TargetedHand == null)
        {
            Debug.LogError("Cannot allocate card to missing hand");
            return;
        }

        GameObject AddedCard = Instantiate(CardPrefab, TargetedHand);
        CardData DataScript = AddedCard.GetComponent<CardData>();

        if (DataScript != null)
        {
            DataScript.DisplayCards(CardData, Hidden);
        }
        else
        {
            Debug.LogError("Failed to create card");
        }
    }


    public IEnumerator DiscardCard(Card DiscardedCard,Player player,CardData PhysicalCard = null) 
    {
        Transform TargetedHand = null;

        if (player == GameManager.instance.Me)
        {
            TargetedHand = PlayerHandZone;
        }
        else
        {
            TargetedHand = AIHandZone;
        }

        Transform CardVanish = null;
        CanvasGroup CardCG = null;
        CardData DataScript = null;

      
        
            if (PhysicalCard != null)
            {
                CardVanish = PhysicalCard.transform;
                CardCG = PhysicalCard.GetComponent<CanvasGroup>();
                DataScript = PhysicalCard;
            }
            else 
            {
                foreach (Transform Card in TargetedHand)
                {
                    CardData CardScript = Card.GetComponent<CardData>();

                    if (CardScript != null && CardScript.Data == DiscardedCard)
                    {
                        CardVanish = Card;
                        CardCG = Card.GetComponent<CanvasGroup>();
                        DataScript = CardScript;
                        break;
                    }
                }
            }

        if (CardVanish != null)
        {


            if (player == GameManager.instance.AI && DataScript != null)
            {
                DataScript.DisplayCards(DiscardedCard, false);

            }

            float Duration = 2f;
            float DurationTime = 0f;

            Vector2 StartPosition = CardVanish.transform.localPosition;
            Vector2 EndPosition = StartPosition + new Vector2(0, 100);
            Vector2 AIEndPosition = StartPosition + new Vector2(0, -100);

            while (DurationTime < Duration)
            {
                if (CardVanish == null)
                {
                    break;
                }

                DurationTime += Time.deltaTime;
                float Percent = DurationTime / Duration;

                if (player == GameManager.instance.Me)
                {
                    CardVanish.localPosition = Vector2.Lerp(StartPosition, EndPosition, Percent);
                }
                else if (player == GameManager.instance.AI)
                {
                    CardVanish.localPosition = Vector2.Lerp(StartPosition, AIEndPosition, Percent);
                }

                if (CardCG != null)
                {
                    CardCG.alpha = Mathf.Lerp(1f, 0f, Percent);
                }

                yield return null;
            }

            if (CardVanish != null)
            {
                Destroy(CardVanish.gameObject);
            }
        }
        else
        {
            Debug.LogError("Couldnt find card");
        }
    }


    public IEnumerator NewRound(bool EndGame = false)
    {

        if (EndGame == false)
        {
            RoundNumberTxt.text = $"Round: {GameManager.instance.RoundNumber}";
        }
        else
        {
            RoundNumberTxt.color = new Color(0.8f, 0.1f, 0.1f, 1f);
            RoundNumberTxt.text = $"EndGame";
            AudioManager.Instance.EndGame();
        }

        yield return StartCoroutine(ShowRoundDetails());

    }

    private IEnumerator ShowRoundDetails()
    {
        RoundNumberTxt.gameObject.SetActive(true);


        yield return StartCoroutine(FadeManager.Instance.FadeOut(StatusLogo.gameObject));
        yield return StartCoroutine(FadeManager.Instance.FadeIn(RoundNumberTxt.gameObject));

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(FadeManager.Instance.FadeIn(StatusLogo.gameObject));
        yield return StartCoroutine(FadeManager.Instance.FadeOut(RoundNumberTxt.gameObject));


        RoundNumberTxt.gameObject.SetActive(false);
    }

    public IEnumerator FinishGame(bool Winner)
    {
        if (Winner == true)
        {
            EndTitleTxt.text = "Winner";
            GameManager.instance.Me.Wins++;
            AudioManager.Instance.WinAudio();
        }
        else
        {
            EndTitleTxt.text = "Loser";
            GameManager.instance.Me.Losses++;
            AudioManager.Instance.LoseAudio();
        }

        yield return StartCoroutine(FadeManager.Instance.FadeIn(EndScreen));

        yield return new WaitForSeconds(3.5f);

        FirebaseUser CurrentUser = FirebaseAuth.DefaultInstance.CurrentUser;

        if (CurrentUser != null)
        {

            DatabaseReference DBRef = FirebaseDatabase.DefaultInstance.RootReference;


            var UserDB = DBRef.Child("user").Child(CurrentUser.UserId);


            UserDB.Child("Wins").SetValueAsync(GameManager.instance.Me.Wins);
            UserDB.Child("Losses").SetValueAsync(GameManager.instance.Me.Losses);

            UserData.Wins = GameManager.instance.Me.Wins;
            UserData.Losses = GameManager.instance.Me.Losses;

        }
        else
        {
            Debug.LogError("Failed to save data.");
        }

        SceneManager.LoadScene("Menu");

    }
}
