using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    //1. ������ RigidBody�� �־���Ѵ� ( IsKinematic :off)
    //2. ���� ������ Collider�� �־���Ѵ�( IsKinematic :off)
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log($"Collision !{collision.gameObject.name}");
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($"Trigger !{other.gameObject.name}");
    //}

    void Start()
    {
        
    }

    void Update()
    {
        //Local <-> World <-> Viewport <-> Screen(ȭ��)

        //Debug.Log(Input.mousePosition);  //ȭ�� �ȼ� ����
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // ȭ�� ����

        //���̾ ����� ���ϴ� �繰�� ĳ�����ϱ�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            //���̾�� ��Ʈ�� ���
            int mask = (1 << 8); //768 ���� �ǹ�;
            //LayerMask layer = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");  //mask�� ���� ����� �� ���������� �Ѱ�
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera {hit.collider.gameObject.tag}");
                Debug.Log($"Raycast Camera {hit.collider.gameObject.name}");
            }
        }

        ////�ؿ� ���� ����ȭ
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        Debug.Log($"Raycast Camera {hit.collider.gameObject.name}");    
        //    }
        //}

        // Ŭ���� ��ǥ�� ī�޶󿡼� ���� ����Ʈ���� � ������Ʈ���� �˾ƿ��°� Ǯ� ����
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;  //ī�޶󿡼� Ŭ���� ��ġ�� ���� ���� ���͸� ���Ѵ�
        //    dir = dir.normalized;  // ������ ũ�⸦ 1�� ����

        //������ ���
        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f)) ;
        //    {
        //        Debug.Log($"Raycast Camera {hit.collider.gameObject.name}");
        //    }
        //}
    }
}
