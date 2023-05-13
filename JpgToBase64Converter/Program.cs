using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide a path to an image file.");
            return;
        }

        string imagePath = args[0];

        try
        {
            using (Image image = Image.FromFile(imagePath))
            {
                // Check if the image format is valid
                if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        Console.WriteLine(base64String);
                    }
                }
                else
                {
                    Console.WriteLine("The file is not a valid image format.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
