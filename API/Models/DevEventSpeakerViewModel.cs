using System;

namespace API.Models;

public class DevEventSpeakerViewModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string TalkTitle { get; set; }
    public required string TalkDescription { get; set; }
    public required string LinkeInProfile { get; set; }
}
