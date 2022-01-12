using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace imagegenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1200;
            int height = 1200;
            int amount = 10;

            var rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < amount; i++)
            {
                var rRed = (byte)rand.Next(256);
                var rGreen = (byte)rand.Next(256);
                var rBlue = (byte)rand.Next(256);
                using (FileStream pngStream = new FileStream($"images/image-{i}.png", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var image = new Image<Rgba32>(width, height))
                    {   var rgb = new Rgba32(rRed, rGreen, rBlue);
                        image.Mutate(x => x.BackgroundColor(rgb));
                        image.SaveAsPng(pngStream);
                    }
                }
            }
        }
    }
}