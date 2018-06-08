package westfive.io.socketioclient.model;

import java.util.Collection;

public class Pool {
    private String poolName;
    private String poolMode;
    private Collection<Queue> queues;
    private String queuesSortColumn;
    private String creator;
    private String createTime;

    public Pool(String poolName, String poolMode, Collection<Queue> queues, String queuesSortColumn, String creator, String createTime) {
        this.poolName = poolName;
        this.poolMode = poolMode;
        this.queues = queues;
        this.queuesSortColumn = queuesSortColumn;
        this.creator = creator;
        this.createTime = createTime;
    }

    public Pool() {

    }

    public String getPoolName() {

        return poolName;
    }

    public void setPoolName(String poolName) {
        this.poolName = poolName;
    }

    public String getPoolMode() {
        return poolMode;
    }

    public void setPoolMode(String poolMode) {
        this.poolMode = poolMode;
    }

    public Collection<Queue> getQueues() {
        return queues;
    }

    public void setQueues(Collection<Queue> queues) {
        this.queues = queues;
    }

    public String getQueuesSortColumn() {
        return queuesSortColumn;
    }

    public void setQueuesSortColumn(String queuesSortColumn) {
        this.queuesSortColumn = queuesSortColumn;
    }

    public String getCreator() {
        return creator;
    }

    public void setCreator(String creator) {
        this.creator = creator;
    }

    public String getCreateTime() {
        return createTime;
    }

    public void setCreateTime(String createTime) {
        this.createTime = createTime;
    }
}
