namespace DialogueChatApp.DialogueTree.DataSets
{
  public class MovieSegment
  {
    public int StartIndex { get; set; }

    public int EndIndex { get; set; }

    public string Text { get; set; }

    public MovieAnnotation[] Annotations { get; set; }
  }
}