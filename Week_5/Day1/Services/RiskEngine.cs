using CardiacMonitoring.Api.Domain;
namespace CardiacMonitoring.Api.Services;

public class RiskEngine
{

    public RiskLevel Evaluate(VitalSign vital)
    {
        if (vital.HeartRate < 40 || vital.HeartRate > 160)
        {
            return RiskLevel.Critical;
        }

        if (vital.HeartRate < 60 || vital.HeartRate > 100)
        {
            return RiskLevel.Warning;
        }

        return RiskLevel.Normal;
    }
}
