using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    #region 欄位與屬性
    /// <summary>
    /// 玩家變形元件
    /// </summary>
    private Transform player;

    [Header("追蹤速度"), Range(0.1f, 50.5f)]
    public float speed = 1.5f;
    #endregion

    #region 方法
    /// <summary>
    /// 追蹤玩家
    /// </summary>
    private void Track()
    {
        //攝影機與小明 Y 軸距離 2.328 - 0.06 = 2.268
        //攝影機與小明 Z 軸距離 -2.109 - 0 = -2.857
        Vector3 posTrack = player.position;
        posTrack.y += 2.268f;
        posTrack.z += -2.109f;

        //攝影機座標 = 變形.座標
        Vector3 posCam = transform.position;
        //攝影機座標 = 三維向量.插值(A邊, B點, 百分比)
        posCam = Vector3.Lerp(posCam, posTrack, 0.5f * Time.deltaTime * speed);
        //變形.座標 = 攝影機座標
        transform.position = posCam;
    }
    #endregion

    #region 事件

    /* 實驗 Lerp 插值...
    public float A = 0;
    public float B = 100;

    private void Update()
    {
        A = Mathf.Lerp(A, B, 0.5f);

        v2A = Vector3.Lerp(v2A, v2B, 0.5f);
    }
    */

    private void Start()
    {
        player = GameObject.Find("小明").transform;
    }

    //延遲更新：會在 Update 執行後再執行
    //建議：需要追蹤座標要寫在此事件內
    private void LateUpdate()
    {
        Track();
    }
    #endregion
}
