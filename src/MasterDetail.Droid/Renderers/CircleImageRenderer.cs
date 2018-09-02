﻿using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using MasterDetail.Droid.Renderers;
using MasterDetail.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(CircleImage), typeof(CircleImageRenderer))]

namespace MasterDetail.Droid.Renderers
{
    public class CircleImageRenderer : ImageRenderer
    {
        public CircleImageRenderer(Context context) : base(context)
        {
        }

        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;
                radius -= strokeWidth / 2;

                //Create path to clip
                var path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);

                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                // Create path for circle border
                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

                var paint = new Paint
                {
                    AntiAlias = true,
                    StrokeWidth = 5
                };
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = Color.White;

                canvas.DrawPath(path, paint);

                //Properly dispose
                paint.Dispose();
                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }

        protected void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
                if ((int) Build.VERSION.SdkInt < 18)
                    SetLayerType(LayerType.Software, null);
        }
    }
}