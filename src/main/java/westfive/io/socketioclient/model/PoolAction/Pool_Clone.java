package westfive.io.socketioclient.model.PoolAction;

public class Pool_Clone {
    private String sourcePoolName;
    private String destPoolName;
    private String creator;

    public Pool_Clone(String sourcePoolName, String destPoolName, String creator) {
        this.sourcePoolName = sourcePoolName;
        this.destPoolName = destPoolName;
        this.creator = creator;
    }

    public Pool_Clone() {

    }

    public String getSourcePoolName() {

        return sourcePoolName;
    }

    public void setSourcePoolName(String sourcePoolName) {
        this.sourcePoolName = sourcePoolName;
    }

    public String getDestPoolName() {
        return destPoolName;
    }

    public void setDestPoolName(String destPoolName) {
        this.destPoolName = destPoolName;
    }

    public String getCreator() {
        return creator;
    }

    public void setCreator(String creator) {
        this.creator = creator;
    }
}
