// Should not be used in Judge
using System.Collections.Generic;

public interface IMissionController
{
    int SuccessMissionCounter { get; }

    int FailedMissionCounter { get; }

    Queue<IMission> Missions { get; }

    string PerformMission(IMission mission);

    void FailMissionsOnHold();
}