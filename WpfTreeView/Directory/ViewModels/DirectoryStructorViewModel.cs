
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView
{
    /// <summary>
    /// The view model for the application main Directory view
    /// </summary>
    class DirectoryStructorViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region Constructr
        /// <summary>
        /// Defalut Constructor
        /// </summary>
        public DirectoryStructorViewModel()
        {
            //Get the logical drives
            var children = DirectoryStructure.GetLogicalDrives();

            //Create the view models from the data
            this.Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }

        #endregion
    }
}
