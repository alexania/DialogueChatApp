using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DialogueChatApp.DialogueTree
{
  public class TreeState
  {
    public TreeState()
    {
      Root = new Node("");
      Nodes = new List<Node>
      {
        Root
      };
      Topics = new List<TopicNode> { Root.TopicNodes[0] };
    }

    public TreeState(Node root, List<Node> nodes, List<TopicNode> topics)
    {
      Root = root;
      Nodes = nodes;
      Topics = topics;
    }

    public Node Root { get; set; }

    public List<Node> Nodes { get; set; }

    public List<TopicNode> Topics { get; set; }
  }

  public sealed class Tree
  {
    private State _state;

    static Tree()
    {
    }

    private Tree()
    {
      _state = new State();
      TreeState = new TreeState();
    }

    public static Tree Instance { get; } = new Tree();

    public TreeState TreeState { get; set; }

    public Node Root => TreeState.Root;

    public void Save()
    {
      //Root.Squish();

      var json = JsonConvert.SerializeObject(TreeState, Formatting.Indented, new TreeStateConverter());
      using (var file = new StreamWriter(@"..\..\..\..\data\processed_conversations.json"))
      {
        file.WriteLine(json);
      }
      Console.WriteLine("Conversation successfully saved.");
    }

    public void Load()
    {
      using (var file = new StreamReader(@"..\..\..\..\data\processed_conversations.json"))
      {
        var json = file.ReadToEnd();
        TreeState = JsonConvert.DeserializeObject<TreeState>(json, new TreeStateConverter());
      }

      Console.WriteLine("Conversation successfully loaded.");
    }

    public Node AddNext(Node node, string text)
    {
      var existingNode = TreeState.Nodes.FirstOrDefault(t => t.Text.Equals(text, StringComparison.OrdinalIgnoreCase));

      if (existingNode == null)
      {
        existingNode = new Node(text);
        TreeState.Nodes.Add(existingNode);
        TreeState.Topics.Add(existingNode.TopicNodes[0]);
      }
      if (!node.TopicNodes[0].Next.Any(t => t == existingNode))
      {
        node.TopicNodes[0].Next.Add(existingNode);
      }

      return existingNode;
    }

    public Node GetRandomResponse(Node node)
    {
      var validResponses = node.GetValidResponses(_state);
      if (validResponses.Count == 0)
      {
        if (node != Root)
        {
          return GetRandomResponse(Root);
        }
        return null;
      }
      return Utils.GetRandomFromList(validResponses);
    }

    public IList<Node> GetValidResponses(Node node = null)
    {
      if (node == null)
      {
        node = Root;
      }

      var validResponses = node.GetValidResponses(_state);
      if (validResponses.Count == 0)
      {
        if (node != Root)
        {
          return GetValidResponses(Root);
        }
        return null;
      }
      return validResponses;
    }

    public TopicNode MergeTopicNodes(TopicNode mergeInto, TopicNode topicNode)
    {
      mergeInto.Next = mergeInto.Next.Union(topicNode.Next).ToList();

      for (var n = 0; n < TreeState.Nodes.Count; n++)
      {
        var topicNodes = TreeState.Nodes[n].TopicNodes;
        if (topicNodes.Contains(topicNode))
        {
          if (!topicNodes.Contains(mergeInto))
          {
            topicNodes.Add(mergeInto);
          }
          topicNodes.Remove(topicNode);
        }
      }

      TreeState.Topics.Remove(topicNode);

      return mergeInto;
    }
  }
}