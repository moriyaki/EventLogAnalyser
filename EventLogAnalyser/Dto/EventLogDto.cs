namespace EventLogAnalyser.Dto;

public class EventLogDto
{
    /// <summary>
    /// イベント発生日時
    /// </summary>
    public string Time { get; set; } = string.Empty;
    
    /// <summary>
    /// イベントソース
    /// </summary>
    public string Source { get; set; } = string.Empty;
    
    /// <summary>
    /// イベントID
    /// </summary>
    public string InstanceID { get; set; } = string.Empty;
    
    /// <summary>
    /// イベントレベル
    /// </summary>
    public string Level { get; set; } = string.Empty;

    /// <summary>
    /// イベントメッセージ
    /// </summary>
    public string Message { get; set; } = string.Empty;

}
