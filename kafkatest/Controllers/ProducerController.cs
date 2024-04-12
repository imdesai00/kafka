using CoreApiResponse;
using kafkatest.Models;
using kafkatest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace kafkatest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : BaseController
    {
        private readonly IKafkaConsumerService _kafkaConsumerService;
        private readonly KafkaProducerService _kafkaProducerService;

        public ProducerController(KafkaProducerService kafkaProducerService, IKafkaConsumerService kafkaConsumerService)
        {
            _kafkaConsumerService = kafkaConsumerService;
            _kafkaProducerService = kafkaProducerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarDetails car)
        {
            await _kafkaProducerService.sendmessageAsync(car);
            return Ok("Data add to Kafkaserver");
        }

        //[HttpGet("consume")]
        //public async Task<IActionResult> Consume()
        //{
        //    await _kafkaConsumerService.ConsumeMessagesAsync();
        //    return Ok("Kafka messages consumed successfully.");
        //}

        [HttpGet("partition-0")]
        public IActionResult data()
        {
            var data = _kafkaConsumerService.Getalldata();
            return CustomResult("Partition-0 data ", data, HttpStatusCode.OK);
        }

        //[HttpGet("partition-1")]
        //public IActionResult data1()
        //{
        //    var data1 = _kafkaConsumerService.Getalldata1();
        //    return CustomResult("Partition-1 data ", data1, HttpStatusCode.OK);
        //}

        [HttpGet("stop")]
        public IActionResult StopConsumer()
        {
            _kafkaConsumerService.StopConsumer();
            return Ok("Kafka consumer stopped");
        }
    }
}
