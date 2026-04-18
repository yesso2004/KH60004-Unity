using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    Setup,
    Draw,
    PlayerTurn,
    AITurn,
    WheelSpin,
    Playing
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState CurrentState;

    public Player Me;
    public Player AI;
    public List<Card> Deck = new List<Card>();
    public int RoundNumber = 1;

    private void Awake()
    {
        instance = this;
        if (Me != null)
        {
            Me.Name = UserData.Username;
            Me.Wins = UserData.Wins;
            Me.Losses = UserData.Losses;
        }

        Shuffle();
    }

    private void Start()
    {
        StartCoroutine(Game());
    }

    private IEnumerator Game()
    {
        yield return StartCoroutine(UIManager.Instance.NewRound());
        CurrentState = GameState.Setup;
        yield return StartCoroutine(SetupGame());

        CurrentState = GameState.PlayerTurn;

    }
    private IEnumerator SetupGame()
    {
        yield return StartCoroutine(Me.InitialDraw());
        yield return StartCoroutine(AI.InitialDraw());

    }


    public void AITurn(Player player)
    {
        StartCoroutine(AITurnWait(player));
    }

    private IEnumerator AITurnWait(Player player)
    {
        if (CurrentState == GameState.WheelSpin)
        {
            yield return new WaitUntil(() => CurrentState != GameState.WheelSpin);
        }


        if (RoundNumber > 1)
        {
            
            yield return StartCoroutine(AI.DrawCard());
        }

       
        yield return new WaitForSeconds(1.5f);

       
        if (AI.Hand.Count == 0)
        {
            yield return StartCoroutine(EndAITurn());
            yield break;
        }

       
        int RandomPlay = Random.Range(0, AI.Hand.Count);
        Card RandomChoice = AI.Hand[RandomPlay];

        AudioManager.Instance.CardSound();
        AI.PlayCard(RandomChoice, Me);

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(EndAITurn());
    }

   
    private IEnumerator EndAITurn()
    {
        RoundNumber++;


        if (RoundNumber == 5)
        {
            bool Winner = (Me.StatusPoints > AI.StatusPoints) ? true : false;
            yield return StartCoroutine(UIManager.Instance.FinishGame(Winner));
            yield break;
        }

        if (RoundNumber == 4)
        {
            yield return StartCoroutine(UIManager.Instance.NewRound(true));

        }
        else
        {
            yield return StartCoroutine(UIManager.Instance.NewRound());

        }

        StartCoroutine(Me.DrawCard());
    }

    public Card DeckDraw()
    {
        if (Deck.Count <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Menu");
            return null;
        }
        
        int RandomCardIndex = Random.Range(0, Deck.Count);
        Card DrawnCard = Deck[RandomCardIndex];
        Deck.Remove(DrawnCard);
        
        return DrawnCard;
    }

    private void Shuffle()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            Card ShuffledCard = Deck[i];
            int RandomIndex = Random.Range(i, Deck.Count);
            Deck[i] = Deck[RandomIndex];
            Deck[RandomIndex] = ShuffledCard;
        }
    }

    public void ChangeState(GameState NewState)
    {
        CurrentState = NewState;
    }
    
}

