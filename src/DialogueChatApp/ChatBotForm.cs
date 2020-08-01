using DialogueChatApp.DialogueTree;
using DialogueChatApp.DialogueTree.DataSets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DialogueChatApp
{
  public partial class ChatBotForm : Form
  {
    private Node _selectedNode;
    private TopicNode _selectedTopic;

    private EventHandler _chatListBox_SelectedIndexChange;

    private EventHandler _currentTopicBox_SelectedIndexChanged;
    private ItemCheckEventHandler _currentTopicBox_ItemCheck;

    private EventHandler _topicBox_SelectedIndexChanged;
    private ItemCheckEventHandler _topicBox_ItemCheck;

    private EventHandler _selectAllResponses_CheckedChanged;
    private ItemCheckEventHandler _responseBox_ItemCheck;

    public ChatBotForm()
    {
      InitializeComponent();

      _chatListBox_SelectedIndexChange = new EventHandler(ChatListBox_SelectedIndexChanged);
      ChatListBox.SelectedIndexChanged += _chatListBox_SelectedIndexChange;

      _currentTopicBox_SelectedIndexChanged = new EventHandler(CurrentTopicBox_SelectedIndexChange);
      CurrentTopicBox.SelectedIndexChanged += _currentTopicBox_SelectedIndexChanged;
      _currentTopicBox_ItemCheck = new ItemCheckEventHandler(CurrentTopicBox_ItemCheck);
      CurrentTopicBox.ItemCheck += _currentTopicBox_ItemCheck;

      _topicBox_SelectedIndexChanged = new EventHandler(TopicBox_SelectedIndexChange);
      TopicBox.SelectedIndexChanged += _topicBox_SelectedIndexChanged;
      _topicBox_ItemCheck = new ItemCheckEventHandler(TopicBox_ItemCheck);
      TopicBox.ItemCheck += _topicBox_ItemCheck;

      _selectAllResponses_CheckedChanged = new EventHandler(SelectAllResponses_CheckedChanged);
      SelectAllResponses.CheckedChanged += _selectAllResponses_CheckedChanged;

      _responseBox_ItemCheck = new ItemCheckEventHandler(ResponseBox_ItemCheck);
      ResponseBox.ItemCheck += _responseBox_ItemCheck;

      UnsavedChanges(false);

      try
      {
        //MovieDialogueDataSet.LoadData(Tree.Instance);
        Tree.Instance.Load();
        InitializeInterface();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message, "An Error Has Occurred", MessageBoxButtons.OK);
      }
    }

    private void ChatListBox_SelectItem(bool enable)
    {
      ChatListBox.SelectedIndexChanged -= _chatListBox_SelectedIndexChange;

      if (enable)
      {
        ChatListBox.SelectedIndexChanged += _chatListBox_SelectedIndexChange;
      }
    }

    private void CurrentTopicBox_ItemCheck(bool enable)
    {
      CurrentTopicBox.ItemCheck -= _currentTopicBox_ItemCheck;

      if (enable)
      {
        CurrentTopicBox.ItemCheck += _currentTopicBox_ItemCheck;
      }
    }

    private void CurrentTopicBox_SelectItem(bool enable)
    {
      CurrentTopicBox.SelectedIndexChanged -= _currentTopicBox_SelectedIndexChanged;

      if (enable)
      {
        CurrentTopicBox.SelectedIndexChanged += _currentTopicBox_SelectedIndexChanged;
      }
    }

    private void TopicBox_ItemCheck(bool enable)
    {
      TopicBox.ItemCheck -= _topicBox_ItemCheck;

      if (enable)
      {
        TopicBox.ItemCheck += _topicBox_ItemCheck;
      }
    }

    private void TopicBox_SelectItem(bool enable)
    {
      TopicBox.SelectedIndexChanged -= _topicBox_SelectedIndexChanged;

      if (enable)
      {
        TopicBox.SelectedIndexChanged += _topicBox_SelectedIndexChanged;
      }
    }

    private void ResponseBox_ItemCheck(bool enable)
    {
      ResponseBox.ItemCheck -= _responseBox_ItemCheck;

      if (enable)
      {
        ResponseBox.ItemCheck += _responseBox_ItemCheck;
      }
    }

    private void SelectAllResponses_ItemCheck(bool enable)
    {
      SelectAllResponses.CheckedChanged -= _selectAllResponses_CheckedChanged;

      if (enable)
      {
        SelectAllResponses.CheckedChanged += _selectAllResponses_CheckedChanged;
      }
    }

    private void InitializeInterface()
    {
      ChangeRoot(Tree.Instance.TreeState.Root);
      TopicBox.DataSource = Tree.Instance.TreeState.Topics;
    }

    private void UnsavedChanges(bool changes = true)
    {
      SaveButton.Enabled = changes;
      StatusLabel.Text = changes ? "Unsaved changes." : "";
    }

    private void ChangeRoot(Node root, Node selected = null)
    {
      ChatListBox.DataSource = root.Next;
      SelectNode(selected);
    }

    private void SelectNode(Node node)
    {
      _selectedNode = node;

      ChatListBox_SelectItem(false);
      CurrentTopicBox_ItemCheck(false);
      TopicBox_ItemCheck(false);
      ResponseBox_ItemCheck(false);

      if (_selectedNode != null)
      {
        ChatListBox.SelectedItem = _selectedNode;
        EditLineBox.Text = _selectedNode.Text;

        CurrentTopicBox.Items.Clear();
        TopicNode selectedTopic = null;
        for (var i = 0; i < TopicBox.Items.Count; i++)
        {
          var item = TopicBox.Items[i] as TopicNode;

          var containsTopic = _selectedNode.TopicNodes.Contains(item);
          TopicBox.SetItemChecked(i, containsTopic);

          if (containsTopic)
          {
            CurrentTopicBox.Items.Add(item, true);

            selectedTopic = selectedTopic ?? item;
          }
        }
        TopicBox.Enabled = true;

        ResponseBox.Items.Clear();
        ResponseBox.Items.AddRange(_selectedNode.Next.ToArray());
        ResponseBox.Enabled = true;

        SelectTopic(selectedTopic);
      }
      else
      {
        ChatListBox.ClearSelected();
        EditLineBox.Text = "";

        TopicBox.Enabled = false;
        TopicBox.ClearSelected();

        ResponseBox.Enabled = false;
        ResponseBox.Items.Clear();
      }

      ChatListBox_SelectItem(true);
      CurrentTopicBox_ItemCheck(true);
      TopicBox_ItemCheck(true);
      ResponseBox_ItemCheck(true);
    }

    private void SelectTopic(TopicNode topicNode)
    {
      ChatListBox_SelectItem(false);
      TopicBox_SelectItem(false);
      TopicBox_ItemCheck(false);
      ResponseBox_ItemCheck(false);
      SelectAllResponses_ItemCheck(false);

      if (_selectedNode != null)
      {
        _selectedTopic = topicNode;

        if (_selectedTopic != null)
        {
          TopicBox.SelectedItem = _selectedTopic;
          NewTopicBox.Text = _selectedTopic.Topic;

          var allSelected = true;
          for (var i = 0; i < ResponseBox.Items.Count; i++)
          {
            var c = _selectedTopic.Next.Contains(ResponseBox.Items[i]);
            ResponseBox.SetItemChecked(i, c);

            allSelected &= c;
          }
          SelectAllResponses.Checked = allSelected;
        }
        else
        {
          TopicBox.ClearSelected();
          NewTopicBox.Text = "";
          SelectAllResponses.Checked = false;
        }
      }

      ChatListBox_SelectItem(true);
      TopicBox_SelectItem(true);
      TopicBox_ItemCheck(true);
      ResponseBox_ItemCheck(true);
      SelectAllResponses_ItemCheck(true);
    }

    private void RefreshTopics()
    {
      TopicBox.DataSource = null;
      TopicBox.Items.Clear();
      TopicBox.DataSource = Tree.Instance.TreeState.Topics;

      SelectNode(_selectedNode);
    }

    // Form ---------------------------------------------------------------------------

    private void OnFormClosed(object sender, FormClosingEventArgs e)
    {
      if (SaveButton.Enabled)
      {
        var dialogResult = MessageBox.Show("Do you want to save changes?", "Ton Ton", MessageBoxButtons.YesNoCancel);
        if (dialogResult == DialogResult.Yes)
        {
          Tree.Instance.Save();
        }
        else if (dialogResult == DialogResult.Cancel)
        {
          e.Cancel = true;
        }
      }
    }

    // SaveButton ---------------------------------------------------------------------

    private void SaveButton_Click(object sender, System.EventArgs e)
    {
      Tree.Instance.Save();

      UnsavedChanges(false);

      StatusLabel.Text = "Changes saved successfully.";
    }

    // ChatListBox --------------------------------------------------------------------

    private void ChatListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      Debug.WriteLine("ChatListBox_SelectedIndexChanged Start");
      SelectNode(ChatListBox.SelectedItem as Node);
      Debug.WriteLine("ChatListBox_SelectedIndexChanged End");
    }

    // CurrentTopicBox ----------------------------------------------------------------

    private void CurrentTopicBox_SelectedIndexChange(object sender, EventArgs e)
    {
      Debug.WriteLine("CurrentTopicBox_SelectedIndexChange Start");
      if (CurrentTopicBox.SelectedItem != null)
      {
        TopicBox.SelectedItem = CurrentTopicBox.SelectedItem;
      }
      Debug.WriteLine("CurrentTopicBox_SelectedIndexChange End");
    }

    private void CurrentTopicBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      Debug.WriteLine("CurrentTopicBox_ItemCheck Start");
      CurrentTopicBox_SelectItem(false);

      if (e.NewValue == CheckState.Unchecked)
      {
        e.NewValue = e.CurrentValue;

        var checkedTopic = CurrentTopicBox.Items[e.Index];
        TopicBox.SetItemChecked(TopicBox.Items.IndexOf(checkedTopic), false);
      }

      CurrentTopicBox_SelectItem(true);
      Debug.WriteLine("CurrentTopicBox_ItemCheck End");
    }

    // TopicBox -----------------------------------------------------------------------

    private void TopicBox_SelectedIndexChange(object sender, EventArgs e)
    {
      Debug.WriteLine("TopicBox_SelectedIndexChange Start");
      SelectTopic(TopicBox.SelectedItem as TopicNode);
      Debug.WriteLine("TopicBox_SelectedIndexChange End");
    }

    private void TopicBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      Debug.WriteLine("TopicBox_ItemCheck Start");
      CurrentTopicBox_ItemCheck(false);
      CurrentTopicBox_SelectItem(false);
      TopicBox_SelectItem(false);
      TopicBox_ItemCheck(false);
      ResponseBox_ItemCheck(false);

      if (_selectedNode != null)
      {
        var isChecked = e.NewValue == CheckState.Checked;
        var checkedTopic = TopicBox.Items[e.Index] as TopicNode;

        if (checkedTopic != null)
        {
          var existingTopic = _selectedNode.TopicNodes.Contains(checkedTopic);
          if (!isChecked && existingTopic)
          {
            _selectedNode.TopicNodes.Remove(checkedTopic);
            CurrentTopicBox.Items.Remove(checkedTopic);
            UnsavedChanges();
          }
          else if (isChecked && !existingTopic)
          {
            _selectedNode.TopicNodes.Add(checkedTopic);
            CurrentTopicBox.Items.Add(checkedTopic, true);
            UnsavedChanges();
          }

          ResponseBox.Items.Clear();
          ResponseBox.Items.AddRange(_selectedNode.Next.ToArray());
          SelectTopic(checkedTopic);
        }
      }

      CurrentTopicBox_ItemCheck(true);
      CurrentTopicBox_SelectItem(true);
      TopicBox_SelectItem(true);
      TopicBox_ItemCheck(true);
      ResponseBox_ItemCheck(true);
      Debug.WriteLine("TopicBox_ItemCheck End");
    }

    private void AddTopicButton_Click(object sender, EventArgs e)
    {
      Debug.WriteLine("AddTopicButton_Click Start");
      if (NewTopicBox.Text != "")
      {
        var n = NewTopicBox.Text;
        var topics = Tree.Instance.TreeState.Topics;

        var existingTopic = topics.FirstOrDefault(t => t.Topic == n);
        if (existingTopic == null)
        {
          existingTopic = new TopicNode(n);
          topics.Add(existingTopic);
          var i = TopicBox.Items.Add(existingTopic);
          if (_selectedNode != null)
          {
            _selectedNode.TopicNodes.Add(existingTopic);
            TopicBox.SetItemChecked(i, true);
            UnsavedChanges();
          }
        }
        else
        {
          MessageBox.Show($"This topic [{n}] already exists.", "Duplicate Topic", MessageBoxButtons.OK);
        }
        _selectedTopic = existingTopic;
        TopicBox.SelectedItem = _selectedTopic;
      }
      NewTopicBox.Text = "";
      Debug.WriteLine("AddTopicButton_Click End");
    }

    private void EditTopicButton_Click(object sender, EventArgs e)
    {
      Debug.WriteLine("EditTopicButton_Click Start");

      var n = NewTopicBox.Text;
      if (n != "" && _selectedTopic != null && n != _selectedTopic.Topic)
      {
        var topics = Tree.Instance.TreeState.Topics;

        var existingTopic = topics.FirstOrDefault(t => t.Topic == n);
        if (existingTopic == null)
        {
          _selectedTopic.Topic = n;
          RefreshTopics();
          UnsavedChanges();
        }
        else
        {
          var messageResponse = MessageBox.Show($"This topic [{n}] already exists. Would you like to continue with the renaming and merge the two?", "Duplicate Topic", MessageBoxButtons.YesNo);
          if (messageResponse == DialogResult.Yes)
          {
            var mergedTopic = Tree.Instance.MergeTopicNodes(existingTopic, _selectedTopic);
            RefreshTopics();

            SelectTopic(mergedTopic);

            UnsavedChanges();
          }
        }
      }
      Debug.WriteLine("EditTopicButton_Click End");
    }

    // ResponseBox ------------------------------------------------------------------

    private void ResponseBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      Debug.WriteLine("ResponseBox_ItemCheck Start");
      if (_selectedTopic != null)
      {
        var isChecked = e.NewValue == CheckState.Checked;
        var checkedResponse = ResponseBox.Items[e.Index] as Node;

        if (checkedResponse != null)
        {
          var existingResponse = _selectedTopic.Next.Contains(checkedResponse);
          if (!isChecked && existingResponse)
          {
            _selectedTopic.Next.Remove(checkedResponse);
            UnsavedChanges();
          }
          else if (isChecked && !existingResponse)
          {
            _selectedTopic.Next.Add(checkedResponse);
            UnsavedChanges();
          }
        }
      }
      Debug.WriteLine("ResponseBox_ItemCheck End");
    }

    private void ResponseBox_DoubleClick(object sender, EventArgs e)
    {
      Debug.WriteLine("ResponseBox_DoubleClick Start");
      if (ResponseBox.SelectedItem != null)
      {
        ChangeRoot(_selectedNode, ResponseBox.SelectedItem as Node);
      }
      Debug.WriteLine("ResponseBox_DoubleClick Start");
    }

    // SelectAllResponses ----------------------------------------------------------

    private void SelectAllResponses_CheckedChanged(object sender, EventArgs e)
    {
      Debug.WriteLine("SelectAllResponses_CheckedChanged Start");
      SelectAllResponses_ItemCheck(false);

      if (_selectedNode != null && _selectedTopic != null)
      {
        var isChecked = SelectAllResponses.Checked;
        for (var i = 0; i < ResponseBox.Items.Count; i++)
        {
          ResponseBox.SetItemChecked(i, isChecked);
        }
      }

      SelectAllResponses_ItemCheck(true);
      Debug.WriteLine("SelectAllResponses_CheckedChanged End");
    }
  }
}
