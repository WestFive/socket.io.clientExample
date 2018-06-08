package westfive.io.socketioclient.model;

public class Queue {
    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getCreateTime() {
        return createTime;
    }

    public void setCreateTime(String createTime) {
        this.createTime = createTime;
    }

    public String getUpdateTime() {
        return updateTime;
    }

    public void setUpdateTime(String updateTime) {
        this.updateTime = updateTime;
    }

    public Queue(String key, String value, String createTime, String updateTime) {
        this.key = key;
        this.value = value;
        this.createTime = createTime;
        this.updateTime = updateTime;
    }

    public Queue() {

    }

    private String key;
    private String value;
    private String createTime;
    private String updateTime;
}
