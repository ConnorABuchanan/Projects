using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
#if MACCATALYST
using Microsoft.Maui.Graphics.Platform;
#else
using Microsoft.Maui.Graphics.Win2D;
#endif

namespace TheNiceList
{
    public class PresentPanel : IDrawable
    {
        private IImage present;
        private bool loaded = false;
        private bool opened = false;

#if MACCATALYST
    private IImage loadImage(string name)
    {
        Assembly assembly = GetType().GetTypeInfo().Assembly;
        return PlatformImage.FromStream(assembly.GetManifestResourceStream($"{name}"));
    }
#else
        private IImage loadImage(string name)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            var service = new W2DImageLoadingService();
            return service.FromStream(assembly.GetManifestResourceStream($"{name}"));
        }
#endif

        public PresentPanel() { }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (!loaded)
            {
                loadImage("../present.png");
                loaded = true;
            }
            canvas.DrawImage(present, 0, 0, 500f, 500f);
        }
    }
}
