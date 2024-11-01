using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WebMConverter.Dialogs
{
    public partial class TrackSelectDialog : Form
    {
        public int SelectedTrack => (int)comboBoxTracks.SelectedValue;

        public TrackSelectDialog(string tracktype, IEnumerable<int> tracks)
        {
            InitializeComponent();

            labelSelect.Text = string.Format("{0} track:", tracktype);

            var dropdownTracks = tracks.ToDictionary(track => track, track => string.Format("Track #{0}", track));

            if (tracktype.Equals("Audio") && tracks.Count() <= 2)
                dropdownTracks.Add(99, "Mix all");

            comboBoxTracks.DataSource = new BindingSource(dropdownTracks, null);
            comboBoxTracks.ValueMember = "Key";
            comboBoxTracks.DisplayMember = "Value";
        }
    }
}
