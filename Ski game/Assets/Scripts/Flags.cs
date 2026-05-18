using UnityEngine;

public class Flags : MonoBehaviour
{
    private bool flagPassed = false;
    private enum Direction { Left, Right};
    [SerializeField] private Direction flagDirection;

    [SerializeField] private Material goodMat, badMat;

    public static event GameManager.TimerEvent RacePenalty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovment.playerPos != null && PlayerMovment.playerPos.position.z < transform.position.z && !flagPassed)
        {
            flagPassed = true;
            Direction passingDirection = Direction.Right;
            if(PlayerMovment.playerPos.position.x < transform.position.x) passingDirection = Direction.Left;
            MeshRenderer rendered = GetComponent<MeshRenderer>();
            if (passingDirection == flagDirection)
            {
                rendered.material = goodMat;
            }
            else
            {
                rendered.material = badMat;
                RacePenalty?.Invoke();
            }
        }
    }
}
