using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DialogueChatApp.DialogueTree.DataSets
{
  public static class MovieDialogueDataSet
  {
    public static void LoadData(Tree tree)
    {
      IList<MovieConversation> conversations;
      using (var file = new StreamReader(@"..\..\..\..\data\dialog_data_corpus.json"))
      {
        var json = file.ReadToEnd();
        conversations = JsonConvert.DeserializeObject<IList<MovieConversation>>(json);
      }

      for (var i = 0; i < conversations.Count; i++)
      {
        var lines = conversations[i].Utterances.OrderBy(t => t.Index).ToList();
        var node = tree.Root;
        for (var j = 0; j < lines.Count; j++)
        {
          var movieLine = lines[j];
          node = tree.AddNext(node, movieLine.Text);
        }
      }

      Console.WriteLine($"Successfully loaded {conversations.Count} Conversations.");
    }
  }
}
