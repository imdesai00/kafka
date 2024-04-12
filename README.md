
# Kafka Producer-Consumer Project with JSON Data

        This project demonstrates the use of Apache Kafka for building a messaging system with a producer-consumer architecture. The producer component is responsible for generating data in JSON format and sending it to Kafka topics, while the consumer component consumes this JSON data and displays it to the user.


## Features

- Apache Kafka: Apache Kafka is used as the messaging backbone for this project. Kafka provides a distributed, fault-tolerant, and scalable platform for building real-time data pipelines and streaming applications.

- Producer: The producer component generates data in JSON format and publishes it to Kafka topics. This data can represent various types of events, messages, or records that need to be processed by the consumer.

- Consumer: The consumer component subscribes to Kafka topics, consumes the JSON data produced by the producer, and processes it accordingly. In this project, the consumer displays the JSON data to the user, but it can be extended to perform any desired processing or analytics.


## Technologies Used

**ASP.NET Core:** The primary framework for building web applications and APIs.

**KAFKA:** Apache Kafka is distributed data streaming platform that can process and store streams of data in real-time.

**Swagger UI:** A tool to document and test APIs.

**PostgreSQL:** A lightweight, file-based database used for local development and testing.

## Download
You can download kafka from here 
https://kafka.apache.org/downloads

- first change 'datadir' path of server.properties & zookeeper.properties file in config.
- first run zookeeper service 
- secound run kafka service
- now you can play with kafka it's ready to use.....
## Deployment

1. To Clone this Project

```bash
    git clone https://github.com/imdesai00/kafka-producer-consumer.git
```

2. Install Kafka: Install Apache Kafka on your local machine or set up a Kafka cluster if you haven't already. You can follow the official Apache Kafka documentation for installation instructions.

3. Start Kafka Server: Start the Kafka server and ensure that it is running properly. You may need to configure Kafka settings such as broker addresses and topic configurations.

4. Configure Producer: Update the producer configuration to specify the Kafka broker address and the topic to which the producer will publish JSON data.

5. Configure Consumer: Update the consumer configuration to specify the Kafka broker address and the topic from which the consumer will consume JSON data.

6. Run Producer: Start the producer component to generate and publish JSON data to Kafka topics.

7. Run Consumer: Start the consumer component to subscribe to Kafka topics, consume JSON data, and display it to the user.

