using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class TimeSpanBox : TextBox
    {
        const string Format = @"hh\:mm\:ss\.fff";
        const int FormatLength = 12;

        public TimeSpan Value
        {
            get
            {
                return TimeSpan.ParseExact(Text, Format, CultureInfo.CurrentCulture);
            }
            set
            {
                Text = value.ToString(Format);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Delete)
            {
                int index = SelectionStart;

                if (char.IsDigit(Text[index]))
                {
                    Text = Text.Remove(index, 1).Insert(index, "0");
                }

                SelectionStart = index; // if this isn't here, the cursor jumps back to the start of the text

                e.Handled = true;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            int index = SelectionStart;

            if (char.IsDigit(e.KeyChar) && index != FormatLength)
            {
                if (!char.IsDigit(Text[index]))
                {
                    index++;
                }

                Text = Text.Remove(index, 1).Insert(index, e.KeyChar.ToString());

                index++;
            }
            else if (e.KeyChar == '\b' && index != 0) // Backspace
            {
                index--;

                if (!char.IsDigit(Text[index]))
                {
                    index--;
                }

                if (char.IsDigit(Text[index]))
                {
                    Text = Text.Remove(index, 1).Insert(index, "0");
                }
            }

            SelectionStart = Math.Max(0, Math.Min(index, FormatLength));

            e.Handled = true;
        }
    }
}
