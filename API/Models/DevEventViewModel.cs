using System;

namespace API.Models;

public class DevEventViewModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<DevEventSpeakerViewModel> Speakers { get; set; }
}
