using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSloc : MonoBehaviour
{
    public static GPSloc Instance { set; get; }
    public double Longi;
    public double Lat;
    public Text GPStext;
    public Text LOGtext;
    // Start is called before the first frame update

    /*void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(GetLocation());             
    }
    private IEnumerator GetLocation()
    {
        Input.location.Start(0.5f);
        if(Input.location.status == LocationServiceStatus.Running)
        {
            LOGtext.text = "연결성공";
        }
        if (!Input.location.isEnabledByUser)
        {
            LOGtext.text = "로케이션 설정오류";
            yield break;
        }
      
        int maxwait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxwait > 0)
        {
            yield return new WaitForSeconds(1);
            maxwait--;
        }
        if(maxwait <=0)
        {
            LOGtext.text = "시간아웃";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            LOGtext.text = "서비스 상태 오류";
            yield break;
        }

        Lat = Input.location.lastData.latitude;
        Longi = Input.location.lastData.longitude;
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
      
    }*/
    bool gpsInit = false;

    LocationInfo currentGPSPosition;

    int gps_connect = 0;
    double detailed_num = 1.0;
    void Start()

    {

        Input.location.Start(0.5f);



        int wait = 1000; // 기본 값

        // Checks if the GPS is enabled by the user (-> Allow location ) 

        if (Input.location.isEnabledByUser)//사용자에 의하여 좌표값을 실행 할 수 있을 경우

        {
            LOGtext.text = "연결성공";
            while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)//초기화 진행중이면

            {

                wait--; // 기다리는 시간을 뺀다

            }

            //GPS를 잡는 대기시간

            if (Input.location.status != LocationServiceStatus.Failed)//GPS가 실행중이라면

            {

                gpsInit = true;
                LOGtext.text = "GPS실행중";
                // We start the timer to check each tick (every 3 sec) the current gps position

                InvokeRepeating("RetrieveGPSData", 0.0001f, 1.0f);//0.0001초에 실행하고 1초마다 해당 함수를 실행합니다.

            }

        }

        else//GPS가 없는 경우 (GPS가 없는 기기거나 안드로이드 GPS를 설정 하지 않았을 경우
        {
            LOGtext.text = "GPS못찾음";
            GPStext.text = "GPS not available";
        }

    }

    void RetrieveGPSData()
    {

        currentGPSPosition = Input.location.lastData;//gps를 데이터를 받습니다.
        Longi = currentGPSPosition.longitude * detailed_num;
        Lat = currentGPSPosition.latitude * detailed_num;
       // GPStext.text = "위도 " + Longi.ToString() + "\n경도: "+ Lat.ToString();//위도 값을 받아,텍스트에 출력합니다
        gps_connect++;

    }

}

