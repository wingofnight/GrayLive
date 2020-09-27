using System;
using System.Drawing;
using static System.Console;

namespace GrayLive
{
    class Program
    {             
        static void Main(string[] args)
        {
            string puth;
             Bitmap bmp;
            Logo logo = new Logo();
            
            do
            {
                Clear();
                logo.print();
                WriteLine("\n\nHello user\n\nIf you wont more gray in you live press ENTER");
                ConsoleKeyInfo getch = ReadKey(true);
                if (getch.Key == ConsoleKey.Enter)
                {
                    while (true)
                    {
                        Clear();
                        logo.print();
                        WriteLine("\n\nOK, just enter the puth to file end press \"ENTER\"\n\n");
                        ForegroundColor = ConsoleColor.DarkYellow;
                        puth = ReadLine();
                        ResetColor();
                        LoadPicture(puth);
                    }                    
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n\nIT IS NOT A ENTER!!! PRESS ENTER, YOU!!!");
                    ResetColor();
                    ReadKey();
                }
            } while (true);                  
           
            void LoadPicture(string filename)
            {
                
                try
                {
                    bmp = new Bitmap(Image.FromFile(filename));
                    ChangePicture();
                    ForegroundColor = ConsoleColor.DarkGreen;
                    WriteLine("\n\nPicture Change!");
                    ResetColor();
                    ReadKey();
                }
                catch (Exception)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n\nAdress is not foud 404");
                    ResetColor();
                    ReadKey();
                }
            }
            void ChangePicture()
            {
                int size = puth.Length - 4;
                string F_name;
                F_name = puth;
                F_name = F_name.Remove(size, 4);
                Bitmap res = new Bitmap(bmp);
                for (int y = 0; y < bmp.Height; y++)
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixel = bmp.GetPixel(x, y);

                        pixel = ChangeGrayscale(pixel);

                        res.SetPixel(x, y, pixel);
                    }
                res.Save(F_name + "-result.jpg");
            }
            Color ChangeGrayscale(Color pixel)
            {
                int avg = (pixel.R + pixel.G + pixel.B + 1) / 3;
                return Color.FromArgb(avg, avg, avg);
            }          

        }

    }
   
}
