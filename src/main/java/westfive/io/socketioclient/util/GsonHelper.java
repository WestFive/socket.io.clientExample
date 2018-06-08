package westfive.io.socketioclient.util;

import com.google.gson.Gson;
import com.google.gson.JsonSyntaxException;
import org.springframework.stereotype.Component;
import westfive.io.socketioclient.model.Connection;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

@Component
public class GsonHelper {

    private Gson gson = new Gson();

    public <T> List<T> EncodeList(String json, Class<T> classOfT) {
        List<Map<String,Object>> list = gson.fromJson(json,List.class);
        List<T> connections = new ArrayList<>();
        for (Map<String,Object> m: list
                ) {
            T connection = gson.fromJson(gson.toJson(m),classOfT);
            connections.add(connection);
        }
        return  connections;
    }

    public <T> Object EncodeObject(String json,Class<T> classOfT){
        return gson.fromJson(json,classOfT);
    }

    public String toJson(Object obj) {
        return  gson.toJson(obj);
    }
}
