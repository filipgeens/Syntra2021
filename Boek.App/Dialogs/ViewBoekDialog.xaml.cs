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
  /// Interaction logic for ViewBoekDialog.xaml
  /// </summary>
  public partial class ViewBoekDialog : Window {
    public BoekViewModel CurrentBoekVm { get; set; }
    public ViewBoekDialog(BoekViewModel curVm) {
      CurrentBoekVm = curVm;
      DataContext = CurrentBoekVm;
      InitializeComponent();
    }
  }
}
