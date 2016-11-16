// <copyright file="ColorExtensions.cs" company="">
// All rights reserved.
// </copyright>
// <author>https://github.com/XLabs/Xamarin-Forms-Labs</author>


#if !WINDOWS_PHONE
using Windows.UI.Xaml.Media;
using Windows.UI;
#else
using System.Windows.Media;
#endif

namespace XF.SignaturePad.WindowsShared
{
    /// <summary>
    /// Class ColorExtensions.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// To brush.
        /// </summary>
        /// <param name="color">Color to use.</param>
        /// <returns>New brush.</returns>
        public static Brush ToBrush(this Xamarin.Forms.Color color)
        {
            return new SolidColorBrush(color.ToMediaColor());
        }

        /// <summary>
        /// To media color.
        /// </summary>
        /// <param name="color">Color to use.</param>
        /// <returns>Color converted.</returns>
        public static Color ToMediaColor(this Xamarin.Forms.Color color)
        {
            return Color.FromArgb((byte)(color.A * 255.0), (byte)(color.R * 255.0), (byte)(color.G * 255.0), (byte)(color.B * 255.0));
        }
    }
}
