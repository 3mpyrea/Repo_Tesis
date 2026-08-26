using UnityEngine;

public class EnterCombat : MonoBehaviour
{
    [SerializeField] GameObject _thirdPersonCam;
    [SerializeField] GameObject _firstPersonCam;

    private void OnTriggerEnter(Collider other)
    {
        _thirdPersonCam.SetActive(false);
        _firstPersonCam.SetActive(true);

        foreach (Transform child in other.transform)
        {
            SetCameraPos(child.transform);
        }
    }

    void SetCameraPos(Transform newPos)
    {
        GameManager.instance.canvas.SetActive(true);
        _firstPersonCam.transform.position = newPos.position;
        gameObject.SetActive(false);
    }
}
