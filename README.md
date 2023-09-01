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

# Open command prompt as admistrator and redirect to elastic search bin folder

type elasticsearch.bat and hit enter

Booooom ----->

elastic search will start running

Don't forget to copy HTTP CA certificate SHA-256 fingerprint AND Password for the elastic user

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
