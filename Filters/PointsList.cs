using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using WebMConverter.Objects;

namespace WebMConverter
{
    public partial class PointsListForm : Form
    {
        public MultipleTrimFilter GeneratedFilter { get; set; }
        public SortedList newList { get; set; }

        public PointsListForm(SortedList points)
        {
            InitializeComponent();
            newList = points;
            if (points != null)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    var point = (SpeedPoint)points.GetByIndex(i);
                    listViewTrims.Items.Add($"Frame {points.GetKey(i)} - {point.Speed*100}%").Tag = points.GetKey(i);
                }
            }
        }

        public PointsListForm()
        {
            InitializeComponent();
        }

        private void listViewTrims_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                listViewTrims.SelectedItems[0].Remove();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            newList.RemoveAt(listViewTrims.SelectedItems[0].Index);
            listViewTrims.SelectedItems[0].Remove();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listViewTrims_Leave(object sender, EventArgs e) => listViewTrims.Focus();
    }

   
}
