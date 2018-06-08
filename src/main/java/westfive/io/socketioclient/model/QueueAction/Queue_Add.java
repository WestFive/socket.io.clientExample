package westfive.io.socketioclient.model.QueueAction;

import westfive.io.socketioclient.model.Queue;

public class Queue_Add {
        private String poolName;
        private Queue queue;

        public Queue_Add() {
        }

        public Queue_Add(String poolName, Queue queue) {
            this.poolName = poolName;
            this.queue = queue;
        }

        public String getPoolName() {
            return poolName;

        }

        public void setPoolName(String poolName) {
            this.poolName = poolName;
        }

        public Queue getQueue() {
            return queue;
        }

        public void setQueue(Queue queue) {
            this.queue = queue;
        }

}
