namespace App
{
    public class SubwayController : IController
    {
        private ISubway _subway;
        public SubwayController(ISubway subway)
        {
            _subway = subway;
        }

        public string Get()
        {
            _subway.Ride();
            _subway.Board();
            _subway.Exit();
            return "You rode the subway.";
        }
    }
}