using EF_Vb.Models;
using EF_Vb.Models.Repositories;
using EF_Vb.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EF_Vb.Dialogs {
  /// <summary>
  /// Interaction logic for GroupDialog.xaml
  /// </summary>
  public partial class GroupDialog : Window {
    public GroupDialog(LoginUnitOfWork uow, Groep curGroep = null) {
      VM = new GroupDialogVm() { UnitOfWork = uow, CurrentGroep = curGroep};
      DataContext = VM;
      InitializeComponent();
    }

    public GroupDialogVm VM { get; set; }

    private void OKBt_Click(object sender, RoutedEventArgs e) {
      VM.Save();
      DialogResult = true;
    }

    private void CancelBt_Click(object sender, RoutedEventArgs e) {
      DialogResult = false;
    }
  }
}
