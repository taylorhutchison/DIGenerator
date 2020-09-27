namespace App
{
    public class Bus : IBus
    {
        private ILogger _logger;

        public Bus(ILogger logger)
        {
            _logger = logger;
        }
        public void Board()
        {
            _logger.Info("The bus is here. Time to ride!");
        }

        public void Exit()
        {
            _logger.Info("Remember to thank the driver! Goodbye.");
        }

        public void Ride()
        {
            _logger.Info("🚌...🚌...🚌...🚌");
        }
    }
}