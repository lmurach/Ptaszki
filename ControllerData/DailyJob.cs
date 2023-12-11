using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.ControllerData;

public class DailyJob
{
    public string Bird0 { get; set; } = "";
    public string Bird1 { get; set; } = "";
    public string Bird2 { get; set; } = "";
    public string Bird3 { get; set; } = "";
    public string Bird4 { get; set; } = "";
}