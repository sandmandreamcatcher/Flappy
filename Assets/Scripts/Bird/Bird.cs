using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;
    public bool IsDied { get; private set; } = false;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBird();
        IsDied = false;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
        IsDied = true;
    }
}