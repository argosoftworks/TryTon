using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private GameObject[] _pipe;
    [SerializeField] private Animator[] _animatorPipe;
    public Animator animator;
    GameManager gameManager;
    public Transform position;
    public int _randomIndex;
    pipeAnimation _pipeAnimation;
    public int randomNumber;
    public int dropIndex;
    
    
    void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        _pipeAnimation = GameObject.FindGameObjectWithTag("Pipe").GetComponent<pipeAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager._gameStarted)
        {
            Destroy(GameObject.Find("coin(Clone)"));
            Destroy(GameObject.Find("Bomb(Clone)"));
            Destroy(GameObject.Find("present(Clone)"));
        }
       
        
    }

    public void _generateIndex()
    {
        _randomIndex = Random.Range(0, _pipe.Length);
        randomNumber = _randomIndex;
    }

    private void _geerateDropIndex()
    {
        int[] value = new[] { 0, 0, 0, 0, 0, 1, 2 };
        var drop = Random.Range(0,value.Length);
        dropIndex = value[drop];
    }
    
    public void SpawnObject()
    {
        if (gameManager._gameStarted)
        {
            _geerateDropIndex();
            _generateIndex();
            position = _pipe[randomNumber].GetComponent<Transform>();
            animator = _animatorPipe[randomNumber].GetComponent<Animator>();
            animator.SetTrigger("spawn");
            _pipeAnimation._pipeSmoke();
        }
    }
}
