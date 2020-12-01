using Boek.App.Viewmodels;
using Boek.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Boek.App.Dialogs {
  /// <summary>
  /// Interaction logic for AddBoekDialog.xaml
  /// </summary>
  public partial class AddBoekDialog : Window {
    BoekCRUDViewModel _vm = null;
    public AddBoekDialog(Boekje curBoek=null) {
      _vm = new BoekCRUDViewModel(curBoek ?? new Boekje(), curBoek == null);
      InitializeComponent();
      DataContext = _vm;
    }

    private void OkBt_Click(object sender, RoutedEventArgs e) {
      _vm.Save();
      DialogResult = true;
    }

    private void CancelBt_Click(object sender, RoutedEventArgs e) {

      DialogResult = false;

    }
  }
}
