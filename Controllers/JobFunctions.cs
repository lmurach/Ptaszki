using BirdGame.ControllerData;
using BirdGame.Data;

public static class JobFunctions {

    public static int FindEmptyJobIndex(UserGame UserGameEntity) {
        for (int i = 0; i < 5; i++) {
            Console.WriteLine(UserGameEntity.jobBirds[i].Bird.Id);
            if (UserGameEntity.jobBirds[i].Bird.Id == 999) {
                return i;
            }
        }
        return -1;
    }

    public static void RemoveOldBird(
        UserGame UserGameEntity, 
        BirdDbContext _context, int index) 
        {
        _context.jobBirds.RemoveRange(_context.jobBirds
            .Where(r => r.User.Id == UserGameEntity.Id 
                && r.SlotNum == index));
    }

    public static JobBird AddJobBird(
        UserGame UserGameEntity, Bird nullBird, 
        BirdDbContext _context, int index) 
        {
        JobBird jobBird = new JobBird {
            User = UserGameEntity, 
            Bird = nullBird, 
            SlotNum = index
        };
        addJobSkills(jobBird);
        _context.Add(jobBird);
        return jobBird;
    }

    static void addJobSkills(JobBird jobBird) {
        jobBird.JS_SeedCollector = 
            calculateSkill(jobBird.Bird.Strength, jobBird.Bird.Hunting);
        jobBird.JS_RockBreaker = 
            calculateSkill(jobBird.Bird.Strength, jobBird.Bird.Strength);
        jobBird.JS_Gatherer = 
            calculateSkill(jobBird.Bird.Perception, jobBird.Bird.Perception);
        jobBird.JS_Hunter = 
            calculateSkill(jobBird.Bird.Hunting, jobBird.Bird.Hunting);
        jobBird.JS_FeatherFeatcher = 
            calculateSkill(jobBird.Bird.Strength, jobBird.Bird.Perception);
        jobBird.JS_BugFinder = 
            calculateSkill(jobBird.Bird.Perception, jobBird.Bird.Hunting);
    }

    static int calculateSkill(int b1, int b2) {
        return b1 + b2 - 9;
    }

    public static List<string> JobObjToStringList(DailyJob dailyJob) {
        List<string> dailyJobStrings = new List<string>();
        dailyJobStrings.Add(dailyJob.Bird0);
        dailyJobStrings.Add(dailyJob.Bird1);
        dailyJobStrings.Add(dailyJob.Bird2);
        dailyJobStrings.Add(dailyJob.Bird3);
        dailyJobStrings.Add(dailyJob.Bird4);
        return dailyJobStrings;
    }
}