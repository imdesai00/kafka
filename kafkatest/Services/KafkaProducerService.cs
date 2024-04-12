using Confluent.Kafka;
using kafkatest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kafkatest.Services
{
    public class KafkaProducerService
    {
        private readonly string? _bootstrapserver;
        private readonly string? _topic;

        public KafkaProducerService(IConfiguration configuration)
        {
            _bootstrapserver = configuration["kafka:BootstrapServers"];
            _topic = configuration["kafka:TopicName"];
        }

        public async Task<bool> sendmessageAsync(CarDetails car)
        {
            string serializedData = JsonConvert.SerializeObject(car);
            var config = new ProducerConfig 
            { 
                BootstrapServers = _bootstrapserver
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var topicPart = new TopicPartition(_topic, new Partition(car.PartationID));
                    var message = new Message<Null, string> { Value = serializedData };
                    var result = await producer.ProduceAsync(topicPart, message);
                    return true;              
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Failed to send message to {_topic}: {e.Message}");
                    return false;
                }
                finally
                {
                    producer.Dispose();
                }
            }
        }
    }
}
