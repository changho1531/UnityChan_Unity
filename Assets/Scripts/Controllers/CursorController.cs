using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class CursorController : MonoBehaviour
{
    int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

    Texture2D _attackIcon;
    Texture2D _handIcon;

    CursorType _cursorType = CursorType.None;

    public enum CursorType
    {
        None,
        Attack,
        Hand
    }
    void Start()
    {
        _attackIcon = Managers.Resource.Load<Texture2D>("Textures/Curosr/Attack");
        _handIcon = Managers.Resource.Load<Texture2D>("Textures/Curosr/Hand");
    }

    void Update()
    {
        //마우스를 누른 상태면 아이콘을 고정시키기 위함
        if (Input.GetMouseButton(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, _mask))
        {
            if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                if (_cursorType != CursorType.Attack)
                {
                    //                             UI커서 작용 지점
                    Cursor.SetCursor(_attackIcon, new Vector2(_attackIcon.width / 5, 0), CursorMode.Auto);
                    _cursorType = CursorType.Attack;
                }
            }
            else
            {
                if (_cursorType != CursorType.Hand)
                {
                    Cursor.SetCursor(_handIcon, new Vector2(_handIcon.width / 3, 0), CursorMode.Auto);
                    _cursorType = CursorType.Hand;
                }
            }
        }
    }
}
