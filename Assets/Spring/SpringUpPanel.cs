using UnityEngine;

public class SpringUpPanel : MonoBehaviour
{
    [SerializeField] private Rigidbody _upPanel;

    private float _currentTension = 0;

    public void SetTension(float tension)
    {
        _currentTension = tension;
    }

    private void Update()
    {
        if (_currentTension == 0)
        {
            return;
        }

        _upPanel.AddForce(-_upPanel.transform.up * _currentTension);
    }
}
