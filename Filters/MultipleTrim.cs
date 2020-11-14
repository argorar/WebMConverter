using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class MultipleTrimForm : Form
    {
        public MultipleTrimFilter GeneratedFilter;

        private enum MoveDirection { Up = -1, Down = 1 };

        public MultipleTrimForm(MultipleTrimFilter filterToEdit = null)
        {
            InitializeComponent();

            if (filterToEdit != null)
            {
                foreach (TrimFilter trim in filterToEdit.Trims)
                    listViewTrims.Items.Add(trim.ToString()).Tag = trim;
            }
        }

        private void listViewTrims_ItemActivate(object sender, EventArgs e)
        {
            using (var form = new TrimForm(listViewTrims.SelectedItems[0].Tag as TrimFilter))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    listViewTrims.SelectedItems[0].Tag = form.GeneratedFilter;
                    listViewTrims.SelectedItems[0].Text = form.GeneratedFilter.ToString();
                }
            }
        }

        private void listViewTrims_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                listViewTrims.SelectedItems[0].Remove();
        }

        private void MoveListViewItem(ListView sender, MoveDirection direction) // http://stackoverflow.com/a/11623992
        {
            int dir = (int)direction;
            var item = sender.SelectedItems[0];
            int index = item.Index + dir;

            listViewTrims.BeginUpdate();

            sender.Items.RemoveAt(item.Index);
            sender.Items.Insert(index, item);

            listViewTrims.EndUpdate();
        }

        private void buttonAddTrim_Click(object sender, EventArgs e)
        {
            using (var form = new TrimForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    listViewTrims.Items.Add(form.GeneratedFilter.ToString()).Tag = form.GeneratedFilter;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            var Trims = new List<TrimFilter>();

            foreach (ListViewItem item in listViewTrims.Items)
                Trims.Add(item.Tag as TrimFilter);

            if (Trims.Count == 0)
                return;

            DialogResult = DialogResult.OK;

            GeneratedFilter = new MultipleTrimFilter(Trims);
        }

        private void listViewTrims_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTrims.SelectedIndices.Count == 0)
            {
                buttonMoveUp.Enabled = false;
                buttonMoveDown.Enabled = false;
                return;
            }

            buttonMoveUp.Enabled = (listViewTrims.SelectedIndices[0] != 0);
            buttonMoveDown.Enabled = (listViewTrims.SelectedIndices[0] != listViewTrims.Items.Count - 1);
        }

        private void buttonMoveUp_Click(object sender, EventArgs e) => MoveListViewItem(listViewTrims, MoveDirection.Up);
        private void buttonMoveDown_Click(object sender, EventArgs e) => MoveListViewItem(listViewTrims, MoveDirection.Down);
        private void listViewTrims_Leave(object sender, EventArgs e) => listViewTrims.Focus();
    }

    public class MultipleTrimFilter
    {
        public List<TrimFilter> Trims { get; }

        public MultipleTrimFilter(List<TrimFilter> trims)
        {
            Trims = trims;
        }

        public double GetDuration()
        {
            double duration = 0;

            foreach (TrimFilter trim in Trims)
                duration += trim.GetDuration();

            return duration;
        }

        public override string ToString() => string.Join(" + ", Trims);
    }
}
