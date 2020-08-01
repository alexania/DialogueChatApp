namespace DialogueChatApp
{
  partial class ChatBotForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.EditLineBox = new System.Windows.Forms.TextBox();
      this.SaveButton = new System.Windows.Forms.Button();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.NewTopicBox = new System.Windows.Forms.TextBox();
      this.AddTopicButton = new System.Windows.Forms.Button();
      this.ChatListBox = new System.Windows.Forms.ListBox();
      this.ResponseBox = new System.Windows.Forms.CheckedListBox();
      this.RightSplitContainer = new System.Windows.Forms.SplitContainer();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.CurrentTopicBox = new System.Windows.Forms.CheckedListBox();
      this.EditTopicButton = new System.Windows.Forms.Button();
      this.TopicBox = new System.Windows.Forms.CheckedListBox();
      this.SelectAllResponses = new System.Windows.Forms.CheckBox();
      this.SplitContainer = new System.Windows.Forms.SplitContainer();
      this.StatusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.RightSplitContainer)).BeginInit();
      this.RightSplitContainer.Panel1.SuspendLayout();
      this.RightSplitContainer.Panel2.SuspendLayout();
      this.RightSplitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
      this.SplitContainer.Panel1.SuspendLayout();
      this.SplitContainer.Panel2.SuspendLayout();
      this.SplitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // EditLineBox
      // 
      this.EditLineBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.EditLineBox.Location = new System.Drawing.Point(0, 362);
      this.EditLineBox.Multiline = true;
      this.EditLineBox.Name = "EditLineBox";
      this.EditLineBox.Size = new System.Drawing.Size(754, 96);
      this.EditLineBox.TabIndex = 1;
      // 
      // SaveButton
      // 
      this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.SaveButton.Location = new System.Drawing.Point(634, 464);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(120, 23);
      this.SaveButton.TabIndex = 2;
      this.SaveButton.Text = "Save Changes";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // StatusStrip
      // 
      this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
      this.StatusStrip.Location = new System.Drawing.Point(0, 490);
      this.StatusStrip.Name = "StatusStrip";
      this.StatusStrip.Size = new System.Drawing.Size(1219, 22);
      this.StatusStrip.TabIndex = 3;
      this.StatusStrip.Text = "StatusStrip";
      // 
      // StatusLabel
      // 
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(67, 17);
      this.StatusLabel.Text = "StatusLabel";
      // 
      // NewTopicBox
      // 
      this.NewTopicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.NewTopicBox.Location = new System.Drawing.Point(3, 333);
      this.NewTopicBox.Name = "NewTopicBox";
      this.NewTopicBox.Size = new System.Drawing.Size(265, 20);
      this.NewTopicBox.TabIndex = 6;
      // 
      // AddTopicButton
      // 
      this.AddTopicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.AddTopicButton.Location = new System.Drawing.Point(332, 332);
      this.AddTopicButton.Name = "AddTopicButton";
      this.AddTopicButton.Size = new System.Drawing.Size(52, 21);
      this.AddTopicButton.TabIndex = 7;
      this.AddTopicButton.Text = "Add";
      this.AddTopicButton.UseVisualStyleBackColor = true;
      this.AddTopicButton.Click += new System.EventHandler(this.AddTopicButton_Click);
      // 
      // ChatListBox
      // 
      this.ChatListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ChatListBox.FormattingEnabled = true;
      this.ChatListBox.Location = new System.Drawing.Point(0, 0);
      this.ChatListBox.Name = "ChatListBox";
      this.ChatListBox.Size = new System.Drawing.Size(458, 490);
      this.ChatListBox.Sorted = true;
      this.ChatListBox.TabIndex = 8;
      // 
      // ResponseBox
      // 
      this.ResponseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ResponseBox.FormattingEnabled = true;
      this.ResponseBox.Location = new System.Drawing.Point(0, 30);
      this.ResponseBox.Name = "ResponseBox";
      this.ResponseBox.Size = new System.Drawing.Size(369, 304);
      this.ResponseBox.Sorted = true;
      this.ResponseBox.TabIndex = 9;
      this.ResponseBox.DoubleClick += new System.EventHandler(this.ResponseBox_DoubleClick);
      // 
      // RightSplitContainer
      // 
      this.RightSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.RightSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.RightSplitContainer.Name = "RightSplitContainer";
      // 
      // RightSplitContainer.Panel1
      // 
      this.RightSplitContainer.Panel1.Controls.Add(this.label2);
      this.RightSplitContainer.Panel1.Controls.Add(this.label1);
      this.RightSplitContainer.Panel1.Controls.Add(this.CurrentTopicBox);
      this.RightSplitContainer.Panel1.Controls.Add(this.EditTopicButton);
      this.RightSplitContainer.Panel1.Controls.Add(this.TopicBox);
      this.RightSplitContainer.Panel1.Controls.Add(this.NewTopicBox);
      this.RightSplitContainer.Panel1.Controls.Add(this.AddTopicButton);
      // 
      // RightSplitContainer.Panel2
      // 
      this.RightSplitContainer.Panel2.Controls.Add(this.SelectAllResponses);
      this.RightSplitContainer.Panel2.Controls.Add(this.ResponseBox);
      this.RightSplitContainer.Size = new System.Drawing.Size(757, 362);
      this.RightSplitContainer.SplitterDistance = 384;
      this.RightSplitContainer.TabIndex = 10;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(0, 124);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Available Topics";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Associated Topics";
      // 
      // CurrentTopicBox
      // 
      this.CurrentTopicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CurrentTopicBox.FormattingEnabled = true;
      this.CurrentTopicBox.Location = new System.Drawing.Point(0, 26);
      this.CurrentTopicBox.Name = "CurrentTopicBox";
      this.CurrentTopicBox.Size = new System.Drawing.Size(384, 94);
      this.CurrentTopicBox.Sorted = true;
      this.CurrentTopicBox.TabIndex = 9;
      // 
      // EditTopicButton
      // 
      this.EditTopicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.EditTopicButton.Location = new System.Drawing.Point(274, 332);
      this.EditTopicButton.Name = "EditTopicButton";
      this.EditTopicButton.Size = new System.Drawing.Size(52, 21);
      this.EditTopicButton.TabIndex = 8;
      this.EditTopicButton.Text = "Edit";
      this.EditTopicButton.UseVisualStyleBackColor = true;
      this.EditTopicButton.Click += new System.EventHandler(this.EditTopicButton_Click);
      // 
      // TopicBox
      // 
      this.TopicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TopicBox.FormattingEnabled = true;
      this.TopicBox.Location = new System.Drawing.Point(0, 141);
      this.TopicBox.Name = "TopicBox";
      this.TopicBox.Size = new System.Drawing.Size(384, 184);
      this.TopicBox.Sorted = true;
      this.TopicBox.TabIndex = 5;
      // 
      // SelectAllResponses
      // 
      this.SelectAllResponses.AutoSize = true;
      this.SelectAllResponses.Location = new System.Drawing.Point(3, 12);
      this.SelectAllResponses.Name = "SelectAllResponses";
      this.SelectAllResponses.Size = new System.Drawing.Size(70, 17);
      this.SelectAllResponses.TabIndex = 10;
      this.SelectAllResponses.Text = "Select All";
      this.SelectAllResponses.UseVisualStyleBackColor = true;
      // 
      // SplitContainer
      // 
      this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer.Name = "SplitContainer";
      // 
      // SplitContainer.Panel1
      // 
      this.SplitContainer.Panel1.Controls.Add(this.ChatListBox);
      // 
      // SplitContainer.Panel2
      // 
      this.SplitContainer.Panel2.Controls.Add(this.RightSplitContainer);
      this.SplitContainer.Panel2.Controls.Add(this.EditLineBox);
      this.SplitContainer.Panel2.Controls.Add(this.SaveButton);
      this.SplitContainer.Size = new System.Drawing.Size(1219, 490);
      this.SplitContainer.SplitterDistance = 458;
      this.SplitContainer.TabIndex = 11;
      // 
      // ChatBotForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1219, 512);
      this.Controls.Add(this.SplitContainer);
      this.Controls.Add(this.StatusStrip);
      this.Name = "ChatBotForm";
      this.Text = "Ton Ton";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosed);
      this.StatusStrip.ResumeLayout(false);
      this.StatusStrip.PerformLayout();
      this.RightSplitContainer.Panel1.ResumeLayout(false);
      this.RightSplitContainer.Panel1.PerformLayout();
      this.RightSplitContainer.Panel2.ResumeLayout(false);
      this.RightSplitContainer.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.RightSplitContainer)).EndInit();
      this.RightSplitContainer.ResumeLayout(false);
      this.SplitContainer.Panel1.ResumeLayout(false);
      this.SplitContainer.Panel2.ResumeLayout(false);
      this.SplitContainer.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
      this.SplitContainer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox EditLineBox;
    private System.Windows.Forms.Button SaveButton;
    private System.Windows.Forms.StatusStrip StatusStrip;
    private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    private System.Windows.Forms.TextBox NewTopicBox;
    private System.Windows.Forms.Button AddTopicButton;
    private System.Windows.Forms.ListBox ChatListBox;
    private System.Windows.Forms.CheckedListBox ResponseBox;
    private System.Windows.Forms.SplitContainer RightSplitContainer;
    private System.Windows.Forms.CheckedListBox TopicBox;
    private System.Windows.Forms.Button EditTopicButton;
    private System.Windows.Forms.CheckBox SelectAllResponses;
    private System.Windows.Forms.SplitContainer SplitContainer;
    private System.Windows.Forms.CheckedListBox CurrentTopicBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}

