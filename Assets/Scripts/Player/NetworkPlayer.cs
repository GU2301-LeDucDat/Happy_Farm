using Fusion;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype MainCharacter;

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            MainCharacter.Move(5 * data.direction * Runner.DeltaTime);
            MainCharacter.AnimationController();
        }
        else
        {
            MainCharacter.StopMove();
        }
    }
}
