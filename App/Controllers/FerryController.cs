namespace App
{
    public class FerryController : IController
    {
        private IFerry _ferry;
        public FerryController(IFerry ferry)
        {
            _ferry = ferry;
        }

        public string Get()
        {
            _ferry.Ride();
            _ferry.Board();
            _ferry.Exit();
            return "You rode the ferry.";
        }
    }
}