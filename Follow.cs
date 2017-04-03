public class Follow : MonoBehaviour
{
    public enum FindEnemyStep { Idle, Find, Rot, Move }
    public Transform target = null;
    public FindEnemyStep step = FindEnemyStep.Idle;
    Vector3 m_TargetDir;
    Vector3 m_Cross;
    float angle = 0f;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (FindEnemyStep.Idle == step)
            {
                step = FindEnemyStep.Find;
            }
        }

        switch (step)
        {
            case FindEnemyStep.Find:
                {
                    m_TargetDir = target.position - transform.position;
                    m_TargetDir.Normalize();
                    m_Cross = Vector3.Cross(transform.forward, m_TargetDir);
                    float dot = Vector3.Dot(transform.forward, m_TargetDir);
                    angle = Mathf.Acos(dot);
                    angle = angle * Mathf.Rad2Deg;
                    step = FindEnemyStep.Rot;
                }
                break;

            case FindEnemyStep.Rot:
                {
                    if (2.0f > angle)
                    {
                        transform.forward = m_TargetDir;
                        step = FindEnemyStep.Move;
                    }
                    else {
                        angle = Mathf.Acos(Vector3.Dot(transform.forward, m_TargetDir));
                        angle = angle * Mathf.Rad2Deg;
                        transform.Rotate(m_Cross, Time.deltaTime * 10);
                    }
                }
                break;

            case FindEnemyStep.Move:
                { transform.position = transform.position + (transform.forward * Time.deltaTime * 5); }
                break;

        }

    }
}
