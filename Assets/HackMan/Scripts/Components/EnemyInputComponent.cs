using System.Collections.Generic;
using UnityEngine;

public class EnemyInputComponent : MovementComponent
{
    private IntVector2[] movementDirections = new[]
    {
        new IntVector2(0, 1),
        new IntVector2(0, -1),
        new IntVector2(-1, 0),
        new IntVector2(1, 0),
    };

    protected override void Update()
    {
        if (transform.position == targetGridPosition.AsVector3())
        {
            var possibleDirections = new List<IntVector2>();

            foreach (var movementDirection in movementDirections)
            {
                IntVector2 potentialTargetPosition = targetGridPosition + movementDirection;

                if (LevelGenerator.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),
                    Mathf.Abs(targetGridPosition.x + currentInputDirection.x)] != 1)
                {
                    if (currentInputDirection != -movementDirection)
                    {
                        possibleDirections.Add(movementDirection);
                    }
                }
            }

            if (possibleDirections.Count < 1)
            {
                possibleDirections.Add(-currentInputDirection);
            }

            int direction = Random.Range(0, possibleDirections.Count);
            currentInputDirection = possibleDirections[direction];
        }

        base.Update();
    }
}
