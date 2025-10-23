using System;

namespace API.Entities;

public class DevEventSpeaker
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string TalkTitle { get; set; }
    public required string TalkDescription { get; set; }
    public required string LinkeInProfile { get; set; }
    public Guid DevEventId { get; set; }
}
