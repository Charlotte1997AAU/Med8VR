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
        const float fpsMeasurePeriod = 1f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        private double avg_fps;
        private Text m_Text;
        private string filePath;

        // File path for the output file


        private List<int> fpsList = new List<int>();

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();
            string directory = Application.persistentDataPath + "/TXTfiles/";
            string fileName = "fps" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            filePath = directory + fileName;
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
        }

        // Method to write FPS value to the text file
        
        private void WriteToFpsFile()
        {
            avg_fps = fpsList.Average();
            Debug.Log("avg fps: " + avg_fps);

            // Append the FPS value to the file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                Debug.Log("written data");
                writer.WriteLine(avg_fps); 
                writer.WriteLine("Hello :3");   
            }
        }
        

        public void saveFps(){ 
            Debug.Log("Saved data to " + filePath);         
            WriteToFpsFile();
         }
    }
}
