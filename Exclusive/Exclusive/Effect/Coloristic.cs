using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.Effect
{
    public static class MiMFa_Coloristic
    {
        #region Range
        public enum ColorRange
        {
            Null = -1, LightRange, DarkRange, SharpRange, HotRange, ColdRange, BlackWhiteRange, OldRange, SkyRange, FireRange, RedRange, GreenRange
        }
        public static Color[] Null = { Color.Transparent };
        public static Color[] LightRange = {  Color.LavenderBlush,  Color.Lavender,Color.Thistle, Color.LightSteelBlue, Color.LightBlue,
                                               Color.PowderBlue, Color.Aquamarine, Color.MintCream, Color.Honeydew, Color.PaleGreen,
                                               Color.GreenYellow, Color.LightYellow, Color.Beige, Color.LemonChiffon, Color.OldLace,
                                               Color.Wheat, Color.PapayaWhip, Color.Bisque, Color.Linen, Color.MistyRose};

        public static Color[] DarkRange = { Color.DarkRed, Color.Brown, Color.Sienna, Color.SaddleBrown,
                                               Color.DarkGoldenrod, Color.Olive, Color.OliveDrab, Color.DarkOliveGreen, Color.ForestGreen,
                                               Color.Green,Color.SeaGreen,Color.DarkSlateGray,Color.Teal, Color.SteelBlue,
                                               Color.SlateGray, Color.DarkSlateBlue, Color.Indigo, Color.Purple, Color.MediumVioletRed};

        public static Color[] SharpRange = { Color.White, Color.Black, Color.Red, Color.OrangeRed, Color.Gold, Color.Yellow,
                                               Color.Chartreuse, Color.Lime, Color.SpringGreen, Color.Aqua, Color.Blue,
                                               Color.MidnightBlue,Color.DarkViolet,Color.DarkMagenta,Color.Magenta,
                                               Color.DeepPink, Color.HotPink, Color.Crimson };

        public static Color[] HotRange = { Color.Snow, Color.SeaShell, Color.Linen, Color.AntiqueWhite, Color.PapayaWhip,
                                              Color.BlanchedAlmond, Color.Moccasin, Color.Wheat,  Color.NavajoWhite, Color.PaleGoldenrod,
                                              Color.Khaki ,Color.Yellow, Color.Gold,  Color.Orange,  Color.SandyBrown,
                                              Color.DarkOrange, Color.Peru, Color.Sienna,  Color.SaddleBrown , Color.Chocolate,
                                              Color.Brown, Color.Maroon, Color.DarkRed, Color.Firebrick, Color.IndianRed, Color.Red,
                                              Color.OrangeRed, Color.Tomato, Color.Coral, Color.Plum, Color.Violet, Color.Fuchsia,
                                              Color.Magenta, Color.HotPink, Color.PaleVioletRed, Color.MediumVioletRed, Color.Crimson,
                                              Color.DeepPink, Color.LightPink, Color.Pink, Color.LavenderBlush};

        public static Color[] ColdRange = { Color.GhostWhite,  Color.AliceBlue,  Color.Azure,  Color.LightCyan,  Color.Lavender,
                                              Color.LightSteelBlue,  Color.PowderBlue,  Color.LightBlue, Color.PaleTurquoise,
                                              Color.LightSkyBlue, Color.SkyBlue,  Color.CornflowerBlue,  Color.Blue,  Color.RoyalBlue,
                                              Color.MidnightBlue,  Color.DarkBlue,  Color.Navy,  Color.MidnightBlue,  Color.Indigo,
                                              Color.DarkSlateBlue,  Color.SlateBlue,  Color.BlueViolet,  Color.MediumSlateBlue, 
                                              Color.MediumPurple,  Color.DarkOrchid,  Color.DarkViolet,  Color.CadetBlue, Color.LightSeaGreen,
                                              Color.DarkCyan, Color.Teal,  Color.DarkSlateGray,  Color.DarkGreen,  Color.Green,
                                              Color.ForestGreen,  Color.SeaGreen,  Color.MediumSeaGreen,  Color.LimeGreen,  Color.Lime,
                                              Color.MediumSpringGreen,  Color.SpringGreen,  Color.DarkSeaGreen,  Color.LightGreen, 
                                              Color.PaleGreen,  Color.LawnGreen ,Color.Chartreuse,  Color.GreenYellow ,
                                              Color.YellowGreen,  Color.OliveDrab,Color.Tan,  Color.Tan, };

        public static Color[] BlackWhiteRange = { Color.White, Color.WhiteSmoke,  Color.Gainsboro,  Color.LightGray,  Color.Silver,
                                                    Color.DarkGray,  Color.Gray,  Color.DimGray, Color.Black};

        public static Color[] OldRange = { Color.Snow, Color.SeaShell, Color.Linen, Color.AntiqueWhite, Color.PapayaWhip,
                                             Color.BlanchedAlmond, Color.Moccasin, Color.Wheat,  Color.NavajoWhite, Color.PaleGoldenrod,
                                             Color.Khaki , Color.Gold,  Color.Orange,  Color.SandyBrown,  Color.Chocolate,Color.Sienna,
                                             Color.SaddleBrown};

        public static Color[] SkyRange = {Color.MediumBlue, Color.RoyalBlue, Color.CornflowerBlue, Color.Lavender, Color.AliceBlue,
                                             Color.GhostWhite, Color.MintCream, Color.Honeydew, Color.Ivory, Color.LightYellow,
                                             Color.Cornsilk, Color.OldLace, Color.PapayaWhip, Color.NavajoWhite, Color.Tan,
                                             Color.SlateGray, Color.DarkSlateGray, Color.DarkBlue, Color.Navy, Color.MidnightBlue };

        public static Color[] FireRange = { Color.Cornsilk, Color.LightGoldenrodYellow,Color.LemonChiffon,  Color.PapayaWhip,
                                              Color.BlanchedAlmond, Color.Moccasin, Color.NavajoWhite, Color.Gold,Color.Yellow,
                                              Color.Orange,Color.DarkOrange,Color.OrangeRed,Color.Red,Color.Tomato,Color.Salmon,
                                              Color.Coral,Color.LightSalmon,Color.PeachPuff,Color.Bisque,Color.MistyRose,Color.SeaShell};

        public static Color[] RedRange = { Color.Cornsilk, Color.PapayaWhip,Color.BlanchedAlmond, Color.Moccasin, Color.NavajoWhite, Color.Gold,
                                              Color.LightSalmon, Color.Salmon,Color.Orange,Color.Coral,Color.DarkOrange,Color.OrangeRed,Color.Red };

        public static Color[] GreenRange = { Color.MintCream, Color.Honeydew, Color.PaleGreen, Color.LightGreen, Color.GreenYellow, Color.Chartreuse,
                                              Color.LawnGreen, Color.Lime, Color.LimeGreen, Color.Green};
        #endregion
        public static void AllChildsControlColorChange(Control parent, MiMFa_SelectFromRange selectLow = MiMFa_SelectFromRange.Random, params Color[] colorRange)
        {
            Color[] arrc = GetColorRenge(parent.Controls.Count, selectLow, colorRange);
            for (int i = 0; i < parent.Controls.Count; i++)
                parent.Controls[i].BackColor = arrc[i];
        }
        public static void AllChildsControlColorChange(Control parent, ColorRange colorRange, MiMFa_SelectFromRange selectLow = MiMFa_SelectFromRange.Random)
        {
            AllChildsControlColorChange(parent, selectLow, GetColorRenge(colorRange, MiMFa_SelectFromRange.OrderBy));
        }
        public static Color[] GetColorRenge(int length, MiMFa_SelectFromRange selectLow = MiMFa_SelectFromRange.Random, params Color[] colorRange)
        {
            Color[] arrc = new Color[length];
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                if (colorRange.Length > j)
                    arrc[i] = colorRange[j++];
                else
                {
                    j = 0;
                    arrc[i] = colorRange[j++];
                }
            }
            switch (selectLow)
            {
                case MiMFa_SelectFromRange.OrderBy:
                    return arrc;
                case MiMFa_SelectFromRange.Random:
                    return MiMFa_CollectionService.Shake(arrc);
                case MiMFa_SelectFromRange.Special:
                    return MiMFa_CollectionService.Shake(MiMFa_CollectionService.Shake(arrc));
                default:
                    return arrc;
            }
        }
        public static Color[] GetColorRenge(int length, ColorRange colorRange, MiMFa_SelectFromRange selectLow = MiMFa_SelectFromRange.Random)
        {
            return GetColorRenge(length, selectLow, GetColorRenge(colorRange, MiMFa_SelectFromRange.OrderBy));
        }
        public static Color[] GetColorRenge(ColorRange colorRange, MiMFa_SelectFromRange selectLow = MiMFa_SelectFromRange.OrderBy)
        {
            switch(colorRange)
            {
                case ColorRange.LightRange:
                    return  LightRange;
                case ColorRange.DarkRange:
                    return  DarkRange;
                case ColorRange.SharpRange:
                    return  SharpRange;
                case ColorRange.HotRange:
                    return  HotRange;
                case ColorRange.ColdRange:
                    return  ColdRange;
                case ColorRange.BlackWhiteRange:
                    return  BlackWhiteRange;
                case ColorRange.OldRange:
                    return  OldRange;
                case ColorRange.SkyRange:
                    return  SkyRange;
                case ColorRange.FireRange:
                    return FireRange;
                case ColorRange.RedRange:
                    return RedRange;
                case ColorRange.GreenRange:
                    return GreenRange;
                default:
                    return Null;
            }
        }

        public static Color InvertColor(Color color)
        {
            Color invertedColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);

            if (invertedColor.R > 110 && invertedColor.R < 150 &&
                invertedColor.G > 110 && invertedColor.G < 150 &&
                invertedColor.B > 110 && invertedColor.B < 150)
            {
                int avg = (invertedColor.R + invertedColor.G + invertedColor.B) / 3;
                avg = avg > 128 ? 200 : 60;
                invertedColor = Color.FromArgb(avg, avg, avg);
            }
            return invertedColor;
        }
        public static Color GetRandomColor()
        {
            Random r = new Random();
            return Color.FromArgb(r.Next(0,255), r.Next(0, 255),r.Next(0,255));
        }
        public static Color GetPercentColor(decimal percent,int changeRange=7)
        {
            int length = Math.Min(GreenRange.Length, changeRange);
            int unit = 100 / length;
            int index = Math.Abs(Convert.ToInt32(percent / unit));
            if (percent > 0) return GreenRange[index];
            else if (percent < 0) return RedRange[index];
            else return Color.White;
        }
    }
}
