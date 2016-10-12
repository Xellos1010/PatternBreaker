using System;
using UnityEngine;
    public class FPSTracker
    {

        //Stores the Real FPS
        private float accum = 0; // FPS accumulated over the interval
        private int frames = 0; // Frames drawn over the interval
        private float timeleft; // Left time for current interval
        public float fps = 30;
        public float updateInterval = 0.2F;
        // Update is called once per frame
        public void Update()
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;

            // Interval ended - update GUI text and start new interval
            if (timeleft <= 0.0)
            {
                // display two fractional digits (f2 format)
                fps = accum / frames;
                timeleft = updateInterval;
                accum = 0.0F;
                frames = 0;
            }
        }

}
