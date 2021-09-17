using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int score;
    [SerializeField]
    private int maxPontuation;
    [SerializeField]
    private GameObject shelfPreFab;
    [SerializeField]
    private GameObject[] shelfs;
    [SerializeField]
    private WindowPointer windowPointer;

    private bool playing;
    private TimerController timerController;
    private List<string> colors = new List<string> { "blue", "red", "yellow", "green", "black", "white"};
    System.Random random = new System.Random();


    void Awake()
    {
        this.timerController = this.gameObject.GetComponent<TimerController>();
        this.score = 0;
        InstantiateShelf();
    }

    void Start(){

    }

    //Checa se a pontuação maxima foi atingida para encerrar o timer
    void Update(){
        if (score == maxPontuation && playing) {
            this.timerController.EndTimer();
            this.playing = false;
            timerController.Collision("Voce conseguiu!!");
        }
    }

    //Inicia o Timer da partida.
    private void StartPlaying() {
        this.timerController.BeginTimer();
        this.playing = true;
    }

    //Incrementa o contador de pontuação.
    private void IncrementCounter(int score) {
        this.score += score;
        this.timerController.IncrementCounter(score);
    }

    //Instancia todas as estantes na posição definida, isso feito atraves da lista de GameObjects,
    //de modo que cada uma tenha uma cor aleatoria.
    private void InstantiateShelf()
    {
        foreach (GameObject shelf in this.shelfs) {
            GameObject est = Instantiate(shelfPreFab, shelf.transform.position, Quaternion.identity);
            est.transform.SetParent(shelf.transform);
            est.GetComponent<ShelfsManager>().SetColor(RandomColor());
        }
    }

    //Randomiza uma cor entre as cores contidas em "colors". Após isso remove a cor da lista.
    private string RandomColor()
    {
        int index = random.Next(this.colors.Count);
        string color = this.colors[index];
        this.colors.Remove(color);
        return color;
    }

    //Inicializa a seta indicativa de acordo com a estante correta para o livro passado.
    private void SetGuide(GameObject book) {
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

    //quando Maria livrão colide com a estante correta
    private void RightCollision() {
        windowPointer.Hide();
        timerController.Collision("Estante Correta!!");
        //animação para pontuação
        //efeito sonoro
    }

    //quando Maria livrão colide com a estante errada
    private void WrongCollision() {
        timerController.Collision("Estante Incorreta!!");
        //animação para erro
        //efeito sonoro
    }
}
