using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class handler : MonoBehaviour

{

    public string targetName = "";

    //保存目标物体的名字。



    Transform targetTransform = null;

    //保存目标物体的坐标系。



    public Transform myself;

    //保存玩家自己作为参考。



    Vector3 targetEuler = new Vector3(0, 0, 0);

    //保存被抓取物体的相对旋转位置。



    Vector3 targetDistance = new Vector3(0, 0, 0);

    //保存被抓取物体相对抓把的位置。



    public Vector3 restAngle = new Vector3(0, 0, 0);





    Vector3 lastAngle = new Vector3(0, 0, 0);





    // Start is called before the first frame update

    void Start()

    {

        myself = transform.parent.parent.transform;

        //用来指定玩家自己，当抓取物体时给物体旋转做参考。  

    }



    // Update is called once per frame

    void Update()

    {

        KeyCode grabberKey = KeyCode.Mouse0;



        if (Input.GetKeyDown(grabberKey) && targetTransform != null)

        {

            lastAngle = myself.eulerAngles;

            targetEuler = targetTransform.GetComponent<Transform>().eulerAngles - myself.eulerAngles;

            targetDistance = targetTransform.position - transform.position;

            //抓取物件。

        }



        if (Input.GetKey(grabberKey) && targetTransform != null)

        {

            lastAngle = myself.eulerAngles - lastAngle;

            targetDistance = Quaternion.Euler(lastAngle) * targetDistance;

            lastAngle = myself.eulerAngles;



            targetTransform.position = transform.position + targetDistance;

            //当按下左边的shift的时候，拾取物体。物体的坐标等于抓把的坐标。

            targetTransform.eulerAngles = myself.eulerAngles + targetEuler;

            //当按下左边的shift的时候，拾取物体的旋转角度与抓把的联动。     

        }



        if (Input.GetAxis("Mouse ScrollWheel") != 0)

        {

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Input.GetAxis("Mouse ScrollWheel"));

        }











        if (Input.GetKeyDown(KeyCode.R))

        {

            targetEuler = restAngle;

            targetDistance = new Vector3(0, 0, 0);

            //当按下定义键的时候被抓物体姿势摆正。

        }





        if (Input.GetKeyDown(KeyCode.F3) && targetTransform != null)

        {

            targetTransform.GetComponent<Rigidbody>().useGravity = true;

            //开启被抓物体重力。

        }



        if (Input.GetKeyDown(KeyCode.F4) && targetTransform != null)

        {

            targetTransform.GetComponent<Rigidbody>().useGravity = false;

            //关闭被抓物体重力。

        }



        if (Input.GetKeyDown(KeyCode.F1))

        {

            transform.GetComponent<MeshRenderer>().enabled = false;

            //显示抓把。

        }

        if (Input.GetKeyDown(KeyCode.F2))

        {

            transform.GetComponent<MeshRenderer>().enabled = true;

            //隐藏抓把。

        }



        if (Input.GetKey(KeyCode.X))

        {

            targetEuler = new Vector3(targetEuler.x + 0.1f, targetEuler.y, targetEuler.z);

        }

        //按下则被抓物体沿x轴旋转。



        if (Input.GetKey(KeyCode.Z))

        {

            targetEuler = new Vector3(targetEuler.x, targetEuler.y, targetEuler.z + 0.1f);

        }

        //按下则被抓物体沿z轴旋转。



        if (Input.GetKey(KeyCode.Y))

        {

            targetEuler = new Vector3(targetEuler.x, targetEuler.y + 0.1f, targetEuler.z);

        }

        //按下则被抓物体沿y轴旋转。

    }



    private void OnTriggerEnter(Collider other)

    {



        if (other.TryGetComponent<grabbable>(out grabbable temp) & (targetName == ""))

        {

            transform.GetComponent<handler>().targetName = other.GetComponent<Transform>().name;

            targetTransform = other.GetComponent<Transform>();

            //玩家正面前方设有一个小球，设置为trigger属性，会与任何具有可抓取组件（grabbable脚本）的物体交互。与该物体接触时会设置一些属性。

        }

    }



    private void OnTriggerExit(Collider other)

    {

        if (other.GetComponent<Transform>().name == targetName)

        {

            transform.GetComponent<handler>().targetName = "";

            targetTransform = null;

            targetEuler = new Vector3(0, 0, 0);

            //玩家正面三米处设有一个小立方体，设置为trigger属性，会与任何具有可抓取组件（grabbable脚本）的物体交互。退出该接触时会清空一些属性。

        }

    }



}