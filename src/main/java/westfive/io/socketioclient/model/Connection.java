package westfive.io.socketioclient.model;

import org.springframework.context.annotation.Bean;

import java.util.Collection;


public class Connection  {
    private String connectionId;
    private String connectionName;
    private String connectionIpAddress;
    private Collection<String> privatePools;

    public Connection() {
    }

    public Collection<String> getPrivatePools() {
        return privatePools;
    }

    public void setPrivatePools(Collection<String> privatePools) {
        this.privatePools = privatePools;
    }

    public String getConnectionId() {
        return connectionId;
    }

    public void setConnectionId(String connectionId) {
        this.connectionId = connectionId;
    }

    public String getConnectionName() {
        return connectionName;
    }

    public void setConnectionName(String connectionName) {
        this.connectionName = connectionName;
    }

    public String getConnectionIpAdress() {
        return connectionIpAddress;
    }

    public Connection(String connectionId, String connectionName, String connectionIpAdress) {
        this.connectionId = connectionId;
        this.connectionName = connectionName;
        this.connectionIpAddress = connectionIpAdress;
    }

    public Connection(String connectionId, String connectionName, String connectionIpAdress, Collection<String>privatePools) {

        this.connectionId = connectionId;
        this.connectionName = connectionName;
        this.connectionIpAddress = connectionIpAdress;
        this.privatePools = privatePools;
    }

    public void setConnectionIpAdress(String connectionIpAdress) {

        this.connectionIpAddress = connectionIpAdress;
    }


}