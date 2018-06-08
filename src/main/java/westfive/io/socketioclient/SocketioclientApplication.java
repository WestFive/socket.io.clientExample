package westfive.io.socketioclient;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class SocketioclientApplication {



	public static void main(String[] args) {
		SpringApplication.run(SocketioclientApplication.class, args);

	}

	@Autowired
	MessageHubClient messageHubClient;




}
