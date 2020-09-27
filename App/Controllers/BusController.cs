namespace App
{
    public class BusController : IController
    {
        private IBus _bus;
        public BusController(IBus bus)
        {
            _bus = bus;
        }

        public string Get()
        {
            _bus.Ride();
            _bus.Board();
            _bus.Exit();
            return "You rode the bus";
        }
    }
}