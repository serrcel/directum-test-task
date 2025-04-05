using Directum.Backend.Core.Common;

namespace Directum.Backend.Core.Entities;

public class Event: BaseEntity
{
    public DateTime EventDate { get; private set; }
    public string Description { get; private set; }
    public int ParticipantsCount { get; private set; }
    public int RequiredParticipants { get; private set; }

    public Event(DateTime eventDate, string description, int requiredParticipants)
    {
        EventDate = eventDate;
        Description = description;
        RequiredParticipants = requiredParticipants;
    }

    public void AddParticipant()
    {
        ParticipantsCount++;
    }

    public bool IsConfirmed() => ParticipantsCount >= RequiredParticipants;
}