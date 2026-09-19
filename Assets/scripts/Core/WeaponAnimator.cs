using UnityEngine;
using DG.Tweening;

public class WeaponAnimator : MonoBehaviour
{
    [Header("Thrust Settings")]
    public float thrustDistance = 1f;
    public float thrustDuration = 0.12f;

    [Header("Sweep Settings")]
    public float swingDuration = 0.25f;
    public float leftY = -140f;
    public float rightY = -220f;
    private bool swingRight = true;

    [Header("Punch Settings")]
    public Transform punchObject1;
    public Transform punchObject2;
    public float punchDuration = 0.2f;
    public float delayBetweenPunches = 0.1f;

    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    private void Awake()
    {
        originalLocalPosition = transform.localPosition;
        originalLocalRotation = transform.localRotation;
    }

    public void PlayAnimation(SkillAnimationType animType)
    {
        transform.DOKill();
        transform.localPosition = originalLocalPosition;
        transform.localRotation = originalLocalRotation;

        switch (animType)
        {
            case SkillAnimationType.Sweep: SweepWeapon(); break;
            case SkillAnimationType.Thrust: ThrustWeapon(); break;
            case SkillAnimationType.Punch: PunchWeapon(); break;
        }
    }

    private void SweepWeapon()
    {
        float targetY = swingRight ? rightY : leftY;
        swingRight = !swingRight;

        transform.DOLocalRotate(new Vector3(0, targetY, 0), swingDuration)
                 .SetEase(Ease.OutSine)
                 .SetLoops(2, LoopType.Yoyo);
    }

    private void ThrustWeapon()
    {
        transform.DOLocalMoveZ(originalLocalPosition.z + thrustDistance, thrustDuration)
                 .SetEase(Ease.OutSine)
                 .SetLoops(2, LoopType.Yoyo);
    }

    private void PunchWeapon()
    {
        Sequence punchSequence = DOTween.Sequence();

        if (punchObject1 != null)
        {
            punchSequence.Append(punchObject1.DOLocalMoveX(-1f, punchDuration)
                .SetRelative()
                .SetEase(Ease.InOutSine)
                .SetLoops(2, LoopType.Yoyo));
        }

        punchSequence.AppendInterval(delayBetweenPunches);

        if (punchObject2 != null)
        {
            punchSequence.Append(punchObject2.DOLocalMoveX(-1f, punchDuration)
                .SetRelative()
                .SetEase(Ease.InOutSine)
                .SetLoops(2, LoopType.Yoyo));
        }
    }

}
