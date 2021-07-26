using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBird();
    }

    public void Die()
    {
        Debug.Log("I'm dead");
        Time.timeScale = 0;
    }
}