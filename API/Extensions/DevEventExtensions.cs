using System;
using API.Entities;
using API.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Extensions;

public static class DevEventExtensions
{
    #region ToViewModel

    public static DevEventViewModel ToViewModel(this DevEvent entity)
    {
        return new DevEventViewModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Speakers = entity.Speakers?.Select(s => new DevEventSpeakerViewModel
            {
                Id = s.Id,
                Name = s.Name,
                TalkTitle = s.TalkTitle,
                TalkDescription = s.TalkDescription,
                LinkeInProfile = s.LinkeInProfile
            }).ToList() ?? []
        };
    }

    public static DevEventSpeakerViewModel ToViewModel(this DevEventSpeaker entity)
    {
        return new DevEventSpeakerViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
            TalkTitle = entity.TalkTitle,
            TalkDescription = entity.TalkDescription,
            LinkeInProfile = entity.LinkeInProfile
        };
    }

    public static List<DevEventViewModel> ToViewModelList(this IEnumerable<DevEvent> entities)
    {
        return entities?.Select(e => e.ToViewModel()).ToList() ?? [];
    }

    #endregion

    #region FromInputModel

    public static DevEvent ToEntity(this DevEventInputModel input)
    {
        return new DevEvent
        {
            Title = input.Title,
            Description = input.Description,
            StartDate = input.StartDate,
            EndDate = input.EndDate
        };
    }

    public static DevEventSpeaker ToEntity(this DevEventSpeakerInputModel input)
    {
        return new DevEventSpeaker
        {
            Name = input.Name,
            TalkTitle = input.TalkTitle,
            TalkDescription = input.TalkDescription,
            LinkeInProfile = input.LinkeInProfile
        };
    }


    #endregion
}
