using System;
using System.Windows.Forms;

namespace PSS.Presentation_Layer
{
    public partial class ArrowlessNumericUpDown : NumericUpDown
    {
        public ArrowlessNumericUpDown()
        {
            Controls[0].Hide();
        }

        protected override void OnTextBoxResize(object source, EventArgs e)
        {
            Controls[1].Width = Width - 4;
        }
    }
}
