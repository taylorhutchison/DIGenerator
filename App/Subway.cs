namespace App
{
    public class Subway : ISubway
    {
        private ILogger _logger;
        public Subway(ILogger logger)
        {
            _logger = logger;
        }
        public void Board()
        {
            _logger.Info("Doors opening. Welcome to the subway!");
        }

        public void Exit()
        {
            _logger.Info("We've reached your destination. Thanks for riding the subway!");
        }

        public void Ride()
        {
            _logger.Info("🚇...🚇...🚇...🚇");
        }
    }
}