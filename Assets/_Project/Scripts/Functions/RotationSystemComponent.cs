using System.Collections;
using UnityEngine;

public class RotationSystemComponent : MonoBehaviour
{

    [SerializeField] private float _waitTime = 1;
    [SerializeField] [Range(5, 50)] private int _speedRotation = 5;
    [SerializeField] private RotateMovimentType _rotateSelect;
    [SerializeField] private float _duration = 5;
    [SerializeField] private float _timerCount;

    private void Update()
    {
        SetRotation();
    }

    private void SetRotation()
    {
        switch (_rotateSelect)
        {
            case RotateMovimentType.Continuo:
                gameObject.transform.Rotate(new Vector3(0f, 10 * Time.deltaTime * _speedRotation, 0f));
                break;

            case RotateMovimentType.Continuo_Reverso:
                gameObject.transform.Rotate(new Vector3(0f, -10 * Time.deltaTime * _speedRotation, 0f));
                break;

            case RotateMovimentType.Intermitente:

                _timerCount += Time.deltaTime;

                if (Timer() != false)
                {
                    gameObject.transform.Rotate(new Vector3(0f, 10 * Time.deltaTime * _speedRotation, 0f));                    
                }
                else if (Timer() == false)
                {
                    StartCoroutine(RotationSystem());                    
                }
                break;

            case RotateMovimentType.Intermitente_Reverso:

                _timerCount += Time.deltaTime;

                if (Timer() != false)
                {
                    gameObject.transform.Rotate(new Vector3(0f, -10 * Time.deltaTime * _speedRotation, 0f));
                }
                else if (Timer() == false)
                {
                    StartCoroutine(RotationSystem());
                }
                break;
        }
    }
    private bool Timer()
    {
        if (_timerCount < _duration)
        {
            return true;
        }
        return false;
    }
    private IEnumerator RotationSystem()
    {
        yield return new WaitForSeconds(_waitTime);

        StopCoroutine(RotationSystem());
        _timerCount = 0;
    }
}