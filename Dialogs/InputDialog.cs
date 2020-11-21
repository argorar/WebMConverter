using System;
using System.Windows.Forms;

namespace WebMConverter.Dialogs
{
    public partial class InputDialog<T> : Form
    {
        public T Value;

        dynamic _inputField;

        public InputDialog(string label, T defaultValue)
        {
            InitializeComponent();
            AddInputField(defaultValue);

            label1.Text = label + ':';
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            switch (typeof(T).ToString())
            {
                case "System.String":
                    Value = _inputField.Text;
                    break;
                case "System.Int32":
                    Value = int.Parse(_inputField.Text);
                    break;
                case "System.TimeSpan":
                    Value = _inputField.Value;
                    break;
                default:
                    break;
            }
            Close();
        }

        void AddInputField(T value)
        {
            switch (typeof(T).ToString())
            {
                case "System.String":
                    _inputField = new TextBox();
                    _inputField.Text = value;
                    break;
                case "System.Int32":
                    _inputField = new TextBox();
                    _inputField.Text = value.ToString();
                    (_inputField as TextBox).KeyPress += delegate(object sender, KeyPressEventArgs e)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                            e.Handled = true;
                    };
                    break;
                case "System.TimeSpan":
                    _inputField = new TimeSpanBox();
                    _inputField.Value = value;
                    break;
                default:
                    throw new ArgumentException("GoToDialog only works with <string>, <int> or <TimeSpan>");
            }

            _inputField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _inputField.Location = new System.Drawing.Point(71, 3);
            _inputField.Name = "inputField";
            _inputField.Size = new System.Drawing.Size(123, 20);
            _inputField.TabIndex = 3;

            tableLayoutPanel.Controls.Add(_inputField, 1, 0);
            tableLayoutPanel.SetColumnSpan(_inputField, 2);
        }
    }
}
