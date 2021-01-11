using System;
using Player;

public class MovePlayer : NetworkMovableWithTranslate
{
    private void Awake()
    {
        moveSpeed = 5f;
        rotateSpeed = 50;
    }
}
