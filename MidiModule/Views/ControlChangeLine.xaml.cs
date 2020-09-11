using AudiotLogic.MidiLogic;
using AudiotModule.ViewModels;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AudiotModule.Views
{
    /// <summary>
    /// Interaction logic for ControlChangeLine.xaml
    /// </summary>
    public partial class ControlChangeLine : UserControl
    {
        public ControlChangeLineViewModel VM;

        public ControlChangeLine(List<ControlChange> Parameters, int MidiChannel)
        {
            InitializeComponent();
            VM = (DataContext as ControlChangeLineViewModel);

            ParameterComboBox.ItemsSource = Parameters;
            VM.MidiChannel = MidiChannel;
        }
    }
}
