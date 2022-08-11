using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Header("Managers")]
    public GameManager gameManager;

    [Header("Fighters Game Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    
    [Header("Fighters Animators")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator enemyAnimator;

    private Shape playerShape;
    private Action playerAction;
    private Shape playerLastShape;
    
    private Shape enemyShape;
    private Action enemyAction;
    private Shape enemyLastShape;

    [Header("Misc")]
    [SerializeField] private int floorHeight;
    [SerializeField] private float transitionTime = 0.5f;

    public void SetInitialShapes(Shape playerShape, Shape enemyShape)
    {
        this.playerShape = playerShape;
        this.enemyShape = enemyShape;
        playerLastShape = playerShape;
        enemyLastShape = enemyShape;

        PlayIdleAnimation(player.transform, playerAnimator, playerShape);
        PlayIdleAnimation(enemy.transform, enemyAnimator, enemyShape);
    }

    private void PlayIdleAnimation(Transform fighter, Animator animator, Shape shape)
    {
        animator.Play(shape.idle.name);
        SetSize(fighter, shape);
    }

    private Vector3 GetNewPosition(Transform fighter, Lanes[] lanesPosition)
    {
        float x = fighter.position.x;

        int lanes = lanesPosition.Length;
        float yScale = fighter.localScale.y;

        float yPos = yScale * lanes / 2f + floorHeight + (int)lanesPosition[0] * yScale;
        Vector3 newPosition = new Vector2(x, yPos);

        return newPosition;
    }

    private void SetSize(Transform fighter, Shape shape)
    {
        Vector3 newPosition = GetNewPosition(fighter, shape.lanesPosition);
        Debug.Log(newPosition);
        
        StartCoroutine(MoveToPosition(fighter, newPosition, transitionTime));
    }

    private void SetSize(Transform fighter, Action action)
    {
        Vector3 newPosition = GetNewPosition(fighter, action.lanesPosition);
        
        if(action.returnAfter){
            StartCoroutine(MoveToPosition(fighter, newPosition, transitionTime, fighter.position));
            return;
        }
        StartCoroutine(MoveToPosition(fighter, newPosition, transitionTime));
    }

    public void ChangeBattleAnimations(BattleStatus battleStatus)
    {
        PlayAction(player.transform, playerAnimator, battleStatus.playerAction);
        PlayAction(enemy.transform, enemyAnimator, battleStatus.enemyAction);
    }

    private void PlayAction(Transform fighter, Animator animator, Action action)
    {
        animator.Play(action.animation.name);
        SetSize(fighter, action);
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
    
    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove, Vector3 returnPosition)
    {
        yield return StartCoroutine(MoveToPosition(transform, position, timeToMove));
        yield return new WaitForSeconds(timeToMove);
        yield return StartCoroutine(MoveToPosition(transform, returnPosition, timeToMove));
    }
}
