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
  /// Interaction logic for AddAuteurDlg.xaml
  /// </summary>
  public partial class AddAuteurDlg : Window {
    public Auteur CurrentData { get; set; }
    public AddAuteurDlg(Auteur current) {
      CurrentData = current;
      InitializeComponent();
      DataContext = CurrentData;

    }

    private void OkBt_Click(object sender, RoutedEventArgs e) {
      DialogResult = true;
    }
    private void CancelBt_Click(object sender, RoutedEventArgs e) {
      DialogResult = false;
    }
  }
}
