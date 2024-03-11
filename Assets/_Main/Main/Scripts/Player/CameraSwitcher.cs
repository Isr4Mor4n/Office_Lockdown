using UnityEngine;
using TMPro;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] cameras;
    public TextMeshProUGUI cameraIndicatorText;
    public TextMeshProUGUI cameraIndicatorTextBackground;
    private int currentCameraIndex;

    void Start()
    {
        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }
        if (cameras.Length > 0)
        {
            cameras[0].SetActive(true);
            currentCameraIndex = 0;
            UpdateCameraIndicator();
        }
    }

    // Método para avanzar a la siguiente cámara
    public void SwitchCameraForward()
    {
        SwitchCamera(true);
    }

    // Método para regresar a la cámara anterior
    public void SwitchCameraBackward()
    {
        SwitchCamera(false);
    }

    // Método para actualizar la cámara activa
    private void SwitchCamera(bool forward)
    {
        cameras[currentCameraIndex].SetActive(false);

        if (forward)
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }
        }
        else
        {
            if (currentCameraIndex <= 0)
            {
                currentCameraIndex = cameras.Length - 1;
            }
            else
            {
                currentCameraIndex--;
            }
        }

        cameras[currentCameraIndex].SetActive(true);
        UpdateCameraIndicator();
    }

    void UpdateCameraIndicator()
    {
        if (cameraIndicatorText != null)
        {
            cameraIndicatorText.text = "0" + (currentCameraIndex + 1).ToString();
        }
        if (cameraIndicatorTextBackground != null)
        {
            cameraIndicatorTextBackground.text = "0" + (currentCameraIndex + 1).ToString();
        }
    }
}
