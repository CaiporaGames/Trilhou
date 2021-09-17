using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int maxPontuation;
    [SerializeField] private GameObject shelfPreFab;
    [SerializeField] private GameObject[] shelfs;
    [SerializeField] private GameObject[] desks;
    [SerializeField] private WindowPointer windowPointer;

    private int score;
    private bool isPlaying;
    private TimerController timerController;
    private SoundManager soundManager;
    private List<string> colors = new List<string> { "blue", "red", "yellow", "green", "black", "white"};
    System.Random random = new System.Random();


    void Awake(){
        timerController = gameObject.GetComponent<TimerController>();
        soundManager = gameObject.GetComponent<SoundManager>();
        transform.GetChild(3).gameObject.SetActive(false);
        score = 0;
        isPlaying = false;
        InstantiateShelf();
    }

    //Checa se a pontua��o maxima foi atingida para encerrar o timer
    void Update(){
        if (isPlaying) {
            if (score == maxPontuation) {
                StopPlaying();
                WinFeedBack();
            }
            if (timerController.GetTimer() == 0) {
                StopPlaying();
                LoseFeedBack();
            } 
        }
    }

    //Inicia o Timer da partida.
    private void StartPlaying() {
        timerController.VisualFeedBack("Come�ouu!!");
        timerController.BeginTimer();
        isPlaying = true;
        transform.GetChild(1).SendMessage("StartPlaying");
        foreach (GameObject desk in desks)
        {
            TweenDesk tweenDesk = desk.GetComponent<TweenDesk>();
            tweenDesk.BeginMove();
        }
    }
    private void StopPlaying() {
        timerController.EndTimer();
        isPlaying = false;
        transform.GetChild(0).transform.GetChild(0).SendMessage("StopPlaying");
        transform.GetChild(1).SendMessage("StopPlaying");
        transform.GetChild(3).gameObject.SetActive(true);
        foreach (GameObject desk in desks)
        {
            TweenDesk tweenDesk = desk.GetComponent<TweenDesk>();
            tweenDesk.StopMove();
        }
    }

    //Incrementa o contador de pontua��o.
    private void IncrementCounter() {
        score += 1;
        timerController.SetScore(score);
    }

    //Instancia todas as estantes na posi��o definida, isso feito atraves da lista de GameObjects,
    //de modo que cada uma tenha uma cor aleatoria.
    private void InstantiateShelf()
    {
        foreach (GameObject shelf in this.shelfs) {
            GameObject est = Instantiate(shelfPreFab, shelf.transform.position, Quaternion.identity);
            est.transform.SetParent(shelf.transform);
            est.GetComponent<ShelfsManager>().SetColor(RandomColor());
        }
    }

    //Randomiza uma cor entre as cores contidas em "colors". Ap�s isso remove a cor da lista.
    private string RandomColor()
    {
        int index = random.Next(this.colors.Count);
        string color = this.colors[index];
        this.colors.Remove(color);
        return color;
    }

    //Inicializa a seta indicativa de acordo com a estante correta para o livro passado.
    private void TookBook(GameObject book) {
        //efeito sonoro pegou o livro
        string bookColor = book.GetComponent<Books>().GetColor();
        GameObject shelf = FindGuideShelf(bookColor);
        windowPointer.Show(shelf.transform.position);
    }

    //Encontra a instancia de estante que tem a cor correspondente ao livro
    private GameObject FindGuideShelf(string bookColor) {
        GameObject rightShelf = null;

        foreach (GameObject shelf in this.shelfs)
        {
            string colorShelf = shelf.transform.GetChild(0).gameObject.GetComponent<ShelfsManager>().GetColor();
            if (colorShelf == bookColor) {
                rightShelf = shelf;
                break;
            }
        }

        return rightShelf;
    }

    //quando Maria livr�o colide com a estante correta
    private void RightCollision() {
        windowPointer.Hide();
        soundManager.PlayRightShelf();
        timerController.VisualFeedBack("Estante Correta!!");
        //anima��o para pontua��o
        //efeito sonoro
    }

    //quando Maria livr�o colide com a estante errada
    private void WrongCollision() {
        soundManager.PlayWrongShelf();
        timerController.VisualFeedBack("Estante Incorreta!!");
        //anima��o para erro
        //efeito sonoro
    }

    private void WinFeedBack()
    {
        //efeito sonoro
        soundManager.PlayWonGame();
        timerController.VisualFeedBack("Voce conseguiu!!");
    }

    private void LoseFeedBack()
    {
        //efeito sonoro
        timerController.VisualFeedBack("N�o foi dessa vez");
    }
}
