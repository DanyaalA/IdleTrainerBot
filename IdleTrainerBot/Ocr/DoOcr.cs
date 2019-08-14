﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IdleTrainerBot.Ocr
{
    class DoOcr
    {
        public static async Task<String> DoAsync(System.Drawing.Point Location, System.Drawing.Size SizeOfRec)
        {
            Rectangle section = new Rectangle(Location, SizeOfRec);

            Bitmap ScreenCap = WindowCapture.CaptureApplication("Nox");
            Bitmap ExtractedPart = new Bitmap(section.Width, section.Height);

            Graphics G = Graphics.FromImage(ExtractedPart);

            G.DrawImage(ScreenCap, 0, 0, section, GraphicsUnit.Pixel);

            string respones = string.Empty;


            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(1, 1, 1);


                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent("34209c846288957"), "apikey"); //Added api key in form data // WHEN SERVER IS UP GET API KEY FROM SERVER
                form.Add(new StringContent("eng"), "language");
                form.Add(new StringContent("1"), "OCREngine");

                ExtractedPart.Save("Image.png");
                byte[] imageData = File.ReadAllBytes("Image.png");
                form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "image", "image.jpg");

                HttpResponseMessage response = await httpClient.PostAsync("https://api.ocr.space/Parse/Image", form);

                string strContent = await response.Content.ReadAsStringAsync();


                Rootobject ocrResult = JsonConvert.DeserializeObject<Rootobject>(strContent);

                if (ocrResult.OCRExitCode == 1)
                {
                    for (int i = 0; i < ocrResult.ParsedResults.Count(); i++)
                    {
                        respones = respones + ocrResult.ParsedResults[i].ParsedText;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + strContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respones;
        }

    }
}
