package westfive.io.socketioclient;

import io.socket.client.Ack;
import io.socket.client.IO;
import io.socket.client.Socket;
import io.socket.emitter.Emitter;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;
import westfive.io.socketioclient.model.*;
import westfive.io.socketioclient.model.PoolAction.Pool_Create;
import westfive.io.socketioclient.model.QueueAction.Queue_Add;
import westfive.io.socketioclient.util.GsonHelper;

import java.net.URI;
import java.time.LocalDateTime;
import java.util.List;

@Component
public class MessageHubClient {



    private GsonHelper gsonHelper = new GsonHelper();

    private Logger logger = LoggerFactory.getLogger(MessageHubClient.class);

    Socket socket;


    public  MessageHubClient(@Value("${messageAddress}") String messageAddress ,@Value("${userName}" )String userName ){

        URI url = URI.create(messageAddress);
        socket = IO.socket(url);
        //step 1 连接消息服务
        socket.on(Socket.EVENT_CONNECT, new Emitter.Listener() {
            @Override
            public void call(Object... objects) {
                socket.emit("authentication","javaClient");
            }
            //step 2 连接接收回调中调用emit("authentication",userId)向消息服务内注册


        });
        socket.on("sessionList", new Emitter.Listener() {
            @Override
            public void call(Object... objects) {
                List<Connection> list = (List<Connection>) gsonHelper.EncodeList(objects[0].toString(),Connection.class);
            }


        }).on("serverResponse", new Emitter.Listener() {
            @Override
            public void call(Object... objects) {
               Response res =   (Response)gsonHelper.EncodeObject(objects[0].toString(),Response.class);

            }
        });

        socket.on("listenPools", new Emitter.Listener() {
            @Override
            public void call(Object... objects) {
               // logger.info("listenPools|"+gson.toJson(objects[0]));
                List<Pool> list = (List<Pool>)gsonHelper.EncodeList(objects[0].toString(),Pool.class);
            }
        });

        //step3 开启与消息服务的连接（在注册监听之后）
        socket.connect();

        //step4 向消息服务指定的方法发送数据。
        Pool_Create pool_create = new Pool_Create("javaClientPool","private","key",false);
        socket.emit("createPool", gsonHelper.toJson(pool_create), new Ack() {
            @Override
            public void call(Object... objects) {

            }
        });
        socket.emit("addQueue",gsonHelper.toJson( new Queue_Add("javaClientPool", new Queue("13579","2468", LocalDateTime.now().toString(),LocalDateTime.now().toString()))));
        socket.emit("updateQueue",gsonHelper.toJson(new Queue_Add("javaClientPool",new Queue("13579","246810", LocalDateTime.now().toString(),LocalDateTime.now().toString()))));



    }

}
