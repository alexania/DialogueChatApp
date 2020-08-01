using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogueChatApp.DialogueTree
{
  public class Node
  {

    public Node(string text, IList<TopicNode> topicNodes = null)
    {
      Text = text;
      TopicNodes = topicNodes ?? new List<TopicNode> { new TopicNode(text) };
    }

    public string Text { get; set; }

    public IList<TopicNode> TopicNodes { get; set; }

    public IList<Node> Next => TopicNodes.SelectMany(t => t.Next).Distinct().ToList();

    public IList<Node> GetValidResponses(State state)
    {
      return Next;
    }

    public override string ToString()
    {
      return Text;
    }
  }
}
