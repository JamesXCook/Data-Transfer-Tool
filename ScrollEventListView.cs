using System.Windows.Forms;

namespace ListViewSharedScroll
{
    public class CustListView : ListView
    {
        public event ScrollEventHandler Scroll;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        protected virtual void OnScroll(ScrollEventArgs e)
        {
            ScrollEventHandler handler = this.Scroll;
            if (handler != null) handler(this, e);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_VSCROLL)
            { // Trap WM_VSCROLL
                OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), -1, 0, ScrollOrientation.VerticalScroll));
            }
            else if (m.Msg == WM_HSCROLL)
            {
                OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), -1, 0, ScrollOrientation.HorizontalScroll));
            }
        }



    }
}