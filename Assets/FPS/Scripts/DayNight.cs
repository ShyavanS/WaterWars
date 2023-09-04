//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CoordinateSharp;
//using System;
//using System.Net;
//using System.Globalization;

//// Uses real date and time to follow sunrise and sunset

//public class DayNight : MonoBehaviour
//{
//    double rate;
//    DateTime sunrise;
//    bool run = false;
//    double angle;
//    // Start is called before the first frame update
//    void Start()
//    {
//        string latitude = new WebClient().DownloadString("https://ipapi.co/latitude");
//        string longitude = new WebClient().DownloadString("https://ipapi.co/longitude");
//        double lat = double.Parse(latitude, System.Globalization.CultureInfo.InvariantCulture);
//        double lon = double.Parse(longitude, System.Globalization.CultureInfo.InvariantCulture);
//        DateTime d = DateTime.Now;
//        var offset = DateTimeOffset.Now.Offset;
//        string sign = offset < TimeSpan.Zero ? "-" : "+";
//        string o = offset.ToString(@"hh");
//        double off = double.Parse(o, System.Globalization.CultureInfo.InvariantCulture);
//        string o2 = offset.ToString(@"mm");
//        double off2 = double.Parse(o, System.Globalization.CultureInfo.InvariantCulture);
//        off2 = off2 / 60;
//        off = off + off2;
//        if (sign == "-")
//        {
//            off = off * -1;
//        }
//        Coordinate c = new Coordinate(lat, lon, d);
//        c.Offset = off;
//        sunrise = (DateTime)c.CelestialInfo.SunRise;
//        DateTime sunset = (DateTime)c.CelestialInfo.SunSet;
//        TimeSpan diff = sunset - sunrise;
//        rate = 180d / diff.TotalSeconds;
//        d = DateTime.Now;
//        TimeSpan diff2 = d - sunrise;
//        angle = rate * diff2.TotalSeconds;
//        if (angle > 180)
//        {
//            angle = (angle - 180) * -1;
//        }
//        else if (angle < -180)
//        {
//            angle = (angle + 180) * -1;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //float angleRecv = transform.rotation.x * 180;
//        //if ((int)angleRecv != (int)angle && run == false)
//        //{
//        //    angleRecv = transform.rotation.x * 180;
//        //    transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
//        //}
//        //else
//        //{
//        //    run = true;
//        if (run == false)
//        {
//            Quaternion originalRot = transform.rotation;
//            transform.rotation = originalRot * Quaternion.AngleAxis((float)angle, Vector3.right);
//            run = true;
//        }
//        else
//        {
//            Quaternion originalRot = transform.rotation;
//            transform.rotation = originalRot * Quaternion.AngleAxis((float)angle, Vector3.right);
//            //transform.RotateAround(Vector3.zero, Vector3.right, (float)rate * Time.deltaTime);
//            transform.LookAt(Vector3.zero);
//        }
//        //}
//    }
//}
