namespace DialogueChatApp.DialogueTree.DataSets
{
  public class MovieLine
  {
    public int Index { get; set; }

    public string Speaker { get; set; }

    public string Text { get; set; }

    public MovieSegment[] Segments { get; set; }
  }
}
