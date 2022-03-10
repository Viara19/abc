using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using TouchTracking;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace abcBLANK.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class writtingLetters : ContentPage
    {
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };
        public writtingLetters()
        {
            InitializeComponent();

        }

        void OnTouchEffectAction(object sender, SKTouchAction args, TouchActionEventArgs args1)
        {
            var coordinateX = args1.Location.X;
            var coordinateY = args1.Location.Y;
            switch (args1.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPaths.ContainsKey(args1.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(canvasView.CanvasSize.Width * coordinateX / 
                                canvasView.CanvasSize.Width, canvasView.CanvasSize.Width *
                                coordinateY / canvasView.CanvasSize.Width);
                        inProgressPaths.Add(args1.Id, path);
                        
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPaths.ContainsKey(args1.Id))
                    {
                        SKPath path = inProgressPaths[args1.Id];
                        path.LineTo(canvasView.CanvasSize.Width * coordinateX / 
                                canvasView.CanvasSize.Width, canvasView.CanvasSize.Width * 
                                coordinateY / canvasView.CanvasSize.Width);
                        
                         canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPaths.ContainsKey(args1.Id))
                    {
                        completedPaths.Add(inProgressPaths[args1.Id]);
                        inProgressPaths.Remove(args1.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPaths.ContainsKey(args1.Id))
                    {
                        inProgressPaths.Remove(args1.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

            }
            
        }
        void OnPainting(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;
            foreach (SKPath path in completedPaths)
            {
                canvas.DrawPath(path, paint);
            }

            foreach (SKPath path in inProgressPaths.Values)
            {
                canvas.DrawPath(path, paint);
            }
        }


        public class Resource
        {
            public class drawable
            {
                public const int a = 0x123;
               
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {//Another image
            image.Source = "b.png";

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}