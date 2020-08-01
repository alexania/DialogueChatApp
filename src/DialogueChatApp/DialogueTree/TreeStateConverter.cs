using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogueChatApp.DialogueTree
{
  public class TreeStateConverter : JsonConverter<TreeState>
  {
    public override TreeState ReadJson(JsonReader reader, Type objectType, TreeState existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
      var token = JToken.Load(reader);

      var nodes = new Dictionary<string, Node>();
      var topics = new Dictionary<string, TopicNode>();

      var jNodes = (JArray)token["Nodes"];
      var jTopics = (JArray)token["Topics"];

      foreach (var jTopic in jTopics)
      {
        var topicString = (string)jTopic["Topic"];
        topics.Add(topicString, new TopicNode(topicString));
      }

      foreach (var jNode in jNodes)
      {
        var textString = (string)jNode["Text"];
        var jNodeTopics = (JArray)jNode["Topics"];

        var topicNodes = new List<TopicNode>();
        foreach (string topicString in jNodeTopics)
        {
          if (topics.TryGetValue(topicString, out var topicNode))
          {
            topicNodes.Add(topicNode);
          }
        }
        nodes.Add(textString, new Node(textString, topicNodes));
      }

      foreach (var jTopic in jTopics)
      {
        var topicString = (string)jTopic["Topic"];
        var jTopicNext = (JArray)jTopic["Next"];

        if (topics.TryGetValue(topicString, out var topicNode))
        {
          foreach (string textString in jTopicNext)
          {
            if (nodes.TryGetValue(textString, out var node))
            {
              topicNode.Next.Add(node);
            }
          }
        }
      }

      return new TreeState(nodes["Root"], nodes.Values.ToList(), topics.Values.ToList());
    }

    public override void WriteJson(JsonWriter writer, TreeState value, JsonSerializer serializer)
    {
      writer.WriteStartObject();

      writer.WritePropertyName("Root");
      writer.WriteValue(value.Root.Text);

      writer.WritePropertyName("Nodes");
      writer.WriteStartArray();
      foreach (var node in value.Nodes)
      {
        writer.WriteStartObject();
        writer.WritePropertyName("Text");
        writer.WriteValue(node.Text);
        writer.WritePropertyName("Topics");
        writer.WriteStartArray();
        foreach (var topic in node.TopicNodes)
        {
          writer.WriteValue(topic.Topic);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
      }
      writer.WriteEndArray();

      writer.WritePropertyName("Topics");
      writer.WriteStartArray();
      foreach (var topic in value.Topics)
      {
        writer.WriteStartObject();
        writer.WritePropertyName("Topic");
        writer.WriteValue(topic.Topic);
        writer.WritePropertyName("Next");
        writer.WriteStartArray();
        foreach (var node in topic.Next)
        {
          writer.WriteValue(node.Text);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
      }
      writer.WriteEndArray();

      writer.WriteEndObject();
    }
  }
}
