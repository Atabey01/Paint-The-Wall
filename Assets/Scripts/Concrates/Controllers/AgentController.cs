using System.Collections;
using TPSRunerGame.Controllers;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    NavMeshAgent _agent;
    PlayerController _playerController;
    Vector3 _agentStartPoint;
    public Transform StartPoint;
    Animator _animator;
    Rigidbody _rb;
    Vector3 _agentStartRotation;
    LevelCreator _levelCreator;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponentInChildren<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _agentStartPoint = transform.position;
        _agentStartRotation = transform.position;

        _levelCreator = FindObjectOfType<LevelCreator>();
    }
    private void Start()
    {
        _agent.speed = 10;
    }

    private void OnEnable()
    {
        GameManager.Instance.OnPainting += AgentLoose;
    }


    private void Update()
    {
        if (GameManager.Instance.GameState == TPSRunerGame.Abstracts.GameStates.InGameStart && GameManager.Instance.AgentStartsMove == true)
        {
            _agent.SetDestination(GameManager.Instance.EndPoint.transform.position); // Agents End Point Destination
            transform.localRotation = Quaternion.identity;
            _animator.SetBool("isRun", true);

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _animator.SetBool("isRun", false);
            GameManager.Instance.InitializeAgentLoose();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            StartFromBegining();

        }
    }
    private void OnDisable()
    {
        GameManager.Instance.OnPainting -= AgentLoose;

    }


    void StartFromBegining()
    {
        StartCoroutine(AgentDeath());
    }
    public IEnumerator AgentDeath() //Repositioning When The Agent Dies 
    {
        _agent.isStopped = true;
        _animator.SetBool("isAgentDeath", true);
        _rb.isKinematic = true;

        yield return new WaitForSecondsRealtime(2); // Delay And Repositioning For The Agents Death Animations When Agent Die
        transform.position = _agentStartRotation;
        _animator.SetBool("isAgentDeath", false);
        _rb.isKinematic = false;
        _agent.isStopped = false;

    }
    void AgentLoose() //When The Agent Lost The Game Against Our Player
    {
        _animator.SetBool("isAgentDeath", true);
        _agent.speed = 0;
    }

}
