using System.Collections.Generic;

namespace DialogueChatApp.DialogueTree.DataSets
{
  public class MovieConversation
  {
    public string ConversationId { get; set; }

    public IList<MovieLine> Utterances { get; set; }
  }
}
