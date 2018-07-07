using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.Animate
{
    public class MiMFa_ObjectMoveOrResize
    {
        public enum MoveOrResize
        {
            Move = -1,
            MoveAndResize = 0,
            Resize = 1
        }

        public MiMFa_ObjectMoveOrResize()
        {
        }
        public MiMFa_ObjectMoveOrResize(MoveOrResize moveOrResize = MoveOrResize.MoveAndResize, params Control[] controls)
        {
            if (controls != null)
                foreach (var item in controls)
                    AddControl(item, item, moveOrResize);
        }
        public void AddControl(MoveOrResize moveOrResize, params Control[] controls)
        {
            if (controls != null)
                for (int i = 0; i < controls.Length; i++)
                    AddControl(controls[i], controls[i], moveOrResize);
        }
        public void AddControl(Control control, MoveOrResize moveOrResize = MoveOrResize.MoveAndResize)
        { AddControl(control,control,moveOrResize); }
        public void AddControl(Control control, Control container/*Moved Container*/, MoveOrResize moveOrResize = MoveOrResize.MoveAndResize)
        {
            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
           
            control.MouseEnter += (sender, e) => { _currentControlDock = control.Dock; };
            control.MouseDown += (sender, e) => StartMovingOrResizing(control, e, moveOrResize);
            control.MouseUp += (sender, e) => StopDragOrResizing(control, moveOrResize);
            control.MouseLeave += (sender, e) => StopDragOrResizing(control, moveOrResize);
            control.MouseMove += (sender, e) => MoveControl(container, e, moveOrResize);
        }

        #region Private Region
        
        private bool _draging;
        private bool _moving;
        private Point _cursorStartPoint;
        private bool _moveIsInterNal;
        private bool _resizing;
        private Size _currentControlStartSize;
        private DockStyle _currentControlDock;
        private bool MouseIsInLeftEdge { get; set; }
        private bool MouseIsInRightEdge { get; set; }
        private bool MouseIsInTopEdge { get; set; }
        private bool MouseIsInBottomEdge { get; set; }

        private void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl, MoveOrResize WorkType)
        {
            if (WorkType == MoveOrResize.Move)
                return;
            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 4;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 4;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= 4;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 4;
        }
        private void UpdateMouseCursor(Control control, MoveOrResize WorkType)
        {
            if (WorkType == MoveOrResize.Move)
                return;
            else if (MouseIsInLeftEdge)
                if (MouseIsInTopEdge)
                    control.Cursor = Cursors.SizeNWSE;
                else if (MouseIsInBottomEdge)
                    control.Cursor = Cursors.SizeNESW;
                else
                    control.Cursor = Cursors.SizeWE;
            else if (MouseIsInRightEdge)
                if (MouseIsInTopEdge)
                    control.Cursor = Cursors.SizeNESW;
                else if (MouseIsInBottomEdge)
                    control.Cursor = Cursors.SizeNWSE;
                else
                    control.Cursor = Cursors.SizeWE;
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
                control.Cursor = Cursors.SizeNS;
            else control.Cursor = Cursors.Default;
        }

        private string GetSizeAndPositionOfControlsToString(Control container)
        {
            List<object> controls = new List<object>();
            controls = MiMFa_ControlService.GetAllChildObjects(container, controls);
            CultureInfo cultureInfo = new CultureInfo("en");
            string info = string.Empty;
            foreach (Control control in controls)
            {
                info += control.Name + ":" + control.Left.ToString(cultureInfo) + "," + control.Top.ToString(cultureInfo) + "," +
                        control.Width.ToString(cultureInfo) + "," + control.Height.ToString(cultureInfo) + "*";
            }
            return info;
        }
        private void SetSizeAndPositionOfControlsFromString(Control container, string controlsInfoStr)
        {
            List<object> controls = new List<object>();
            controls = MiMFa_ControlService.GetAllChildObjects(container, controls);
            string[] controlsInfo = controlsInfoStr.Split(new[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> controlsInfoDictionary = new Dictionary<string, string>();
            foreach (string controlInfo in controlsInfo)
            {
                string[] info = controlInfo.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                controlsInfoDictionary.Add(info[0], info[1]);
            }
            foreach (Control control in controls)
            {
                string propertiesStr;
                controlsInfoDictionary.TryGetValue(control.Name, out propertiesStr);
                string[] properties = propertiesStr.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (properties.Length == 4)
                {
                    control.Left = int.Parse(properties[0]);
                    control.Top = int.Parse(properties[1]);
                    control.Width = int.Parse(properties[2]);
                    control.Height = int.Parse(properties[3]);
                }
            }
        }

        //Target
        private void StartMovingOrResizing(Control control, MouseEventArgs e, MoveOrResize WorkType)
        {
            MiMFa_ControlService.SetControlThreadSafe(control, new Action<object[]>((oa) =>
            {
                if (_moving || _resizing)
                    return;
                if (WorkType != MoveOrResize.Move &&
                    (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
                {
                    _resizing = true;
                    _currentControlStartSize = control.Size;
                }
                else if (WorkType != MoveOrResize.Resize)
                {
                    control.Dock = DockStyle.None;
                    _moving = true;
                    control.Cursor = Cursors.SizeAll;
                }
                else control.Cursor = Cursors.Default;
                _cursorStartPoint = new Point(e.X, e.Y);
                control.Capture = true;
                _draging = true;
            }), new object[] { });
        }
        private void MoveControl(Control control, MouseEventArgs e, MoveOrResize WorkType)
        {
            MiMFa_ControlService.SetControlThreadSafe(control, new Action<object[]>((oa) =>
            {
                if ((!_resizing && !_moving) || !_draging)
                {
                    _resizing = _moving = _draging;
                    UpdateMouseEdgeProperties(control, new Point(e.X, e.Y), WorkType);
                    UpdateMouseCursor(control, WorkType);
                }
                if (_resizing)
                {
                    if (MouseIsInLeftEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            control.Width -= (e.X - _cursorStartPoint.X);
                            control.Left += (e.X - _cursorStartPoint.X);
                            control.Height -= (e.Y - _cursorStartPoint.Y);
                            control.Top += (e.Y - _cursorStartPoint.Y);
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            control.Width -= (e.X - _cursorStartPoint.X);
                            control.Left += (e.X - _cursorStartPoint.X);
                            control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        }
                        else
                        {
                            control.Width -= (e.X - _cursorStartPoint.X);
                            control.Left += (e.X - _cursorStartPoint.X);
                        }
                    }
                    else if (MouseIsInRightEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                            control.Height -= (e.Y - _cursorStartPoint.Y);
                            control.Top += (e.Y - _cursorStartPoint.Y);

                        }
                        else if (MouseIsInBottomEdge)
                        {
                            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                            control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        }
                        else
                        {
                            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        }
                    }
                    else if (MouseIsInTopEdge)
                    {
                        control.Height -= (e.Y - _cursorStartPoint.Y);
                        control.Top += (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        StopDragOrResizing(control, WorkType);
                    }
                }
                else if (_moving)
                {
                    _moveIsInterNal = !_moveIsInterNal;
                    if (!_moveIsInterNal)
                    {
                        int x = (e.X - _cursorStartPoint.X) + control.Left;
                        int y = (e.Y - _cursorStartPoint.Y) + control.Top;
                        control.Location = new Point(x, y);
                    }
                }
            }), new object[] { });
        }
        private void StopDragOrResizing(Control control, MoveOrResize WorkType)
        {
            MiMFa_ControlService.SetControlThreadSafe(control, new Action<object[]>((oa) =>
            {
                control.Dock = _currentControlDock;
                _draging = false;
                _resizing = false;
                _moving = false;
                control.Capture = false;
                MouseIsInLeftEdge = false;
                MouseIsInRightEdge = false;
                MouseIsInTopEdge = false;
                MouseIsInBottomEdge = false;
                UpdateMouseCursor(control, WorkType);
            }), new object[] { });
        }

        #endregion
    }
}
