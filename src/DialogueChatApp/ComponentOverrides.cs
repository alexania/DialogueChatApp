using DialogueChatApp.DialogueTree;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DialogueChatApp
{
  public class RefreshingListBox : ListBox
  {
    public void RefreshAllItems()
    {
      RefreshItems();
    }
  }

  public class RefreshingCheckedListBox : CheckedListBox
  {
    public void RefreshAllItems()
    {
      RefreshItems();
    }
  }
}
