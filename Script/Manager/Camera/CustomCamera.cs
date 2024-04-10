using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    /*******************************º¯¼ö*******************************/

    Transform target;
    Vector3 camPos = new Vector3(0, 11.0f, -7.0f);
    
    List<MeshRenderer> alphaList = new List<MeshRenderer>();


    /******************************************************************/

    public void CameraAlphaList() 
    {
        if(alphaList.Count > 0)
        {
            foreach(var one in alphaList)
            {
                Color color = one.material.color;
                color.a = 1f;
                one.material.color = color;
            }

            alphaList.Clear();
        }

        RaycastHit[] hitInfo =
          Physics.RaycastAll(transform.position, GameManager.Inst.PLAYER.transform.position - transform.position);
                
        for(int i = 0; i < hitInfo.Length; i++)
        {
            if (hitInfo[i].collider.CompareTag("Building"))
            {
                MeshRenderer mesh = hitInfo[i].collider.GetComponent<MeshRenderer>();
                Color color = mesh.material.color;
                color.a = 0.2f;
                mesh.material.color = color;
                alphaList.Add(mesh);

                Debug.Log(mesh.gameObject.name);
            }

           
        }

        //Debug.DrawLine(transform.position, GameManager.Inst.PLAYER.gameObject.transform.position);
    }



    void Start()
    {
        target = GameManager.Inst.PLAYER.transform;
    }
 
    private void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X");

        
        /*
        if (Input.GetMouseButton(1) &&
            x > 0f)
        {

            transform.RotateAround(target.position, Vector3.up, 1.0f);
            camPos = transform.position - target.position;

        }

        if (Input.GetMouseButton(1) &&
            x < 0f)
        {

            transform.RotateAround(target.position, Vector3.up, -1.0f);
            camPos = transform.position - target.position;

        }
        */

        transform.position = target.position + camPos;
        transform.LookAt(target);

        CameraAlphaList();
    }
}
