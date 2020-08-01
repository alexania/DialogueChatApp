using System.Collections.Generic;

namespace DialogueChatApp.DialogueTree
{
  public class TopicNode
  {
    public TopicNode(string topic)
    {
      Topic = topic;
    }

    public string Topic { get; set; }

    public List<Node> Next { get; set; } = new List<Node>();

    public override string ToString()
    {
      return Topic;
    }
  }
}
