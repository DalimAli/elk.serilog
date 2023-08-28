# elk.serilog
Elashtic search, kibana, logstash with serilog and .net 6

# Download and Install Java 
https://www.oracle.com/java/technologies/downloads/#jdk20-windows

# Download Elastic search and Kibana 
https://www.elastic.co/downloads/past-releases#elasticsearch

https://www.elastic.co/downloads/past-releases#kibana

# Elastic Search Configuration 
Extract file somewhere in File Explorer

# Open Elastic search elasticsearch.yml (located in config folder) in editor
----> paste below line before cluster config

action.auto_create_index: .monitoring*,.watches,.triggered_watches,.watcher-history*,.ml*

---> check below lines

--> Enable security features

xpack.security.enabled: true

xpack.security.enrollment.enabled: true

--> Enable encryption for HTTP API client connections, such as Kibana, Logstash, and Agents

xpack.security.http.ssl:

  enabled: false
  
  keystore.path: certs/http.p12

--> Enable encryption and mutual authentication between cluster nodes

xpack.security.transport.ssl:

  enabled: false
  
  verification_mode: certificate
  
  keystore.path: certs/transport.p12
  
  truststore.path: certs/transport.p12
  
--> Create a new cluster with the current node only

--> Additional nodes can still join the cluster later

cluster.initial_master_nodes: ["Your computer name"]

Allow HTTP API connections from localhost and local networks

--> Connections are encrypted and require user authentication

http.host: [_local_, _site_]

# Open command prompt as admistrator and redirect to elastic search bin folder

type elasticsearch.bat and hit enter

Booooom ----->

elastic search will start running

# Password reset 

reset password: bin\elasticsearch-reset-password -u elastic

store somewhere will be needed to log in to localhost

# Running Elastic search as service

open command prompt and run

sc create "Elasticsearch 8.0.0" binPath= "D:\software\elk\elasticsearch-8.0.0\bin\elasticsearch.bat"



# Kibana Search Configuration
Navigate to kibana folder 

Open kibana.yml (located in config folder) in editor

uncomment these lines

  server.port: 5601
  
  server.host: "localhost"
  
  elasticsearch.hosts: ["http://localhost:9200"]
  
  elasticsearch.username: "kibana_system"
  
  elasticsearch.password: "Your password"

you can reset password in command prompt

reset password: bin\elasticsearch-reset-password -u kibana_system

# Open command prompt as admistrator and redirect to kibana bin folder

type kibana.bat and hit enter

Booooom ------->

kibana will start running

remember kibana is depend on elastic search

Kibana as service

sc create "Elasticsearch Kibana 8.0.0" binPath= "D:\software\elk\kibana-8.0.0\bin\kibana.bat" depend= "elasticsearch-service-x64" 


# #####Now you can log to elastic search#####
