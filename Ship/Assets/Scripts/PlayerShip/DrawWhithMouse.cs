using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private BulletPlayer _bullet;

    private List<Vector3> _mousePositionList = new();
    private bool _isDrawing = false;

    private void Update()
    {
        ActiveDraw();
        DrawVector();
        EnableDraw();
    }

    private void EnableDraw()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
            StartCoroutine(MoveBullet());
        }
    }

    private void DrawVector()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 _currentMousePosition = Camera.main.ScreenToWorldPoint
                (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 19));

            if (_mousePositionList.Count == 0 || Vector3.Distance(_mousePositionList[_mousePositionList.Count - 1], _currentMousePosition) > 0.1f)
            {
                _mousePositionList.Add(_currentMousePosition);
                _lineRenderer.positionCount = _mousePositionList.Count;
                _lineRenderer.SetPosition(_mousePositionList.Count - 1, _currentMousePosition);
            }
        }
    }

    private void ActiveDraw()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDrawing = true;
            _mousePositionList.Clear();
            _lineRenderer.positionCount = 0;
        }
    }

    private IEnumerator MoveBullet()
    {
        BulletPlayer bullet = Instantiate(_bullet, transform.position, Quaternion.identity);

        for (int i = 0; i < _mousePositionList.Count; i++)
        {
            while (Vector3.Distance(bullet.transform.position, _mousePositionList[i]) > 0.1f) 
            {
                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, _mousePositionList[i], Time.deltaTime * 10);
                yield return null;
            }
        }
    }
}

