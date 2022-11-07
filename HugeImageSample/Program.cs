using System.Drawing;
using System.Drawing.Imaging;

// Available in windows only 
class Program
{
    
    static readonly string source = "image.jpg";
    static readonly ImageFormat sFormat = ImageFormat.Jpeg;

    static readonly string dest = "image.png";
    static readonly ImageFormat dFormat = ImageFormat.Png;

    static void Main(string[] args)
    {
        StdCopyImage1();
        StdCopyImage2();
    }

    private static void StdCopyImage1()
    {
        try
        {
            Bitmap img = new Bitmap(source);
            img.Save(dest, dFormat);

            Console.WriteLine("----- Case 1: OK");
        }
        catch (Exception)
        {
            Console.WriteLine("----- Case 1: KO");
        }
        finally
        {
            File.Delete(dest);
        }
    }

    private static void StdCopyImage2()
    {
        try
        {
            var bytes = File.ReadAllBytes(source);
            Bitmap b = new Bitmap(new MemoryStream(bytes));
            b.Save(dest, dFormat);

            Console.WriteLine("----- Case 2: OK");
        }
        catch (Exception)
        {
            Console.WriteLine("----- Case 2: KO");
        }
        finally
        {
            File.Delete(dest);
        }
    }

}