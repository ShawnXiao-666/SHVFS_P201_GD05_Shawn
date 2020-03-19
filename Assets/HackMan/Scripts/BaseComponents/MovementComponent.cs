using UnityEngine;

public class MovementComponent : BaseGirdObject
{
    public float MovementSpeed;
    protected IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;
    protected IntVector2 currentInputDirection;
    private IntVector2 previousInputDirection;

    private void Start()
    {
        targetGridPosition = GridPosition;
    }

    protected virtual void Update()
    {
        // If we have arrived...
        if (transform.position == targetGridPosition.AsVector3())
        {
            progressToTarget = 0f;
            GridPosition = targetGridPosition;
        }

        // If we have arrived -- we need to set a new target -- and if current input is valid
        if (GridPosition == targetGridPosition &&
            LevelGenerator.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),
                Mathf.Abs(targetGridPosition.x + currentInputDirection.x)] != 1)
        {
            targetGridPosition += currentInputDirection;
            previousInputDirection = currentInputDirection;
        }

        // If we set a new target, and previous input is valid
        else if (GridPosition == targetGridPosition &&
            LevelGenerator.Grid[Mathf.Abs(targetGridPosition.y + previousInputDirection.y),
                Mathf.Abs(targetGridPosition.x + previousInputDirection.x)] != 1)
        {
            targetGridPosition += previousInputDirection;
        }

        // If we have arrived, and no input was valid
        if (GridPosition == targetGridPosition) return;

        // Movement Logic
        progressToTarget += MovementSpeed * Time.deltaTime;

        // Set the position, Lerp towards the target
        transform.position = Vector3.Lerp(GridPosition.AsVector3(), targetGridPosition.AsVector3(), progressToTarget);
    }
}
