package westfive.io.socketioclient.model;

public class MessageBean {
    private String eventName;
    private Object data;

    public MessageBean(String eventName, Object data) {
        this.eventName = eventName;
        this.data = data;
    }

    public MessageBean() {
    }

    public String getEventName() {

        return eventName;
    }

    public void setEventName(String eventName) {
        this.eventName = eventName;
    }

    public Object getData() {
        return data;
    }

    public void setData(Object data) {
        this.data = data;
    }
}
