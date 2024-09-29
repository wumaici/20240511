using System.Collections;

using System.Collections.Generic;

using System.Diagnostics;

using UnityEngine;



public class grabbable : MonoBehaviour

{

    public bool grabable = true;

    //用来标记物件是不是可以被抓取



    // Start is called before the first frame update

    void Start()

    {

        transform.GetComponent<Rigidbody>().drag = 5;

        transform.GetComponent<Rigidbody>().angularDrag = 10;

        //增加物体移动和旋转阻力，免得动不动就到处乱飘。



        //注意别忘了给物体添加Rigidbody组件和collide组件啊，不然这个脚本就没用，而且会报错。

    }



    // Update is called once per frame

    void Update()

    {

    }

}
