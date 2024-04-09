using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof(Text))]
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        private double avg_fps;
        const string display = "{0} FPS";
        private Text m_Text;

        // File path for the output file
        private string directory = Application.dataPath + "/TXTfiles/";

        private List<int> fpsList = new List<int>();

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();
            
            
        }

        private void Update()
        {
            // Measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                //Debug.Log("current FPS: " + m_CurrentFps);
                fpsList.Add(m_CurrentFps);                
            }
            SaveToPlayerPrefs();
        }

        // Method to write FPS value to the text file
        /*
        private void WriteToFpsFile(int fps)
        {
            string fileName = "fps" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            string filePath = directory + fileName;

            // Append the FPS value to the file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (int fpsValue in fpsList){
                    writer.WriteLine(fpsValue);
                }
            }
        }
        */

        public void SaveToPlayerPrefs()
        {
            avg_fps = fpsList.Average();

            int current_avg = (int)avg_fps;
            PlayerPrefs.SetInt("avg FPS" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), current_avg);
        }

         void OnApplicationQuit(){
            Debug.Log("Avg FPS: " + avg_fps);
            SaveToPlayerPrefs();
         }
    }
}
