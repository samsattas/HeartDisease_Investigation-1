﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace TestingConectionToServerPython.Model
{
    public class Conecction
    {
        public Conecction() {
            
        }
        public string GetReleases1(string url) {
            var client = new WebClient();
            client.Headers.Add("dd");
            var response = client.DownloadString(url);
            return response;
        }
        public string ConnectionTest(string uirWebAPI, string exceptionMessage) {
            exceptionMessage=string.Empty;
            string webResponse = string.Empty;
          //  try
           // {
                Uri uri = new Uri(uirWebAPI);
                WebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.ContentType = "application/xml";
            httpWebRequest.Method = "POST";
                
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) 
                {
                    //Esto es lo que envia al servidor (?) Si creo que si
                   
                    //dynamic employee = new Object();
                    //employee.username = "theUserName";
                    //employee.password = "thePassword";
                    //streamWriter.Write("d");
                   
                }
                
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    webResponse = streamReader.ReadToEnd();
                }
           // }
          //  catch(Exception ex)
           // {
           //     exceptionMessage = $"An error occurred. {ex.Message}";
           ///     Console.WriteLine(ex.Message);
           //     Console.ReadKey();
           // }
            return webResponse;
        }

        public string ConnectionTest2(string uirWebAPI)
        {
            string webResponse = string.Empty;
            Uri uri = new Uri(uirWebAPI);
            WebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
              
            }
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                webResponse = streamReader.ReadToEnd();
            }
            
            return webResponse;
        }
        public string ConnectionTest3(string uirWebAPI)
        {
            var client = new WebClient();
            var response = client.DownloadString(uirWebAPI);
            return response;
        }



    }
}
