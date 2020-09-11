using AudiotModule.ViewModels;
using Prism.Events;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AudiotModule.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class MidiControlView : UserControl
    {
        IRegionManager _region;
        IRegionManager _scopedRegion;
        IEventAggregator _ea;
        IRegion _controlLineRegion;
        MidiControlViewModel _viewModel;

        public MidiControlView(IRegionManager region, IEventAggregator ea)
        {
            _region = region; _ea = ea;
            InitializeComponent();

            _scopedRegion = region.CreateRegionManager();
            CreateControlLineContentRegion();
            _viewModel = (DataContext as MidiControlViewModel);
        }

        private void CreateControlLineContentRegion()
        {
            string regionName = "ControlItemsRegion";

            RegionManager.SetRegionName(ControlChangeItems, regionName);
            RegionManager.SetRegionManager(ControlChangeItems, _scopedRegion);

            _controlLineRegion = _scopedRegion.Regions.FirstOrDefault(x => x.Name == regionName);
        }

        private void CreateControlLine()
        {
            _controlLineRegion.Add(new ControlChangeLine(_viewModel.ControlChangeParameters, _viewModel.SelectedChannel), null, true);
        }

        private void RemoveControlLine()
        {
            if(_controlLineRegion.Views.Count() > 0)
                _controlLineRegion.Remove(_controlLineRegion.Views.Last());

            ControlChangeItems.Items.Refresh();
        }

        private void AddControlLineButton_Click(object sender, RoutedEventArgs e)
        {
            CreateControlLine();
        }

        private void RemoveControlLineButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveControlLine();
        }

        private void AutoPatchButton_Click(object sender, RoutedEventArgs e)
        {
            AutoPatch();
        }

        private void AutoPatch()
        {
            foreach(var controlLine in _controlLineRegion.Views)
            {
                (controlLine as ControlChangeLine).VM.RandomizeControl();
            }
        }
    }
}
