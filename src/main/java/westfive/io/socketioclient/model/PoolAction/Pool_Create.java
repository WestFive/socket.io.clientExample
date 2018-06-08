package westfive.io.socketioclient.model.PoolAction;


public class Pool_Create {
    private String poolName;
    private String poolMode;
    private String queueSortColumn;
    private boolean forceOverWrite;

    public Pool_Create(String poolName, String poolMode, String queueSortColumn, boolean forceOverWrite) {
        this.poolName = poolName;
        this.poolMode = poolMode;
        this.queueSortColumn = queueSortColumn;
        this.forceOverWrite = forceOverWrite;
    }

    public Pool_Create() {
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

    public String getQueueSortColumn() {
        return queueSortColumn;
    }

    public void setQueueSortColumn(String queueSortColumn) {
        this.queueSortColumn = queueSortColumn;
    }

    public boolean isForceOverWrite() {
        return forceOverWrite;
    }

    public void setForceOverWrite(boolean forceOverWrite) {
        this.forceOverWrite = forceOverWrite;
    }

}
