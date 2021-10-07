using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paulo
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int maxPontuation;
        [SerializeField] private int maxLife;
        [SerializeField] private int life;
        [SerializeField] private GameObject shelfPreFab;
        [SerializeField] private GameObject[] shelfs;
        [SerializeField] private GameObject[] objects;
        [SerializeField] private WindowPointer windowPointer;


        private int score;
        private bool isPlaying;
        private bool won;
        private TimerController timerController;
        private SoundManager soundManager;
        private StudyGroup studyGroup;
        private PlayerManager playerManager;
        private List<string> colors = new List<string> { "blue", "red", "yellow", "green", "black", "white" };
        private List<string> colors2 = new List<string> { "blue", "red", "yellow", "green", "black", "white" };
        System.Random random = new System.Random();


        void Awake()
        {
            timerController = gameObject.GetComponent<TimerController>();
            soundManager = gameObject.GetComponent<SoundManager>();
            studyGroup = gameObject.GetComponentInChildren<StudyGroup>();
            playerManager = gameObject.GetComponentInChildren<PlayerManager>();
            transform.GetChild(3).gameObject.SetActive(false);
            score = 0;
            isPlaying = false;
            won = false;
            InstantiateShelf();
        }

        //Checa se a pontuação maxima foi atingida para encerrar o timer
        void Update()
        {
            if (isPlaying && !won)
            {
                if (score == maxPontuation)
                {
                    StopPlaying();
                    WinFeedBack();
                    won = true;
                }
                if (timerController.GetTimer() < 0 || life == 0)
                {
                    StopPlaying();
                    LoseFeedBack();
                }
            }
        }

        //Inicia o Timer da partida.
        private void StartPlaying()
        {
            life = maxLife;
            timerController.VisualFeedBack("Começouu!!");
            timerController.BeginTimer();
            timerController.SetScore(life);
            studyGroup.StartPlaying(colors2);
            isPlaying = true;
         
            //StartMoveObjetcs(); move os npcs pelo mapa 
        }

        private void StopPlaying()
        {
            timerController.EndTimer();
            isPlaying = false;
            playerManager.StopPlaying();
            studyGroup.StopPlaying();
            //transform.GetChild(3).gameObject.SetActive(true); exibe a saida
            StopMoveObjetcs();
        }

        private void StopMoveObjetcs()
        {
            foreach (GameObject obj in objects)
            {
                TweenDesk tweenDesk = obj.GetComponent<TweenDesk>();
                tweenDesk.StopMove();
            }
        }

        private void StartMoveObjetcs()
        {
            foreach (GameObject obj in objects)
            {
                TweenDesk tweenDesk = obj.GetComponent<TweenDesk>();
                tweenDesk.StartMove();
            }
        }

        //Incrementa o contador de pontuação.
        private void IncrementCounter()
        {
            score += 1;
            if (life < maxLife) {
                life += 1;
            }
            //timerController.SetScore(score);
        }

        //Instancia todas as estantes na posição definida, isso feito atraves da lista de GameObjects,
        //de modo que cada uma tenha uma cor aleatoria.
        private void InstantiateShelf()
        {
            foreach (GameObject shelf in this.shelfs)
            {
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
        private void TookBook(GameObject studyGroup)
        {
            //efeito sonoro pegou o livro
            //GameObject shelf = FindGuideShelf(bookColor);
            timerController.PopUpBook(true);
            windowPointer.Show(studyGroup.transform.position);
        }

        private void TookRequest(string bookColor)
        {
            //efeito sonoro pegou o livro
            GameObject shelf = FindGuideShelf(bookColor);
            shelf.transform.GetChild(0).gameObject.GetComponent<ShelfsManager>().CreateBook();
            windowPointer.Show(shelf.transform.position);
            studyGroup.NewRequest();
            timerController.EndTimer();
            timerController.BeginTimer();
        }

        //Encontra a instancia de estante que tem a cor correspondente ao livro
        private GameObject FindGuideShelf(string bookColor)
        {
            GameObject rightShelf = null;

            foreach (GameObject shelf in this.shelfs)
            {
                string colorShelf = shelf.transform.GetChild(0).gameObject.GetComponent<ShelfsManager>().GetColor();
                if (colorShelf == bookColor)
                {
                    rightShelf = shelf;
                    break;
                }
            }

            return rightShelf;
        }

        //quando Maria livrão colide com a estante correta
        private void RightCollision()
        {
            windowPointer.Hide();
            soundManager.PlayRightShelf();
            //timerController.VisualFeedBack("Grupo Correto!!");
            IncrementCounter();
            timerController.PopUpBook(false);
            timerController.SetScore(life);

            //animação para pontuação
            //efeito sonoro
        }

        //quando Maria livrão colide com a estante errada
        private void WrongCollision()
        {
            soundManager.PlayWrongShelf();
            timerController.VisualFeedBack("Estante Incorreta!!");
            life -= 1;
            timerController.SetScore(life);
            //animação para erro
            //efeito sonoro
            //decrementa a vida da maria livrao ou decrementa a quantidade de acertos
        }

        private void WinFeedBack()
        {
            //efeito sonoro
            soundManager.PlayWonGame();
            windowPointer.Hide();
            timerController.VisualFeedBack("Voce conseguiu!!");
        }

        private void LoseFeedBack()
        {
            //efeito sonoro
            timerController.VisualFeedBack("Não foi dessa vez");
            //destroi o livro e zera variaveis
            playerManager.DestroyBook();
            windowPointer.Hide();
            timerController.PopUpBook(false);
            score = 0;
    }
    }
}