namespace App
{
    public class Ferry : IFerry
    {
        private ILogger _logger;
        public Ferry(ILogger logger)
        {
            _logger = logger;
        }
        public void Board()
        {
            _logger.Info("All aboard the ferry!");
        }

        public void Exit()
        {
            _logger.Info("Land ho! The ferry ride is over");
        }

        public void Ride()
        {
            _logger.Info("🛥️...🛥️...🛥️...🛥️");
        }
    }
}