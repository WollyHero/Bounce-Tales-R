using UnityEngine;
using Cinemachine;

public class CameraBounce : MonoBehaviour
{
    [SerializeField] private float bounceDuration = 0.2f;
    [SerializeField] private float bounceIntensity = 0.5f;

    private CinemachineVirtualCamera vcam;
    private float initialOrthographicSize;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float elapsedTime;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        initialOrthographicSize = vcam.m_Lens.OrthographicSize;
    }

    private void OnEnable()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        elapsedTime = 0f;

        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    private float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse Y" || axisName == "Mouse X")
            return Input.GetAxis(axisName) * Time.unscaledDeltaTime;

        return Input.GetAxis(axisName);
    }

    private void Update()
    {
        if (vcam.Follow == null)
            return;

        if (elapsedTime < bounceDuration)
        {
            float normalizedTime = elapsedTime / bounceDuration;
            float bounceValue = Mathf.Sin(normalizedTime * Mathf.PI) * bounceIntensity * (1f - normalizedTime);
            float orthoSize = initialOrthographicSize + bounceValue;
            Vector3 position = Vector3.Lerp(initialPosition, vcam.Follow.position, normalizedTime);
            Quaternion rotation = Quaternion.Lerp(initialRotation, vcam.Follow.rotation, normalizedTime);
            vcam.m_Lens.OrthographicSize = orthoSize;
            transform.position = position;
            transform.rotation = rotation;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            vcam.m_Lens.OrthographicSize = initialOrthographicSize;
            transform.position = vcam.Follow.position;
            transform.rotation = vcam.Follow.rotation;
        }
    }
}
