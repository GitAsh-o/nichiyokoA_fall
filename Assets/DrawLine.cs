using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private GameObject dummyObjtPref = default;

    [SerializeField] private Transform dummyObjtParent = default;

    [SerializeField] private Vector3 v0 = default;

    [SerializeField] private int dummyCount = 10;

    [SerializeField] private float secInterval = 0.15f;

    private List<GameObject> dummySphereList = new List<GameObject>();
    private Rigidbody2D rigid = default;

    //重なっているか否か
    bool isOverlap = false;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (!rigid) rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.isKinematic = true;

        dummyObjtParent.transform.position = transform.position;

        for (int i = 0; i < dummyCount; i++)
        {
            var obj = (GameObject)Instantiate(dummyObjtPref, dummyObjtParent);
            dummySphereList.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dummyCount; i++)
        {
            var t = i * secInterval + 0.15f;
            var x = t * v0.x;
            var z = t * v0.z;
            var y = (v0.y * t) - 0.5f * (-Physics.gravity.y * 0.6f) * Mathf.Pow(t, 2.0f);
            dummySphereList[i].transform.localPosition = new Vector3(x, y, z);

            //前のupdateのタイミングでsetActiveをfalseにしたものをtrueに戻す
            dummySphereList[i].SetActive(true);

            //Rayを飛ばす
            RaycastHit2D hit = Physics2D.Raycast(dummySphereList[i].transform.position, new Vector3(0, 0, 1), 100);

            //もし何かに当たったら
            if (hit.collider)
            {
                dummySphereList[i].SetActive(false);
                isOverlap = true;
            }

            //当たった先にある予測線の処理
            if (isOverlap == true)
            {
                dummySphereList[i].SetActive(false);
            }

        }
        //for文の処理(全ての予測線の上書き)が終わったタイミングで、次の判定に備えてisOverlapはfalseに戻しておく
        isOverlap = false;
    }

    public void Set(Vector3 v3)
    {
        v0 = v3;
    }
}
