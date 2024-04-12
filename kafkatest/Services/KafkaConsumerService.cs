using Confluent.Kafka;
using kafkatest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading;
using static Confluent.Kafka.ConfigPropertyNames;

namespace kafkatest.Services
{
    public interface IKafkaConsumerService
    {
        IEnumerable<CarDetails> Getalldata();
        IEnumerable<CarDetails> Getalldata1();
        void StopConsumer();
    }
    public class KafkaConsumerService : IKafkaConsumerService
    {
        private readonly string _bootstrapserver;
        private readonly string _topic;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly string _groupId;

        public KafkaConsumerService(IConfiguration configuration)
        {
            _bootstrapserver = configuration["kafka:BootstrapServers"];
            _groupId = configuration["kafka:GroupId"];
            _topic = configuration["kafka:TopicName"];
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public IEnumerable<CarDetails> Getalldata1()
        {
            var data2 = new List<CarDetails>();
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapserver,
                GroupId = _groupId
            };
            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Assign(new TopicPartitionOffset(_topic, 1, Offset.Beginning));

                try
                {
                    while (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        var result = consumer.Consume(_cancellationTokenSource.Token);
                        Console.WriteLine($"Consumed message from partition {result.Partition}: {result.Value}");
                        var data = new CarDetails();
                        data = JsonSerializer.Deserialize<CarDetails>(result.Value);
                        data2.Add(data);
                    }
                    return data2;
                }
                catch (OperationCanceledException)
                {
                    return data2;
                    consumer.Close();
                }
            }
        }
        public IEnumerable<CarDetails> Getalldata()
        {
            var data1 = new List<CarDetails>();
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapserver,
                GroupId = _groupId
            };
            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Assign(new TopicPartitionOffset(_topic, 1, Offset.Beginning));

                try
                {
                    while (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        var result = consumer.Consume(_cancellationTokenSource.Token);
                        Console.WriteLine($"Consumed message from partition {result.Partition}: {result.Value}");
                        var data = new CarDetails();
                        data = JsonSerializer.Deserialize<CarDetails>(result.Value);
                        data1.Add(data);
                    }
                    return data1;
                }
                catch (OperationCanceledException)
                {
                    return data1;
                    consumer.Close();
                }
            }
        }
        public void StopConsumer()
        {
            _cancellationTokenSource.Cancel();
        }
        
        
        //public async Task ConsumeMessagesAsync()
        //{
        //    var config = new ConsumerConfig
        //    {
        //        BootstrapServers = _bootstrapserver,
        //        GroupId = _groupId,
        //        AutoOffsetReset = AutoOffsetReset.Earliest
        //    };
        //    using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        //    {
        //        consumer.Subscribe(_topic);

        //        while (true)
        //        {
        //            try
        //            {
        //                var consumeResult = consumer.Consume();
        //                if (consumeResult is null)
        //                {
        //                    continue;
        //                }
        //                Console.WriteLine($"Received message: Key = {consumeResult.Message.Key}, Value = {consumeResult.Message.Value}");
        //            }
        //            catch (ConsumeException ex)
        //            {
        //                Console.WriteLine($"Error consuming message: {ex.Message}");
        //            }
        //        }
        //    }
        //}
    }
}
