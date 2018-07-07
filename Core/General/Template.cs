using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MiMFa_Framework.General
{
    public class MiMFa_Template
    {
        public static void ChangeBackColor(ToolStripMenuItem toolStripMenuItem, Color color, bool changeTransparentCase)
        {
            if (changeTransparentCase || toolStripMenuItem.BackColor != Color.Transparent)
                toolStripMenuItem.BackColor = color;
        }
        public static void ChangeBackColor(Control control, Color color, bool changeTransparentCase)
        {
            if (changeTransparentCase || control.BackColor != Color.Transparent)
                control.BackColor = color;
        }
        public static void ChangeBackColor(Control mainControl, Type childType, params  Color[] colorRenge)
        {
            int i = 0;
            if (colorRenge.Length > 0)
                foreach (Control item in mainControl.Controls)
                {
                    if (item.GetType() == childType)
                        if (i < colorRenge.Length) i = 0;
                    ChangeBackColor(item, colorRenge[i++], false);
                }
        }
        public static void ChangeBackColor(Control mainControl, params  Color[] colorRenge)
        {
            ChangeBackColor(mainControl, typeof(Control), colorRenge);
        }

        public static void SmartChangeBackColors(Control mainControl, bool changeTransparentCase, params Color[] colorRenge)
        {
            if (colorRenge.Length > 0)
                foreach (Control item in mainControl.Controls)
                {
                    int i = -1;
                    if (colorRenge.Length > ++i && item is Panel) ChangeBackColor(item, colorRenge[i], changeTransparentCase);
                    if (colorRenge.Length > ++i && item is TableLayoutPanel) ChangeBackColor(item, colorRenge[i], changeTransparentCase);
                    if (colorRenge.Length > ++i && item is Label) ChangeBackColor(item, colorRenge[i], changeTransparentCase);
                    if (colorRenge.Length > ++i && item is Button) ChangeBackColor(item, colorRenge[i], changeTransparentCase);
                }
        }
        public static void SmartChangeBackColors(Control mainControl, Dictionary<string, Color> accessableNameAndColor)
        {
            foreach (var item in accessableNameAndColor.Keys)
                SmartChangeBackColors(mainControl, item, accessableNameAndColor[item]);
        }
        public static void SmartChangeBackColors(Control mainControl, string accessableName, Color color)
        {
            foreach (Control item in mainControl.Controls)
            {
                if (item.AccessibleName == accessableName) ChangeBackColor(item, color, false);
                SmartChangeBackColors(item, accessableName, color);
            }
        }


        public static void ChangeForeColor(ToolStripMenuItem toolStripMenuItem, Color color, bool changeTransparentCase)
        {
            if (changeTransparentCase || toolStripMenuItem.ForeColor != Color.Transparent)
                toolStripMenuItem.ForeColor = color;
        }
        public static void ChangeForeColor(Control control, Color color, bool changeTransparentCase)
        {
            if (changeTransparentCase || control.ForeColor != Color.Transparent)
                control.ForeColor = color;
        }
        public static void ChangeForeColor(Control mainControl, Type childType, params  Color[] colorRenge)
        {
            int i = 0;
            if (colorRenge.Length > 0)
                foreach (Control item in mainControl.Controls)
                {
                    if (item.GetType() == childType)
                        if (i < colorRenge.Length) i = 0;
                    ChangeForeColor(item, colorRenge[i++], false);
                }
        }
        public static void ChangeForeColor(Control mainControl, params  Color[] colorRenge)
        {
            ChangeForeColor(mainControl, typeof(Control), colorRenge);
        }

        public static void SmartChangeForeColors(Control mainControl, bool changeTransparentCase, params Color[] colorRenge)
        {
            if (colorRenge.Length > 0)
                foreach (Control item in mainControl.Controls)
                {
                    int i = -1;
                    if (colorRenge.Length > ++i && item is Panel) ChangeForeColor(item, colorRenge[i], changeTransparentCase);
                    if (colorRenge.Length > ++i && item is TableLayoutPanel) ChangeForeColor(item, colorRenge[i], changeTransparentCase);
                    if (colorRenge.Length > ++i && item is Label) ChangeForeColor(item, colorRenge[i], changeTransparentCase);
                    if (colorRenge.Length > ++i && item is Button) ChangeForeColor(item, colorRenge[i], changeTransparentCase);
                }
        }
        public static void SmartChangeForeColors(Control mainControl, Dictionary<string, Color> accessableNameAndColor)
        {
            foreach (var item in accessableNameAndColor.Keys)
                SmartChangeForeColors(mainControl, item, accessableNameAndColor[item]);
        }
        public static void SmartChangeForeColors(Control mainControl, string accessableName, Color color)
        {
            foreach (Control item in mainControl.Controls)
            {
                if (item.AccessibleName == accessableName) ChangeForeColor(item, color, false);
                SmartChangeForeColors(item, accessableName, color);
            }
        }


        public static void ChangeFont(ToolStripMenuItem toolStripMenuItem, Font font)
        {
            if (font != null) toolStripMenuItem.Font = font;
        }
        public static void ChangeFont(Control control, Font font)
        {
            control.Font = font;
        }
        public static void ChangeFont(Control mainControl, Type childType, params  Font[] fontRenge)
        {
            int i = 0;
            if (fontRenge.Length > 0)
                foreach (Control item in mainControl.Controls)
                {
                    if (item.GetType() == childType)
                        if (i < fontRenge.Length) i = 0;
                    ChangeFont(item, fontRenge[i++]);
                }
        }
        public static void ChangeFont(Control mainControl, params  Font[] fontRenge)
        {
            ChangeFont(mainControl, typeof(Control), fontRenge);
        }

        public static void SmartChangeFonts(Control mainControl, bool changeTransparentCase, params Font[] fontRenge)
        {
            if (fontRenge.Length > 0)
                foreach (Control item in mainControl.Controls)
                {
                    int i = -1;
                    if (fontRenge.Length > ++i && item is Panel) ChangeFont(item, fontRenge[i]);
                    if (fontRenge.Length > ++i && item is TableLayoutPanel) ChangeFont(item, fontRenge[i]);
                    if (fontRenge.Length > ++i && item is Label) ChangeFont(item, fontRenge[i]);
                    if (fontRenge.Length > ++i && item is Button) ChangeFont(item, fontRenge[i]);
                }
        }
        public static void SmartChangeFonts(Control mainControl, Dictionary<string, Font> accessableNameAndfont)
        {
            foreach (var item in accessableNameAndfont.Keys)
                SmartChangeFonts(mainControl, item, accessableNameAndfont[item]);
        }
        public static void SmartChangeFonts(Control mainControl, string accessableName, Font font)
        {
            if (font != null)
                foreach (Control item in mainControl.Controls)
                {
                    if (item.AccessibleName == accessableName) ChangeFont(item, font);
                    SmartChangeFonts(item, accessableName, font);
                }
        }
    }
}
