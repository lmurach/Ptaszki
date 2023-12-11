using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.ControllerData;

public class RemovedBird
{
    public string birdId { get; set; }

    public string birdPosition { get; set; }
}